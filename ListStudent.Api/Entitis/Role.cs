using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PhongKhamNhaKhoa.Api.Entitis
{
    public class Role : IdentityRole<Guid>
    {
        [MaxLength(250)]
        [Required]
        public string Description { get; set; }
    }
}
