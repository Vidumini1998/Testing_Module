namespace PMSWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [UserLevel], [FirstName], [LastName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [CompanyName], [CompanyAddress], [ContactNo], [Comment], [Image], [HomeContactNo], [Nic], [Discriminator]) VALUES (N'11cc7040-3cd7-44e1-a92c-ed230cae1f37', NULL, NULL, NULL, N'client@pms.com', 0, N'AKlUgr0WgfvZjmYV1woxqcm8aWAyut2oaBuQpQ4vRZMaaBGsoq0XGfNz2woZn9XqUA==', N'fb35984a-2946-4fcc-a167-4661b2b65f64', NULL, 0, 0, NULL, 1, 0, N'client@pms.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'ApplicationUser')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [UserLevel], [FirstName], [LastName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [CompanyName], [CompanyAddress], [ContactNo], [Comment], [Image], [HomeContactNo], [Nic], [Discriminator]) VALUES (N'17ade93f-cd40-4fad-9890-35fb74b39dfb', NULL, NULL, NULL, N'admin@pms.com', 0, N'ANrtgVR2D0Qx+l4jObbuACir/E8q8zFwAh3P7bE3IQZ5uilQv+Irk9EBbZufyfMT0Q==', N'8e8c908b-5f7c-40ef-9191-51db73e29e55', NULL, 0, 0, NULL, 1, 0, N'admin@pms.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'ApplicationUser')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [UserLevel], [FirstName], [LastName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [CompanyName], [CompanyAddress], [ContactNo], [Comment], [Image], [HomeContactNo], [Nic], [Discriminator]) VALUES (N'c513e3bb-aba3-48a4-80fa-b2306979c36a', NULL, NULL, NULL, N'employee@pms.com', 0, N'AOsrP++D7MIKuVcLmbYT9pDgukaJxcEFP2oz9JboCMoPK4UTpvOlDrqulKHk8RJCVQ==', N'7b3a2843-7853-4810-8bd3-4d1a7fb428d2', NULL, 0, 0, NULL, 1, 0, N'employee@pms.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'ApplicationUser')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'51b19268-bae7-4ad3-b0eb-c05ecf4909b0', N'Administrator')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5b192b36-36cb-47eb-8138-9e580907dcf8', N'Client')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'908735ff-0233-498f-95ee-bdf8fa336b1c', N'Employee')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'17ade93f-cd40-4fad-9890-35fb74b39dfb', N'51b19268-bae7-4ad3-b0eb-c05ecf4909b0')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'11cc7040-3cd7-44e1-a92c-ed230cae1f37', N'5b192b36-36cb-47eb-8138-9e580907dcf8')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c513e3bb-aba3-48a4-80fa-b2306979c36a', N'908735ff-0233-498f-95ee-bdf8fa336b1c')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
