using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class GlobalSetting
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string StringValue { get; set; }
        public long? IntValue { get; set; }
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
