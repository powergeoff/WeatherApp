using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using WeatherApp.Db.Models;
using MongoDB.Bson;
using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Db.Repositories;

//https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application

public interface IUserRepository : IDisposable
{
    Task<IEnumerable<User>> GetUsers();
    Task<User?> GetUserById(ObjectId id);
    Task<User?> GetUserByName(string name);
    Task<bool> InsertUser(User user);
    void DeleteUser(ObjectId id);
    void UpdateUser(User user);
    Task Save();
}
public class UserRepository : IUserRepository, IDisposable
{
    private WeatherAppDbContext _context;
    private bool _disposed = false;
    public UserRepository(WeatherAppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> GetUsers() => await _context.Users.ToListAsync();
    public async Task<User?> GetUserById(ObjectId id) => await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    public async Task<User?> GetUserByName(string name) => await _context.Users.FirstOrDefaultAsync(u => u.UserName == name);
    public async Task<bool> InsertUser(User user)
    {
        //if the user already exists by user name - don't insert
        var dbUser = await GetUserByName(user.UserName);
        if (dbUser != null)
            return false;
        user.Created = DateTime.Now;
        user.Modified = DateTime.Now;
        //encrypt password
        await _context.Users.AddAsync(user);
        return true;
    }
    public async Task Save() => await _context.SaveChangesAsync();

    public void DeleteUser(ObjectId id)
    {
        User? user = _context.Users.Find(id);
        if (user != null)
            _context.Users.Remove(user);
    }
    public void UpdateUser(User user)
    {
        user.Modified = DateTime.Now;
        _context.Entry(user).State = EntityState.Modified;
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this._disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

}
