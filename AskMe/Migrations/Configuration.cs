namespace AskMe.Migrations
{
  using AskMe.Helper;
  using AskMe.Models;
  using Microsoft.AspNet.Identity;
  using Microsoft.AspNet.Identity.EntityFramework;
  using System.Data.Entity.Migrations;

  internal sealed class Configuration : DbMigrationsConfiguration<AskMe.Models.ApplicationDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(AskMe.Models.ApplicationDbContext context)
    {

      //  This method will be called after migrating to the latest version.

      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data.

      SeedingHelper seedingHelper = new SeedingHelper(context);
      var userManager = new UserManager<User>(new UserStore<User>(context));
      var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
      //Add role
      //var roles = new string[] { "Admin", "User" };
      //seedingHelper.CreatRoles(roles);

      //Add user
      seedingHelper.CreateUser("User1");
      seedingHelper.CreateUser("User2");
      seedingHelper.CreateUser("User3");

      //Add Tags
      seedingHelper.CreateTags();

      //Add Question
      seedingHelper.AddQuestions();


    }
  }
}
