using Linkedin.Entites.Enum;
using Linkedin.Models.Entites;
using Linkedin.Models.Enum;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Country Country { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public DateTime BirthDay { get; set; }
        public string HeadLine { get; set; }
        public Gender Gender{ get; set; }
        public Indstry Indstry { get; set; }
        public string ProfilePicURL { get; set; }
        public string CoverPicURL { get; set; }
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
        public virtual ICollection<Post> Posts{ get; set; }
        public virtual ICollection<Post> LikedPosts { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Award> Awards { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<EducationExperience> EducationExperiences { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<Patent> Patents { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
        public virtual ICollection<VolunteerExperience> VolunteerExperiences { get; set; }
        public virtual ICollection<TestScore> TestScores { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }


        public ApplicationUser()
        {
            WorkExperiences = new HashSet<WorkExperience>();
            Skills = new HashSet<Skill>();
            Posts = new HashSet<Post>();
            LikedPosts = new HashSet<Post>();
            Awards = new HashSet<Award>();
            VolunteerExperiences = new HashSet<VolunteerExperience>();
            Projects= new HashSet<Project>();
            Patents = new HashSet<Patent>();
            Languages = new HashSet<Language>();
            Courses = new HashSet<Course>();
            EducationExperiences= new HashSet<EducationExperience>();
            Publications = new HashSet<Publication>();
            TestScores= new HashSet<TestScore>();
            ApplicationUsers = new HashSet<ApplicationUser>();
        }














        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
