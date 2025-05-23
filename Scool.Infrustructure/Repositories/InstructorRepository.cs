using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using Shcool.Infrustructure.Abstract;
using Shcool.Infrustructure.Data;
using Shcool.Infrustructure.InfrustractureBaseces;

namespace Shcool.Infrustructure.Repositories
{
    public class InstructorRepository : GenaricRepos<Instructor>, IInstructorRepository
    {
        #region Fields
        private DbSet<Instructor> instructors;

        #endregion

        #region constractor

        public InstructorRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            instructors = appDbContext.Set<Instructor>();
        }



        #endregion

        #region Habdel Function
        #endregion

    }
}
