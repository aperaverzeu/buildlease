using Contracts.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Services.Abstractions;
using Services.Extension.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _db;

        public CustomerService(ApplicationDbContext dbContext, IServiceManager manager) => _db = dbContext;

        public CustomerInfo GetCustomerInfo(string userId)
        {
            var customer = _db.Customers
                .Include(e => e.Addresses)
                .SingleOrDefault(e => e.UserId == userId);

            if (customer is null)
            {
                customer = new Customer() { UserId = userId };
                _db.Customers.Add(customer);
                _db.SaveChanges();
            }

            var info = customer.MapToCustomerInfo();

            return info;
        }

        public void SaveCustomerInfo(CustomerInfo info)
        {
            var customer = info.MapToCustomer();
            var addresses = ExtractAddresses(info);

            _db.Database.BeginTransaction();

            _db.CustomerAddresses.RemoveRange(_db.CustomerAddresses.Where(e => e.CustomerId == customer.UserId));
            _db.CustomerAddresses.AddRange(addresses);
            _db.SaveChanges();

            var dbCustomer = _db.Customers.Single(e => e.UserId == customer.UserId);
            dbCustomer.CompanyName = customer.CompanyName;
            dbCustomer.RepresentativeName = customer.RepresentativeName;
            dbCustomer.ContactInfo = customer.ContactInfo;
            _db.Customers.Update(dbCustomer);
            _db.SaveChanges();

            _db.Database.CommitTransaction();
        }

        private IEnumerable<Address> ExtractAddresses(CustomerInfo info)
        {
            var addresses = new List<Address>();
            if (info.JuridicalAddress is not null)
                addresses.Add(info.JuridicalAddress.MapToAddress());
            if (info.DeliveryAddresses?.Any() is true)
                addresses.AddRange(info.DeliveryAddresses.MapToAddress());

            for (int i = 0; i < addresses.Count; i++)
            {
                addresses[i].CustomerId = info.UserId;
                addresses[i].Priority = info.JuridicalAddress is not null ? i : i + 1;
            }

            return addresses;
        }
    }
}
