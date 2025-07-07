using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommProject_1144.DataAccess.Repositry.IRepositry;
using EcomProject_1144.DataAccess.Data;
using EcomProject_1144.Models;

namespace EcomProject_1144.DataAccess.Repositry
{
    public class ShoppingCartRepositry: Repositry<ShoppingCart>, IShoppingCartRepositry
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartRepositry(ApplicationDbContext context):base(context)
        {
            _context = context;  
        }

    }
}
