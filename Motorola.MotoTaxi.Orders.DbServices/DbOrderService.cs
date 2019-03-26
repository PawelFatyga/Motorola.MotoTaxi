using Microsoft.EntityFrameworkCore;
using Motorola.MotoTaxi.Orders.DomainModels;
using Motorola.MotoTaxi.Orders.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Motorola.MotoTaxi.Orders.DbServices
{
    public class DbOrderService : IOrderService
    {
        private readonly OrdersContext context;

        public DbOrderService(OrdersContext context)
        {
            this.context = context;
        }

        public void Add(Order entity)
        {
            context.Orders.Add(entity);
            context.SaveChanges();
        }
        
        public void Cancel(int id)
        {
            throw new NotImplementedException();
        }

        public void Complete(int id, Location destination)
        {
            throw new NotImplementedException();
        }

        public void Confirm(int id)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            return context.Orders.FromSql($"Select * from dbo.Orders where id={id}").SingleOrDefault();
        }

        public IEnumerable<Order> Get()
        {
            return context.Orders.AsNoTracking().ToList();
        }

        public void Start(int id, Location start)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entyity)
        {
            context.Orders.Update(entyity);
            context.SaveChanges();
        }
    }
}
