using School.Data.Models;
using Shcool.Infrustructure.InfrustractureBaseces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shcool.Infrustructure.IRepositories
{
     public interface IStudentRepositories:IGenaricRepos<Student>
    {
        public Task<List<Student>> GetStudentListAsync(); 
    }
}
