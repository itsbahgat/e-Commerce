using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Areas.Identity.Data;

// Add profile data for application users by adding properties to the E_CommerceUser class
public class E_CommerceUser : IdentityUser
{

    [Required , MaxLength(50)]
    public string FirstName { get; set; }

    [Required , MaxLength(50)]
    public string LastName { get; set; }

    [Phone]
    [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Please enter a valid phone number.")]
    public int PhoneNumber { get; set; }

    public string Address { get; set; }

}

