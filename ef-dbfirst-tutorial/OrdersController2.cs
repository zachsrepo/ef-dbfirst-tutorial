using ef_dbfirst_tutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_dbfirst_tutorial
{
    public class OrdersController2
    {
        private readonly SalesDbContext _context;
        public OrdersController2()
        {
            _context = new SalesDbContext();
        }
        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.Include(x => x.Customer).ToListAsync();
        }
        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.Include(x => x.Customer)
                                        .Include(x => x.OrderLines)
                                        .SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var order = await GetByIdAsync(id);
            if(order is null)
            {
                return false;
            }
            _context.Orders.Remove(order);
            return await SaveDbAsync();
        }
        public async Task<bool> InsertAsync(Order order)
        {
            _context.Orders.Add(order);
            return await SaveDbAsync();
        }
        public async Task<bool> UpdateAsync(Order order)
        {
            var ord = await GetByIdAsync(order.Id);
            if(ord is null)
            {
                return false;
            }
            _context.Orders.Entry(ord).State = EntityState.Modified;
            return await SaveDbAsync();
        }
        private async Task<bool> SaveDbAsync()
        {
            var changes = await _context.SaveChangesAsync();
            return (changes == 1) ? true : false;
        }
    }
}
