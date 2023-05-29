using Microsoft.EntityFrameworkCore;
using SaviaHomeTest.Application.Abstractions;
using SaviaHomeTest.Application.Extensions;
using SaviaHomeTest.Domain.Exceptions;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace SaviaHomeTest.Infrastructure.Persistence.Repositories;

public class AppRepository<T> : IAppRepository<T> where T : class
{
    private readonly AppDbContextRead _AppDbContextRead;
    private readonly AppDbContextWrite _AppDbContextWrite;

    public AppRepository(AppDbContextRead appDbContextRead, AppDbContextWrite appDbContextWrite)
    {
        _AppDbContextRead = appDbContextRead;
        _AppDbContextWrite = appDbContextWrite;
    }

    ///<inheritdoc/>
    public async Task<IEnumerable<T>> GetAll()
    {
        return await _AppDbContextRead.Set<T>().ToListAsync();
    }

    ///<inheritdoc/>
    public async Task<T> GetById(Guid id)
    {
        var result = await _AppDbContextRead.Set<T>().FindAsync(id);
        
        return (result != null) 
            ? result 
            : throw new KeyNotFoundException();
    }

    /// <summary>
    /// Saves T in write and read databases
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>T</returns>
    public async Task<T> Save(T entity)
    {
        var writeNumberOfRowsAffected = await SaveWriteDb(entity);
        var readNumberOfRowsAffected = await SaveReadDb(entity);

        CheckDatabasesInconsistency(writeNumberOfRowsAffected, readNumberOfRowsAffected);

        return entity;
    }

    /// <summary>
    /// Updates T in write and read databases
    /// </summary>
    /// <param name="entity"></param>
    public async Task Update(T entity)
    {
        var writeNumberOfRowsAffected = await UpdateWriteDb(entity);
        var readNumberOfRowsAffected = await UpdateReadDb(entity);

        CheckDatabasesInconsistency(writeNumberOfRowsAffected, readNumberOfRowsAffected);
    }

    /// <summary>
    /// Deletes T in write and read databases
    /// </summary>
    /// <param name="entity"></param>
    public async Task Delete(T entity)
    {
        var writeNumberOfRowsAffected = await DeleteWriteDb(entity);
        var readNumberOfRowsAffected = await DeleteReadDb(entity);

        CheckDatabasesInconsistency(writeNumberOfRowsAffected, readNumberOfRowsAffected);
    }

    /// <summary>
    /// Saves T in write database
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>T</returns>
    private async Task<int> SaveWriteDb(T entity)
    {
        _AppDbContextWrite.Set<T>().Add(entity);
        return await _AppDbContextWrite.SaveChangesAsync();
    }

    /// <summary>
    /// Saves T in read database
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>T</returns>
    private async Task<int> SaveReadDb(T entity)
    {
        _AppDbContextRead.Set<T>().Add(entity);
        return await _AppDbContextRead.SaveChangesAsync();
    }

    /// <summary>
    /// Updates T in write database
    /// </summary>
    /// <param name="entity"></param>
    public async Task<int> UpdateWriteDb(T entity)
    {
        _AppDbContextWrite.Set<T>().Update(entity);
        return await _AppDbContextWrite.SaveChangesAsync();
    }

    /// <summary>
    /// Updates T in read database
    /// </summary>
    /// <param name="entity"></param>
    public async Task<int> UpdateReadDb(T entity)
    {
        _AppDbContextRead.Set<T>().Update(entity);
        return await _AppDbContextRead.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes T in write database
    /// </summary>
    /// <param name="entity"></param>
    public async Task<int> DeleteWriteDb(T entity)
    {
        _AppDbContextWrite.Set<T>().Remove(entity);
        return await _AppDbContextWrite.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes T in read database
    /// </summary>
    /// <param name="entity"></param>
    public async Task<int> DeleteReadDb(T entity)
    {
        _AppDbContextRead.Set<T>().Remove(entity);
        return await _AppDbContextRead.SaveChangesAsync();
    }

    /// <summary>
    /// Checks if the is an inconsistency in write and read databases and throws exception
    /// </summary>
    /// <param name="writeNumberOfRowsAffected"></param>
    /// <param name="readNumberOfRowsAffected"></param>
    /// <exception cref="InconsistenceInReadDatabaseException"></exception>
    /// <exception cref="InconsistenceInWriteDatabaseException"></exception>
    private void CheckDatabasesInconsistency(int writeNumberOfRowsAffected, int readNumberOfRowsAffected)
    {
        if (writeNumberOfRowsAffected == 1 && readNumberOfRowsAffected == 1)
            return;

        if (writeNumberOfRowsAffected == 0 && readNumberOfRowsAffected == 0)
            throw new SystemException();

        if (readNumberOfRowsAffected == 0)
            throw new InconsistenceInReadDatabaseException();

        if (writeNumberOfRowsAffected == 0)
            throw new InconsistenceInWriteDatabaseException();
    }
}
