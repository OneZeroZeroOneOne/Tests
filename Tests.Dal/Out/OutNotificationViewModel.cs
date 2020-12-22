using System.Collections.Generic;

namespace Tests.Dal.Out
{
    public class OutNotificationViewModel
    {
        public List<OutNotificationSettingViewModel> Email { get; set; }
        public List<OutNotificationSettingViewModel> Web { get; set; }
    }

    public class OutNotificationSettingViewModel
    {
        public int TargetTypeId { get; set; }
        public string TargetTypeName { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public bool IsEnabled { get; set; }

    }
}
