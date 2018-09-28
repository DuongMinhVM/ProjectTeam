using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}