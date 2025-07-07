using EcomProject_1144.DataAccess.Data;
using EcomProject_1144.DataAccess.Repositry.IRepositry;
using EcomProject_1144.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject_1144.DataAccess.Repositry
{
    public class CategoryRepositry:Repositry<Category>, ICategoryRepositry
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepositry(ApplicationDbContext context)
            :base(context)
        {
           _context = context;
        }
    }
}
