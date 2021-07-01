using System;
using System.Collections.Generic;
using System.Linq;
using EF_Core.Models;
using EF_Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace EF_Core.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class StudentController : ControllerBase
    {
  
        private IStudentService _studentService;

        public StudentController(IStudentService studentService){
            _studentService = studentService;
        }

        [HttpGet("Students")]
        public IEnumerable<Students> Get()
        {
            return _studentService.GetList();
        }

        [HttpPost("Student")]
        public IActionResult  AddStudent(Students student)
        {
            var add = _studentService.CreateStudent(student);
            if (!add.Any())
            {
                return NotFound();
            }
            return Ok(add);
        }

        [HttpPut("Student/{id}")]
        public List<Students> UpdateStudent(Students student, int id)
        {
            var update = _studentService.EditStudent(student, id);
            return update;
        }

        [HttpGet("Student/{id}")]
        public Students FindByID(int id){
            return _studentService.FindByID(id);
        }

        [HttpDelete("Student/{id}")]
        public List<Students> IsDelete(int id)
        {
            var list = _studentService.IsDelete(id);
            return list;
        }

        [HttpGet("Student/FirstName={firstname}/LastName={lastname}/City={city}")]
        public List<Students> Filter(string firstname, string lastname, string city){
            return _studentService.Filter(firstname,lastname,city);
        }
    }


}