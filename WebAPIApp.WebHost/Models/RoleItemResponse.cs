﻿using System;

namespace WebAPIApp.WebHost.Models
{
    public class RoleItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
