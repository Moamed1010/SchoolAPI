using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using Shcool.Infrustructure.Data;
using Shcool.Infrustructure.InfrustractureBaseces;
using Shcool.Infrustructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shcool.Infrustructure.Repositories
{
    public class StudentRepository :GenaricRepos<Student>, IStudentRepositories
    {
        #region Fields
        
        private readonly DbSet<Student> _dbSet;
        #endregion

        #region Ctor 
        public StudentRepository(AppDbContext _context) : base(_context)
        {
            _dbSet = _context.Set<Student>();
        }

        
        #endregion

        #region Handel Function
        public async Task<List<Student>> GetStudentListAsync()
        {
          return await _dbSet.Include(x=>x.Department).ToListAsync ();
        }
        #endregion

    }
}
