using System;
using System.Collections.Generic;
using System.Linq;
using EF_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Services
{

    public class StudentService : IStudentService
    {
        private StudentContext _studentContext;
        public StudentService(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public IEnumerable<Students> GetList()
        {
            return _studentContext.Students.ToList();
        }

        public List<Students> CreateStudent(Students student)
        {
            _studentContext.Students.Add(student);
            _studentContext.SaveChanges();

            return _studentContext.Students.ToList();
        }

        public List<Students> EditStudent(Students student, int id)
        {
            Students existingStudent = _studentContext.Students.Find(id);

            if (existingStudent == null)
            {
                return new List<Students>();
            }
            else
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.City = student.City;
                existingStudent.State = student.State;

                _studentContext.Entry(existingStudent).State = EntityState.Modified;
                _studentContext.SaveChanges();
            }
            return _studentContext.Students.ToList();
        }

        public List<Students> IsDelete(int id)
        {
            Students existingStudent = _studentContext.Students.Find(id);
            _studentContext.Remove(existingStudent);
            _studentContext.SaveChanges();
            return _studentContext.Students.ToList();
        }

        public Students FindByID(int id)
        {
            Students existingStudent = _studentContext.Students.Find(id);

            return existingStudent;
        }

        //Filter (FirstName LastName City) = bai tap ve nha => tim gan dung
        public List<Students> Filter(string fname,string lname,string city)
        {
            var filter =  _studentContext.Students.Where(p =>p.FirstName.ToLower().Contains(fname) || p.LastName.ToLower().Contains(lname) || p.City.ToLower().Contains(city) ).ToList();
            return filter;
        }
    }

}