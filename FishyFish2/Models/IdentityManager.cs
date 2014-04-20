using Microsoft.AspNet.Identity.EntityFramework;
using FishyFish2.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace FishyFish2.DAL
{
    /// <summary>
    /// All the roles dawg
    /// </summary>

    public enum PersonRoles
    {
        Admin,
        User
    }
    public class IdentityManager
    {

        //public bool CreateRole(string name)
        //{
        //    var rm = new RoleManager<IdentityRole>(
        //        new RoleStore<IdentityRole>(new FishContext()));
        //    var idResult = rm.Create(new IdentityRole(name));
        //    return idResult.Succeeded;
        //}

        public bool AddUserToRole(string userId, PersonRoles roleName)
        {
            var um = new UserManager<Person>(
                new UserStore<Person>(new FishContext()));
            var idResult = um.AddToRole(userId, roleName.ToString());
            return idResult.Succeeded;
        }


        public void ClearUserRoles(string userId)
        {
            var um = new UserManager<Person>(
                new UserStore<Person>(new FishContext()));
            var user = um.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                um.RemoveFromRole(userId, role.Role.Name);
            }
        }
    }
}