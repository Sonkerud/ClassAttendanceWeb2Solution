using ClassAttendanceWeb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassAttendanceWeb2.Data
{
    public class StudentData
    {

        List<Student> students = new List<Student>();
        

        void AddData()
        {
            students.Add(new Student { Id = "1", Name = "Alexander Sonerud", Attending = "true" });
            students.Add(new Student { Id = "2", Name = "Viktor Hörwing", Attending = "true" });
            students.Add(new Student { Id = "3", Name = "Samuel Lindgren", Attending = "true" });
        }

    }
}
