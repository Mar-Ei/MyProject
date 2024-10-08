﻿using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class UserSetting
    {
        public int SettingId { get; set; }
        public int? UserId { get; set; }
        public string? Language { get; set; }
        public string? TimeZone { get; set; }
        public string? NotificationPreference { get; set; }

        public virtual User? User { get; set; }
    }
}
