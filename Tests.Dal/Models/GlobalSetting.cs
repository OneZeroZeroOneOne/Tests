using Microsoft.EntityFrameworkCore;

namespace Tests.Dal.Models
{
    public class GlobalSetting
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string? StringValue { get; set; }
        public int? IntValue { get; set; }
    }


    public static class ContextGlobalSettingExtension
    {
        public static ModelBuilder AddGlobalSettings(this ModelBuilder model)
        {
            model.Entity<GlobalSetting>(x =>
            {
                x.ToTable("GlobalSetting");
                x.HasKey(xx => xx.Id);
            });

            return model;
        }
    }
}
