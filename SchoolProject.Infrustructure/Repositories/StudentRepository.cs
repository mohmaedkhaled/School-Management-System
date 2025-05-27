using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrustructure.Abstracts;
using SchoolProject.Infrustructure.Data;
using SchoolProject.Infrustructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>,IStudentRepository
    {
        private readonly DbSet<Student> _students;

        public StudentRepository(ApplicationDBContext dBcontext):base(dBcontext) 
        {
            _students=dBcontext.Set<Student>();
        }
        public async Task<List<Student>> GetStudentsListAsyns()
        {
            return await _students.Include(x =>x.Department).ToListAsync();
        }
    }
}
