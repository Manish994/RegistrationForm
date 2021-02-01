using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegestrationForm.Models;

namespace RegestrationForm.Repositories
{
    public interface IStudentRepository
    {
        Task Insert(Student student);
        Task updateInsert(Student student);
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
        Task DelById(Student student);
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly studentDetailsContext _studentDetailsContext;
        public StudentRepository(studentDetailsContext studentDetailsContext)
        {
            _studentDetailsContext = studentDetailsContext;
        }

        public async Task DelById(Student student)
        {
             _studentDetailsContext.Students.Remove(student);
            await _studentDetailsContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _studentDetailsContext.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _studentDetailsContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(Student student)
        {
            await _studentDetailsContext.Students.AddAsync(student);
            await _studentDetailsContext.SaveChangesAsync();
        }

        public async Task updateInsert(Student student)
        {
            //Student objstudent = await _studentDetailsContext.Students.FirstAsync(x => x.Id == student.Id);
            //{
            //    await _studentDetailsContext.Students.Update(objstudent);
            //    await _studentDetailsContext.SaveChangesAsync();
            //}
            _studentDetailsContext.Students.Update(student);
            await _studentDetailsContext.SaveChangesAsync();
            
        }
    }
    
}
