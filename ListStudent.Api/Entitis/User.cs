using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;

namespace PhongKhamNhaKhoa.Api.Entitis
{
    public class User : IdentityUser<Guid>
    {
        [MaxLength(250)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(250)]
        [Required]
        public string LastName { get; set; }
    }
}
