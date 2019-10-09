using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.DAL.Interfaces
{
    public interface IStudentsRepository
    {
        Task<DomainModels.Student> Create(DomainModels.CreateStudent student);

        Task<DomainModels.Student> GetAll(DomainModels.CreateStudent student);
    }
}
