//using AutoMapper;
//using School_Management_System.DTOs;
//using School_Management_System.Models;

//namespace School_Management_System.Mappings;

//public class StudentProfile : Profile
//{
//    public StudentProfile()
//    {
//        CreateMap<Student, StudentDTO>()
//            .ForMember(dest => dest.FullName,
//            opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

//        CreateMap<Student, StudentDetailsDTO>()
//                 .ForMember(dest => dest.FullName,
//            opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))

//                 .ForMember(dest => dest.GradeLevel,
//                 opt => opt.MapFrom(src => src.Classroom.GradeLevel));


//        CreateMap<CreateStudentDTO, Student>()
//            .ForMember(des => des.FirstName,
//            opt => opt.MapFrom(src => src.FullName.Split(' ')[0]))

//            .ForMember(des => des.LastName,
//            opt => opt.MapFrom(src => src.FullName.Split(' ')[1]));


//        CreateMap<UpdateStudentDTO, Student>()
//            .ForMember(des => des.FirstName,
//            opt => opt.MapFrom(src => src.FullName.Split(' ')[0]))

//            .ForMember(des => des.LastName,
//            opt => opt.MapFrom(src => src.FullName.Split(' ')[1]));













//    }
//}
