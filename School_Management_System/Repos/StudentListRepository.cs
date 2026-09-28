//using School_Management_System.Models;
//using School_Management_System.Repos.Abstraction;

//namespace School_Management_System.Repos;

//public class StudentListRepository : IStudentRepository
//{
//    public static List<Student> Students = new List<Student>
//    {
//        new Student {Id = 1, FirstName = "ahmed", LastName = "sayed", Email ="test@gmail.com"},
//        new Student {Id = 2, FirstName = "mahmoud", LastName = "sayed", Email ="test2@gmail.com"},
//        new Student {Id = 3, FirstName = "mostafa", LastName = "ibrahim", Email ="test3@gmail.com"},
//        new Student {Id = 4, FirstName = "ali", LastName = "sayed", Email ="test4@gmail.com"},
//    };

//    public List<Student> GetAll()
//    {
//        return Students.ToList();
//    }
//    public Student GetById(int id)
//    {
//        return Students.FirstOrDefault(s => s.Id == id);
//    }
//}
