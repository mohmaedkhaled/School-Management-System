using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentsByIDWithIncludeAsync(int id);
        public Task<Student> GetByIDAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<bool> IsNameArExist(string name);
        public Task<bool> IsNameEnExist(string name);
        public Task<bool> IsNameArExistExcludeSelf(string name, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string name, int id);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        public IQueryable<Student> GetStudentsQuerable();
        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search);

    }
}
