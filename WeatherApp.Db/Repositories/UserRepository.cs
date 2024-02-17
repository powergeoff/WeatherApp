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
    IEnumerable<User> GetUsers();
    User? GetUserById(ObjectId id);
    User? GetUserByName(string name);
    bool InsertUser(User user);
    void DeleteUser(ObjectId id); //again by ObjectId
    void UpdateUser(User user); //ObjectId
    void Save();
}
public class UserRepository : IUserRepository, IDisposable
{
    private WeatherAppDbContext _context;
    private bool _disposed = false;
    public UserRepository(WeatherAppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<User> GetUsers() => _context.Users.ToList();
    public User? GetUserById(ObjectId id) => _context.Users.FirstOrDefault(u => u.Id == id);
    public User? GetUserByName(string name) => _context.Users.FirstOrDefault(u => u.UserName == name);
    public bool InsertUser(User user)
    {
        //if the user already exists by user name - don't insert
        if (GetUserByName(user.UserName) != null)
            return false;
        //encrypt password
        _context.Users.Add(user);
        return true;
    }
    public void Save() => _context.SaveChanges();

    public void DeleteUser(ObjectId id)
    {
        User? user = _context.Users.Find(id);
        if (user != null)
            _context.Users.Remove(user);
    }
    public void UpdateUser(User user)
    {
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
