using ef_dbfirst_tutorial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_dbfirst_tutorial
{
    public class OrdersController
    {
        private readonly SalesDbContext _context;

        public OrdersController()
        {
            _context = new SalesDbContext();
        }
        public async Task<List<Order>> GetAllAsync()
        {
           return await _context.Orders.Include(x => x.Customer).ToListAsync();
        }
        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                                 .Include(x => x.Customer)
                                 .Include(x => x.OrderLines)
                                 .SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> InsertAsync(Order order)
        {
            _context.Orders.Add(order);
            return await SaveDbAsync();
        }
        public async Task<bool> UpdateAsync(Order order)
        {
            //var ord = await _context.Orders.FindAsync(order.Id);
            var ord = await GetByIdAsync(order.Id); 
            if(ord is null)
            {
                return false;
            }
            _context.Orders.Entry(order).State = EntityState.Modified;
            return await SaveDbAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            //var order = await _context.Orders.FindAsync(id);
            var ord = await GetByIdAsync(id);
            if(ord is null)
            {
                return false;
            }
            _context.Orders.Remove(ord);
            return await SaveDbAsync();
        }
        private async Task<bool> SaveDbAsync()
        {
            var changes = await _context.SaveChangesAsync();
            return (changes == 1) ? true : false;
        }

    }
}
