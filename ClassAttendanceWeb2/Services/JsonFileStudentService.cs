using ClassAttendanceWeb2.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassAttendanceWeb2.Services
{
    public class JsonFileStudentService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        Random random = new Random();

        List<Student> studentss = new List<Student>() {new Student { Id = "1", Name = "Alexander Sonerud", Attending = "På plats!" },
                                       new Student { Id = "2", Name = "Viktor Hörwing", Attending = "På plats!" },
                                       new Student { Id = "3", Name = "Samuel Lindgren", Attending = "På plats!" },
                                       new Student { Id = "4", Name = "Daniel Andersson", Attending = "På plats!" },
                                       new Student { Id = "5", Name = "Anja Johansson Arnsesson", Attending = "På plats!" },
                                       new Student { Id = "6", Name = "Marie Degerström", Attending = "På plats!" },
                                       new Student { Id = "7", Name = "Ansari Haji Cheteh", Attending = "På plats!" },
                                       new Student { Id = "8", Name = "Axel Friberg", Attending = "På plats!" },
                                       new Student { Id = "9", Name = "Abdi Gobena", Attending = "På plats!" },
                                       new Student { Id = "10", Name = "Daniel Lundqvist", Attending = "På plats!" },
                                       new Student { Id = "11", Name = "Jens Lövgren", Attending = "På plats!" },
                                       new Student { Id = "12", Name = "Eric Runer", Attending = "På plats!" },
                                       new Student { Id = "13", Name = "Martin Viksten", Attending = "På plats!" },
                                       new Student { Id = "14", Name = "Malin Gröön", Attending = "På plats!" },
                                       new Student { Id = "15", Name = "Pontus Nelander", Attending = "På plats!" }


        };

        List<Student> students = new List<Student>() {new Student { Id = "1", Name = "Bamse Björn", Attending = "På plats!" },
                                       new Student { Id = "2", Name = "Lego Larsson", Attending = "På plats!" },
                                       new Student { Id = "3", Name = "Sven Svensson", Attending = "På plats!" },
                                       new Student { Id = "4", Name = "Badtunna Tunnsson", Attending = "På plats!" },
                                       new Student { Id = "5", Name = "Göran Gillinger", Attending = "På plats!" },
                                       new Student { Id = "6", Name = "Lennart Jäkel", Attending = "På plats!" },
                                       new Student { Id = "7", Name = "Karl Karlsson", Attending = "På plats!" },
                                       new Student { Id = "8", Name = "Fia Flinta", Attending = "På plats!" },
                                       new Student { Id = "9", Name = "Joy Division", Attending = "På plats!" },
                                       new Student { Id = "10", Name = "Linda Bandage", Attending = "På plats!" },
                                       new Student { Id = "11", Name = "Siv Slev", Attending = "På plats!" },
                                       new Student { Id = "12", Name = "Radio Fem", Attending = "På plats!" },
                                       new Student { Id = "13", Name = "Kväll Morgonsson", Attending = "På plats!" },
                                       new Student { Id = "14", Name = "Rut Spader", Attending = "På plats!" },
                                       new Student { Id = "15", Name = "Ponton Flyter", Attending = "På plats!" }


        };


        public JsonFileStudentService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;

        }
        public JsonFileStudentService()
        {

        }


        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "students.json"); }
        }

        public IEnumerable<Student> GetStudents()
        {
            return students;
        }

        //public IEnumerable<Student>GetProducts()
        //{

        //    using (var jsonFileReader = File.OpenText(JsonFileName))
        //    {
        //        return JsonSerializer.Deserialize<Student[]>(jsonFileReader.ReadToEnd(),
        //             new JsonSerializerOptions
        //             {
        //                 PropertyNameCaseInsensitive = true
        //             });
        //    }
        //}

        public void ChangeAttendingStatus(string productId)
        {
            var products = GetStudents();
          
            var student = students.First(x => x.Id == productId);
            if (student.Attending == "På plats!")
            {
                student.Attending = "Inte här";
            }
            else if (student.Attending == "Inte här")
            {
                student.Attending = "På plats!";
            }



            //using (var outputStream = File.OpenWrite(JsonFileName))
            //{


            //    JsonSerializer.Serialize<IEnumerable<Student>>(
            //        new Utf8JsonWriter(outputStream, new JsonWriterOptions
            //        {
            //            SkipValidation = true,
            //            Indented = true
            //        }),
            //        products
            //    );
            //}
        }
        public int NumberOfGroups()
            {
            int nr = GetStudents().Where(x => x.Attending == "På plats!").Count();

            if (nr <= 3)
            {
                return nr;
            }
            else if (nr < 10)
            {
                if (nr == 4)
                {
                    return 2;
                }
                else if (nr % 3 == 2) //5 = 3,2. 8 = 3,3,2
                {
                    return 3;
                }
                else if (nr % 3 == 1) // 7
                {
                    return 4;
                }
            } 
            else if (nr < 25)
            {
                switch (nr)
                {
                    case 10: return 5;
                    case 11: return 4;                      
                    case 12: return 4;
                    case 13: return 5;
                    case 14: return 3;
                    case 15: return 5;
                    case 16: return 4;
                    case 17: return 3; 
                    default: return 3;

                }
            }
            return 3;
        }

        public Dictionary<int, List<Student>> GroupClass()
        {
            int chunk = NumberOfGroups();
            Dictionary<int, List<Student>> attendeesSortedIntoGroups = new Dictionary<int, List<Student>>();
            var list = students.Where(x => x.Attending == "På plats!").Select(c => c).ToList();
            var newRandomList = students.Where(x => x.Attending == "På plats!").OrderBy(c => random.Next()).Select(c => c).ToList();


            for (int i = 0; i <= list.Count / chunk; i++)
            {
                if (newRandomList.Count >= chunk)
                {
                    attendeesSortedIntoGroups.Add(i, newRandomList.Take(chunk).ToList());

                    for (int x = 0; x < chunk; x++)
                    {
                        newRandomList.RemoveAt(0);
                    }
                }
                else if (newRandomList.Count != 0)
                {
                    attendeesSortedIntoGroups.Add(i, newRandomList.Take(newRandomList.Count).ToList());
                }
            }
            return attendeesSortedIntoGroups;
        }
        public int ChoseGroupForPresentation()
        {
            return random.Next(1, NumberOfGroups());
        }
    }
}
