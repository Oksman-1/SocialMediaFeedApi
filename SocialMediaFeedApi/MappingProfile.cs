using AutoMapper;
using Entities.Models;
using Shared.DataTranferObjects;


namespace SocialMediaFeedApi;

public class MappingProfile : Profile
{

	public MappingProfile()
	{
		CreateMap<User, UserDTO>();

        CreateMap<Post, PostDTO>();

        CreateMap<Like, LikeDTO>().ReverseMap();

        CreateMap<UserFollowed, UserFollowedDTO>().ReverseMap();

		CreateMap<UserForCreationDTO, User>();	
		
		CreateMap<PostForCreationDTO, Post>();		

		CreateMap<LikeForCreationDTO, Like>();		

		//CreateMap<Class, ClassDto>();

		//CreateMap<ClassForCreationDto, Class>();

		//CreateMap<Student, StudentDto>();

		//Random rand = new Random();
		//string RegNum;

		//RegNum = Convert.ToString((long)Math.Floor(rand.NextDouble() * 19_000_000L + 10_000_000L));

		//CreateMap<StudentForCreationDto, Student>()
		//	.ForMember(c => c.StudentRegistrationNumber,
		//		opt => opt.MapFrom(x => string.Join('/', x.SchoolAreaCode, x.SchoolCode, RegNum,"LG")));

		//CreateMap<ClassForUpdateDto, Class>().ReverseMap();

		//CreateMap<StudentForUpdateDto, Student>().ReverseMap(); 

		//CreateMap<SchoolForUpdateDto, School>().ReverseMap();

	}
}
