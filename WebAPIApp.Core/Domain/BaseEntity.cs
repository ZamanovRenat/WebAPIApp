using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPIApp.Core.Domain
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }    
    }
}
