using EcomProject_1144.DataAccess.Data;
using EcomProject_1144.DataAccess.Repositry.IRepositry;
using EcomProject_1144.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject_1144.DataAccess.Repositry
{
    public class CoverTypeRepositry : Repositry<CoverType>,ICoverTypeRepositry
    {
        private readonly ApplicationDbContext _context;
            public CoverTypeRepositry(ApplicationDbContext context)
            :base(context)
        {
            _context = context;
        }

    }
}
