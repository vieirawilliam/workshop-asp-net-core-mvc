using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeddingService
    {
        private SalesWebMvcContext _context;

        public SeddingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return;//o banco de dados ja tem registros
            }

            Department d1 = new Department();
            d1.Id = 10;
            d1.Name = "Computers";

            Seller s1 = new Seller();
            s1.Id = 1;
            s1.Name = "William";
            s1.Email = "william@mplan.com.br";
            s1.Birthdate = new DateTime(1988, 4, 13);
            s1.Basesalary = 1000;
            s1.Department = d1;

            SalesRecord r1 = new SalesRecord(1, new DateTime(2019, 10, 02), 1000, SalesStatus.Billed, s1);

            _context.Department.AddRange(d1);
            _context.Seller.AddRange(s1);
            _context.SalesRecord.AddRange(r1);

            _context.SaveChanges();
        }

    }
}
