using ECommProject_1144.DataAccess.Repository;
using ECommProject_1144.DataAccess.Repositry;
using ECommProject_1144.DataAccess.Repositry.IRepositry;
using EcomProject_1144.DataAccess.Data;
using EcomProject_1144.DataAccess.Repositry.IRepositry;
using EcomProject_1144.Models;
using EComProject_1144.DataAccess.Repositry.IRepositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject_1144.DataAccess.Repositry
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepositry(context);
            CoverType = new CoverTypeRepositry(context);
            SP_CALL = new SP_CALL(context);
            Product = new ProductRepositry(context);
            Company = new CompanyRepositry(context);
            ApplicationUser = new ApplicationUserRepositry(context);
            ShoppingCart = new ShoppingCartRepositry(context);
            OrderHeader = new OrderHeaderRepositry(context);
            OrderDetails = new OrderDetailsRepositry(context);
        }
        public ICategoryRepositry Category { private set; get; }

        public ICoverTypeRepositry CoverType { private set; get; }

        public ISP_CALL SP_CALL { private set; get; }
        public IProductRepositry Product { private set; get; }
        public ICompanyRepositry Company { private set; get; }
        public IApplicationUserRepositry ApplicationUser { private set; get; }
        public IShoppingCartRepositry ShoppingCart { private set; get; }

        public IOrderHeaderRepositry OrderHeader { private set; get; }

        public IOrderDetailsRepositry OrderDetails { private set; get; }

        public void Save()
        {

            _context.SaveChanges();
        }
    }
}
