using System;
using System.Collections.Generic;
using EF_Core.Models;


namespace EF_Core.Services
{

    public interface IStudentService
    {
        IEnumerable<Students> GetList();
        List<Students> CreateStudent(Students student);
        List<Students> EditStudent(Students student, int id);
        List<Students> IsDelete(int id);

        Students FindByID(int id);
        List<Students> Filter(string fname,string lname,string city);

    }

}