using AutoMapper;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using Tests.Dal.In;
using Tests.Dal.Models;
using Tests.Dal.Out;

namespace Tests.WebApi.Dal
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Status, OutStatusViewModel>();
            CreateMap<Quiz, OutQuizViewModel>().ForMember(x => x.Status, x => x.MapFrom(y => y.Status));
            CreateMap<InEmployeeViewModel, Employee>();

            CreateMap<Employee, OutEmployeeViewModel>().ForMember(x => x.Quizzes,
                x => x.MapFrom(y => y.UserQuizzes.ToList().Select(t => t.Quiz)))
                .ForMember(x => x.AvatarPath, x => x.MapFrom(y => y.Avatar.Path))
                .ForMember(x => x.ResumePath, x => x.MapFrom(y => y.Resume.Path))
                .ForMember(x => x.ResumeName, x => x.MapFrom(y => y.Resume.Name));

            CreateMap<Employee, Employee>()
                .ForMember(x => x.Id, x => x.MapFrom((y, yy) => yy.Id));


            CreateMap<LongevityType, OutLongevityTypeViewModel>();
            CreateMap<SubscriptionType, OutSubscriptionTypeViewModel>().ForMember(x => x.Longevity, x => x.MapFrom(y => y.LongevityType));
            CreateMap<Subscription, OutSubscriptionViewModel>().ForMember(x => x.Type, x => x.MapFrom(y => y.Type));
        }
    }
}