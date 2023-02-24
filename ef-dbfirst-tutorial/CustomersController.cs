using ef_dbfirst_tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace ef_dbfirst_tutorial;

public class CustomersController
{
    private readonly SalesDbContext _context;
    public CustomersController()
    {
        _context = new SalesDbContext();
    }
    public async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }
    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }
    public async Task<bool> InsertAsync(Customer cust)
    {
        _context.Customers.Add(cust);
        var changes = await _context.SaveChangesAsync();
        return(changes == 1) ? true : false;    
    }
    public async Task<bool> UpdateAsync(Customer cust)
    {
        var customer = await _context.Customers.FindAsync(cust.Id);
        if (customer is null)
        {
            throw new Exception("Not found!");
        }
        _context.Entry(cust).State = EntityState.Modified;
        var changes = await _context.SaveChangesAsync();
        return (changes == 1) ? true : false;

    }
    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer is null)
        {
            throw new Exception("Not found!");
        }
        _context.Customers.Remove(customer);
        var changes = await _context.SaveChangesAsync();
        return (changes == 1) ? true : false;
    }
}
