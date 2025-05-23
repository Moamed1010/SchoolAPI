using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using Shcool.Infrustructure.Abstract;
using Shcool.Infrustructure.Data;
using Shcool.Infrustructure.InfrustractureBaseces;

namespace Shcool.Infrustructure.Repositories
{
    public class SubjectRepository : GenaricRepos<Subjects>, ISubjectRepository
    {

        #region Fields
        private DbSet<Subjects> subjects;
        #endregion
        #region constractor
        public SubjectRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        #endregion

        #region Habdel Function
        #endregion
    }
}
