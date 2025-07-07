using EcomProject_1144.DataAccess.Data;
using EcomProject_1144.DataAccess.Repositry;
using EComProject_1144.DataAccess.Repositry.IRepositry;
using EComProject_1144.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommProject_1144.DataAccess.Repositry
{
    public class OrderHeaderRepositry : Repositry<OrderHeader>, IOrderHeaderRepositry
    {
        private readonly ApplicationDbContext _context;
        public OrderHeaderRepositry(ApplicationDbContext context) : base(context)
        {
            _context = context;
            
        }
    }
}
