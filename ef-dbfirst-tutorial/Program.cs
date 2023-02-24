



using ef_dbfirst_tutorial;
using ef_dbfirst_tutorial.Models;
using Microsoft.EntityFrameworkCore;

var dbc = new SalesDbContext();
var custCtrl = new CustomersController();
var orderCtrl = new OrdersController2();
var orderLineCtrl = new OrderLinesController();

var orderline1 = await orderCtrl.GetByIdAsync(2);
Console.WriteLine(orderline1);
var orderTotal = orderline1.OrderLines.Sum(x => x.Price * x.Quantity);
Console.WriteLine($"\nOrder total is {orderTotal}");




//var orders = await orderCtrl.GetAllAsync();
//orders.ForEach(x  => Console.WriteLine(x)); 
   

//orderline1.OrdersId = 2;
//orderline1.Product = "plastic";
//orderline1.Description = "junk";
//orderline1.Price = 50.50m;


//var success = await orderLineCtrl.UpdateAsync(orderline1);
//Console.WriteLine(success ? "insert worked" : "its broken");

//var success = await orderLineCtrl.InsertAsync(orderLine1);
//Console.WriteLine(success ? "insert worked" : "its broken");

//var orderline = await orderLineCtrl.GetAllAsync();
//foreach(var n in orderline)
//{
//    Console.WriteLine(n);
//}
//Console.WriteLine();
//var ordline = await orderLineCtrl.GetByIdAsync(1);
//Console.WriteLine(ordline);






//Order order1 = new Order()
//{
//    Id = 0,
//    CustomerId = 1, // this has to be tied to a customer or it will not work.
//    Date = DateTime.Now,
//    Description = "my custom order for kroger"

//};
//var success = await orderCtrl.InsertAsync(order1);
//Console.WriteLine(success ? "added" : "failed");

//Console.WriteLine();

//var ord = await orderCtrl.GetAllAsync();
//ord.ForEach(n => Console.WriteLine(n.Description));

//Console.WriteLine();

//var order = await orderCtrl.GetByIdAsync(28);
//Console.WriteLine(order);
//order.Description += "by ZT";
//var success = await orderCtrl.UpdateAsync(order);
//Console.WriteLine(success ? "updated" : "failed");


//Console.WriteLine();

//var success = await orderCtrl.DeleteAsync(28);
//Console.WriteLine(success ? "deleted" : "failed");




//var success = await custCtrl.DeleteAsync(38);

//if (!success)
//{
//    Console.WriteLine("failed update");
//}



//var bootcamp = await custCtrl.GetByIdAsync(38);
//bootcamp.Sales = 5000;
//var success = await custCtrl.UpdateAsync(bootcamp);
//var cust = new Customer()
//{
//    Id = 0,
//    Name = "BootCamp",
//    City = "Mason",
//    State = "OH",
//    Sales = 0,
//    Active = true
//};
//var success = await custCtrl.InsertAsync(cust);
//Console.WriteLine(success ? "ok" : "Failed");






/*
var customers = await custCtrl.GetAllAsync();
foreach( var customer in customers)
{
    Console.WriteLine(customer.Name);
}

Console.WriteLine();

var cust = await custCtrl.GetByIdAsync(1);
Console.WriteLine(cust.Name);

Console.WriteLine();    
*/
//var customer = await GetById(1);
//Console.WriteLine(customer.Name);
/*
async Task<Customer> GetById(int id)
{
    return await dbc.Customers.FindAsync(id);
}
*/
/*
var customers = await GetAll();
foreach (var cust in customers)
{
    Console.WriteLine(cust.Name);

}

async Task<List<Customer>> GetAll()
{
    return await dbc.Customers.ToListAsync();
}
*/
/*
var orderWithCustomers = from o in dbc.Orders
                         join c in dbc.Customers
                         on o.CustomerId equals c.Id
                         orderby c.Name
                         select new
                         {
                             Id = o.Id,
                             Desc = o.Description,
                             Customer = c.Name
                         };

foreach(var oc in orderWithCustomers)
{
    Console.WriteLine($"{oc.Id,2} | {oc.Customer,-30} | {oc.Desc,-30}");
}
*/
/*
var orders = from o in dbc.Orders
             select o;

foreach(var order in orders)
{
    Console.WriteLine(order.Description);
}

var customers = dbc.Customers.Where(n => n.City == "Cincinnati")
                             .OrderByDescending(n => n.Sales)                         
                             .ToList();
                             
foreach(var cust in customers)
{
    Console.WriteLine($"{cust.Name}");
}
*/