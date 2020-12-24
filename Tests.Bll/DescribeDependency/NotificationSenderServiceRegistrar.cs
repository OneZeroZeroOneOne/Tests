using Microsoft.Extensions.DependencyInjection;
using Tests.Bll.Services;
using Tests.Bll.Services.NotificationSenderTarget;

namespace Tests.Bll.DescribeDependency
{
    public static class NotificationSenderServiceRegistrar
    {
        public static void AddNotificationSender(this IServiceCollection services)
        {
            services.AddTransient<NotificationSenderService>();

            services.AddTransient<INotificationTarget, NotificationWebTarget>();
        }
    }
}
