﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Tests.Dal.Models
{
    public partial class User
    {
        public User()
        {
            Notifications = new HashSet<Notification>();
            Orders = new HashSet<Order>();
            Positions = new HashSet<Position>();
            Quizzes = new HashSet<Quiz>();
            Subscriptions = new HashSet<Subscription>();
            UserEmployees = new HashSet<UserEmployee>();
            UserNotificationSettings = new HashSet<UserNotificationSetting>();
            Vacancies = new HashSet<Vacancy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int? AvatarId { get; set; }

        public virtual Avatar Avatar { get; set; }
        public virtual Role Role { get; set; }
        public virtual UserSecurity UserSecurity { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<UserEmployee> UserEmployees { get; set; }
        public virtual ICollection<UserNotificationSetting> UserNotificationSettings { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
