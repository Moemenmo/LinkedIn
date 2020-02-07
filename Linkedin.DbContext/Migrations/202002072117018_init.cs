namespace Linkedin.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Award",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Issuer = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Country = c.Int(nullable: false),
                        Address = c.String(),
                        About = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        HeadLine = c.String(),
                        Gender = c.Int(nullable: false),
                        Indstry = c.Int(nullable: false),
                        ProfilePicURL = c.String(),
                        CoverPicURL = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Comment_Id = c.Guid(),
                        Post_Id = c.Guid(),
                        Patent_Id = c.Guid(),
                        Project_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comment", t => t.Comment_Id)
                .ForeignKey("dbo.Post", t => t.Post_Id)
                .ForeignKey("dbo.Patent", t => t.Patent_Id)
                .ForeignKey("dbo.Project", t => t.Project_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Comment_Id)
                .Index(t => t.Post_Id)
                .Index(t => t.Patent_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Number = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.EducationExperience",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Grade = c.String(),
                        Degree = c.Int(nullable: false),
                        Description = c.String(),
                        Activites = c.String(),
                        StartYear = c.DateTime(nullable: false),
                        EndYear = c.DateTime(nullable: false),
                        SchoolId = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SavedPlace", t => t.SchoolId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.SchoolId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SavedPlace",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        PlaceType = c.Int(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VolunteerExperience",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Cause = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SavedPlace", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WorkExperience",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Location = c.String(),
                        Headline = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsPresent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SavedPlace", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Level = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Status = c.String(),
                        ImageUrl = c.String(),
                        AuthorId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id1)
                .Index(t => t.AuthorId)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id1);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(),
                        PicURL = c.String(),
                        AuthorId = c.String(nullable: false, maxLength: 128),
                        Comment_Id = c.Guid(),
                        Post_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Comment", t => t.Comment_Id)
                .ForeignKey("dbo.Post", t => t.Post_Id)
                .Index(t => t.AuthorId)
                .Index(t => t.Comment_Id)
                .Index(t => t.Post_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Patent",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Office = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Url = c.String(),
                        Issued = c.Boolean(nullable: false),
                        Description = c.String(),
                        CreatorId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.CreatorId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        URL = c.String(),
                        Description = c.String(),
                        CreatorId = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.CreatorId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Publication",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PublisherId = c.Guid(nullable: false),
                        Url = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SavedPlace", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestScore",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Score = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ApplicationUserApplicationUsers",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id1 = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.ApplicationUser_Id1 })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id1)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id1);
            
            CreateTable(
                "dbo.PublicationApplicationUsers",
                c => new
                    {
                        Publication_Id = c.Guid(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Publication_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Publication", t => t.Publication_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Publication_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.SkillApplicationUsers",
                c => new
                    {
                        Skill_Id = c.Guid(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Skill_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Skill", t => t.Skill_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Skill_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Award", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestScore", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SkillApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SkillApplicationUsers", "Skill_Id", "dbo.Skill");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Publication", "PublisherId", "dbo.SavedPlace");
            DropForeignKey("dbo.PublicationApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PublicationApplicationUsers", "Publication_Id", "dbo.Publication");
            DropForeignKey("dbo.Project", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Project");
            DropForeignKey("dbo.Project", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Post", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Patent", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Patent_Id", "dbo.Patent");
            DropForeignKey("dbo.Patent", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Post", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Post_Id", "dbo.Post");
            DropForeignKey("dbo.Comment", "Post_Id", "dbo.Post");
            DropForeignKey("dbo.Comment", "Comment_Id", "dbo.Comment");
            DropForeignKey("dbo.AspNetUsers", "Comment_Id", "dbo.Comment");
            DropForeignKey("dbo.Comment", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Post", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Languages", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EducationExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EducationExperience", "SchoolId", "dbo.SavedPlace");
            DropForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkExperience", "CompanyId", "dbo.SavedPlace");
            DropForeignKey("dbo.VolunteerExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.VolunteerExperience", "CompanyId", "dbo.SavedPlace");
            DropForeignKey("dbo.Course", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.SkillApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SkillApplicationUsers", new[] { "Skill_Id" });
            DropIndex("dbo.PublicationApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.PublicationApplicationUsers", new[] { "Publication_Id" });
            DropIndex("dbo.ApplicationUserApplicationUsers", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.ApplicationUserApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.TestScore", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Publication", new[] { "PublisherId" });
            DropIndex("dbo.Project", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Project", new[] { "CreatorId" });
            DropIndex("dbo.Patent", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Patent", new[] { "CreatorId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Comment", new[] { "Post_Id" });
            DropIndex("dbo.Comment", new[] { "Comment_Id" });
            DropIndex("dbo.Comment", new[] { "AuthorId" });
            DropIndex("dbo.Post", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Post", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Post", new[] { "AuthorId" });
            DropIndex("dbo.Languages", new[] { "UserId" });
            DropIndex("dbo.WorkExperience", new[] { "UserId" });
            DropIndex("dbo.WorkExperience", new[] { "CompanyId" });
            DropIndex("dbo.VolunteerExperience", new[] { "UserId" });
            DropIndex("dbo.VolunteerExperience", new[] { "CompanyId" });
            DropIndex("dbo.EducationExperience", new[] { "UserId" });
            DropIndex("dbo.EducationExperience", new[] { "SchoolId" });
            DropIndex("dbo.Course", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Project_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Patent_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Post_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Comment_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Award", new[] { "UserId" });
            DropTable("dbo.SkillApplicationUsers");
            DropTable("dbo.PublicationApplicationUsers");
            DropTable("dbo.ApplicationUserApplicationUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TestScore");
            DropTable("dbo.Skill");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Publication");
            DropTable("dbo.Project");
            DropTable("dbo.Patent");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Comment");
            DropTable("dbo.Post");
            DropTable("dbo.Languages");
            DropTable("dbo.WorkExperience");
            DropTable("dbo.VolunteerExperience");
            DropTable("dbo.SavedPlace");
            DropTable("dbo.EducationExperience");
            DropTable("dbo.Course");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Award");
        }
    }
}
