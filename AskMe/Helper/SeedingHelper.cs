using AskMe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AskMe.Helper
{
  public class SeedingHelper
  {
    UserManager<User> userManager;
    RoleManager<IdentityRole> roleManager;
    ApplicationDbContext context;
    public SeedingHelper(ApplicationDbContext context)
    {
      this.context = context;
      userManager = new UserManager<User>(new UserStore<User>(context));
      roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
    }

    public void CreateUser(string name)
    {
      string userName = name + "@AskMe.com";
      string password = name + "A123";

      var userInDb = userManager.FindByName(userName);
      if (userInDb != null) return;
      var PasswordHash = new PasswordHasher();
      var user = new User()
      {
        UserName = userName,
        Email = userName,
        PasswordHash = PasswordHash.HashPassword(password),
      };
      userManager.Create(user);
    }
    public void CreateTags()
    {
      List<Tag> tags = new List<Tag>()
      {
        new Tag() {Name="C#"},
        new Tag() {Name="Asp.net"},
        new Tag() {Name="Sql"},
        new Tag() {Name="Css"},
        new Tag() {Name="Html"},
        new Tag() {Name="Js"},
      };
      foreach (var tag in tags)
      {
        var isExist = context.Tags.Any(t => t.Name == tag.Name);
        if (!isExist)
        {
          context.Tags.Add(tag);
        }
      }
    }

    public void AddQuestions()
    {
      Post post = new Post()
      {
        Content = "<h1>I know you can answer this question?</h1>",
        Title = "Question",
        CreatedTime = DateTime.Now,
        CreatedBy = context.Users.Where(user => user.UserName == "User1@AskMe.com").FirstOrDefault()
      };

      Question question = new Question()
      {
        Post = post,
        Tags = context.Tags.Take(2).ToList(),
      };
      context.Posts.Add(post);
      context.SaveChanges();
      context.Questions.Add(question);
      context.SaveChanges();
    }
  }
}