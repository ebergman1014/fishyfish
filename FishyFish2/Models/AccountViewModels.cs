using FishyFish2.DAL;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace FishyFish2.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.CompareAttribute("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel : Person
    {
        override public string UserName
        {
            get
            {
                var name = Name;
                name = Regex.Replace(name, @"\s", "");
                return name;
            }
            set
            {
                var name = Name;
                name = Regex.Replace(name, @"\s", "");
                value = name;
            }
        }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.CompareAttribute("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public Person GetPerson()
        {
            Person p = new Person()
            {
                Email = this.Email,
                Name = this.Name,
                Dob = this.Dob,
                PhoneNumber = this.PhoneNumber,
                SignupDate = DateTime.Now,
                UserName = this.UserName,
                TshirtSize = this.TshirtSize,
                Affiliation = this.Affiliation,
                PaymentMethod = this.PaymentMethod,
            };
            return p;
        }
    }

    public class EditUserViewModel : Person {
        public EditUserViewModel(Person p)
        {
                this.Affiliation = p.Affiliation;
                this.Dob = Dob;
                this.Name = Name;
                this.PaymentMethod = PaymentMethod;
                this.PhoneNumber = PhoneNumber;
                this.TshirtSize = TshirtSize;
                this.SignupDate = SignupDate;
        }

    }

    public class SelectUserRolesViewModel : Person
    {
        public SelectUserRolesViewModel()
        {
            this.Roles = new List<SelectRoleEditorViewModel>();
        }


        // Enable initialization with an instance of ApplicationUser:
        public SelectUserRolesViewModel(Person p)
            : this()
        {
            this.Affiliation = p.Affiliation;
            this.Dob = Dob;
            this.Name = Name;
            this.PaymentMethod = PaymentMethod;
            this.PhoneNumber = PhoneNumber;
            this.TshirtSize = TshirtSize;
            this.SignupDate = SignupDate;

            var Db = new FishContext();

            // Add all available roles to the list of EditorViewModels:
            var allRoles = Db.Roles;
            foreach (var role in allRoles)
            {
                // An EditorViewModel will be used by Editor Template:
                var rvm = new SelectRoleEditorViewModel(role);
                this.Roles.Add(rvm);
            }

            // Set the Selected property to true for those roles for 
            // which the current user is a member:
            foreach (var userRole in p.Roles)
            {
                var checkUserRole =
                    this.Roles.Find(r => r.RoleName == userRole.Role.Name);
                checkUserRole.Selected = true;
            }
        }

        public List<SelectRoleEditorViewModel> Roles { get; set; }
    }

    // Used to display a single role with a checkbox, within a list structure:
    public class SelectRoleEditorViewModel
    {
        public SelectRoleEditorViewModel() { }
        public SelectRoleEditorViewModel(IdentityRole role)
        {
            this.RoleName = role.Name;
        }

        public bool Selected { get; set; }

        [Required]
        public string RoleName { get; set; }
    }

}
