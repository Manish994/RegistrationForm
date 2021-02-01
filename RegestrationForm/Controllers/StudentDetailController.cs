using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegestrationForm.ClassModel;
using RegestrationForm.Models;
using RegestrationForm.Repositories;

namespace RegestrationForm.Controllers
{
    [ApiController]
    public class StudentDetailController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentDetailController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost]
        [Route("create-studentDetails")]
        public async Task<IActionResult> Insert(Student student)
        {
            try
            {
                await _studentRepository.Insert(student);
                return Ok("Student has been inserted");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("saveUpdate-studentDetails")]
        public async  Task<IActionResult> updateInsert(Student student)
        {
            try
            {
                await _studentRepository.updateInsert(student);
                return Ok("Successfully Updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("students")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Student> students = await _studentRepository.GetAll();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("student/{id}")]
        public async Task<IActionResult> EditStudentDetails(int id)
        {

            var student = await _studentRepository.GetById(id);
            return Ok(student);
        }

        [HttpPost]
        [Route("del-student")]
        public async Task<IActionResult> DeleteStudentDetails(Student student)
        {

            await _studentRepository.DelById(student);
            return Ok("Student has been successfully deleted");
        }
    }
}
