using AutoMapper;
using System.Linq;
using Tests.Dal.In;
using Tests.Dal.Models;
using Tests.Dal.Models.Views;
using Tests.Dal.Out;

namespace Tests.Dal
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Status, OutStatusViewModel>();
            CreateMap<Quiz, OutQuizViewModel>().ForMember(x => x.Status, x => x.MapFrom(y => y.Status));
            
            CreateMap<InEmployeeViewModel, Employee>();
            CreateMap<InVacancyViewModel, Vacancy>();
            CreateMap<InPositionViewModel, Position>();

            CreateMap<Position, OutPositionViewModel>();
            CreateMap<Avatar, OutAvatarViewModel>();
            CreateMap<Resume, OutResumeViewModel>();
            CreateMap<Vacancy, OutVacancyViewModel>();

            CreateMap<Employee, OutEmployeeViewModel>().ForMember(x => x.Quizzes,
                x => x.MapFrom(y => y.UserQuizzes.ToList().Select(t => t.Quiz)))
                .ForMember(x => x.Vacancy, x => x.MapFrom(y => y.Vacancy))
                .ForMember(x => x.Resume, x => x.MapFrom(y => y.Resume))
                .ForMember(x => x.Resume, x => x.MapFrom(y => y.Resume));

            CreateMap<Employee, Employee>()
                .ForMember(x => x.Id, x => x.MapFrom((y, yy) => yy.Id));


            CreateMap<LongevityType, OutLongevityTypeViewModel>();
            CreateMap<SubscriptionType, OutSubscriptionTypeViewModel>().ForMember(x => x.Longevity, x => x.MapFrom(y => y.LongevityType));
            CreateMap<Subscription, OutSubscriptionViewModel>().ForMember(x => x.Type, x => x.MapFrom(y => y.Type));

            CreateMap<PositionsWithCount, OutPositionsWithCount>();

            CreateMap<InUpdateNotificationSetting, UserNotificationSetting>()
                .ForMember(x => x.NotificationTargetTypeId, y=> y.MapFrom(x => x.TargetTypeId))
                .ForMember(x => x.NotificationTypeId, y => y.MapFrom(x => x.TypeId));
        }
    }
}