using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using Shcool.Infrustructure.Abstract;
using Shcool.Infrustructure.Data;
using Shcool.Infrustructure.InfrustractureBaseces;

namespace Shcool.Infrustructure.Repositories
{
    public class DepartmentRepository : GenaricRepos<Department>, IDepartmentRepository
    {
        #region Fields 
        private DbSet<Department> departments;
        #endregion
        #region constractor
        public DepartmentRepository(AppDbContext appContext) : base(appContext)
        {
            departments = appContext.Set<Department>();

        }
        #endregion
        #region Habdel Function
        #endregion

    }
}
