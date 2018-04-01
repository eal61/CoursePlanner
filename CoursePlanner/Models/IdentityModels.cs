using System.Data.Entity;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System;
namespace App.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetFirstName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("firstName");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetLastName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("lastName");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetFullName(this IIdentity identity)
        {
            return GetFirstName(identity) + " " + GetLastName(identity);
        }
        public static int GetStudentId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("studentId");
            // Test for null to avoid issues during local testing
            return (claim != null) ? int.Parse(claim.Value) : -1;
        }
    }
}
namespace CoursePlanner.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Hometown { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("firstName", this.firstName.ToString()));
            userIdentity.AddClaim(new Claim("lastName", this.lastName.ToString()));
            userIdentity.AddClaim(new Claim("studentId", this.studentId.ToString(), "Integer"));

            return userIdentity;
        }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string major { get; set; }
        public int studentId { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    
}