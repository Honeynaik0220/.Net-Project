using EcomProject_1144.DataAccess.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcomProject_1144.DataAccess.Data;
using EComProject_1144.Models;
using EComProject_1144.DataAccess.Repositry.IRepositry;

namespace ECommProject_1144.DataAccess.Repository
{
    public class OrderDetailsRepositry: Repositry<OrderDetails>,IOrderDetailsRepositry
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailsRepositry(ApplicationDbContext context):base(context)
        {
            _context = context;            
        }
    }
}
