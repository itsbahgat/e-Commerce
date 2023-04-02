﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Areas.FavouriteList.Models;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Areas.Identity.Data;

// Add profile data for application users by adding properties to the E_CommerceUser class
public class E_CommerceUser : IdentityUser
{

    [Required , MaxLength(50)]
    public string FirstName { get; set; }

    [Required , MaxLength(50)]
    public string LastName { get; set; }

    
    [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Please enter a valid phone number.")]
    [AllowNull]
    public string? PhoneNumber { get; set; }

    public string Address { get; set; }

    // For M:M relationship
    //ICollection<Product>? Products { get; set; }
    public virtual ICollection<FavouriteItems>? FavouriteItems { get; set; }

    //// Navigation properties for the CartItems class

    //public virtual ICollection<FavouriteItems>? CartItems { get; set; }

    //// Navigation properties for the PreviousPurchases class
    //public virtual ICollection<FavouriteItems>? PreviousPurchases { get; set; }

}

