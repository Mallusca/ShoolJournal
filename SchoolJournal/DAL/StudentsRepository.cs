namespace SchoolJournal.DAL
{
    using Mapster;
    using SchoolJournal.DAL.Interfaces;
    using SchoolJournal.DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;

    public class StudentsRepository : RepositoryBase, IStudentsRepository
    {
        public StudentsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<DomainModels.Student> Create(DomainModels.CreateStudent student)
        {
            Student dbModel = student.Adapt<Student>();

            DbContext.Students.Add(dbModel);
            await DbContext.SaveChangesAsync();

            return dbModel.Adapt<DomainModels.Student>();
        }

        Студенты, их оценка и дата их посещения
        

            

            tr - td - td
            tr - td - td
            tr - td - td



        public async Task<DomainModels.Student> GetAll(DomainModels.CreateStudent student)
        {
            Student dbModel = student.Adapt<Student>();
            var stList = DbContext.Students.ToList();

            // Student dbModel = student.Adapt<Student>();
            // var stList = DbContext.Students.ToList();
            //foreach (var student in stList)

            //     dbModel.Adapt(new DomainModels.CreateStudent()
            //     {
            //         students.Id = studentId,
            //         studentFirstName = student.FirstName,
            //         studentLastName = student.LastName
            //     });
            // return dbModel;
        }

    }
}