using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AskMe.Models
{
  // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
  public class User : IdentityUser
  {
    public static object Identity { get; internal set; }

    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
    {
      // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
      var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
      // Add custom user claims here
      return userIdentity;
    }
  }
  public class Post
  {
    public Post()
    {
      Votes = new HashSet<Votes>();
    }
    public int PostId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(MAX)")]
    public string Content { get; set; }
    public string Title { get; set; }
    public DateTime CreatedTime { get; set; }
    [Required]
    public string CreatedById { get; set; }
    public virtual User CreatedBy { get; set; }
    public int Views { get; set; }
    public virtual ICollection<Votes> Votes { get; set; }
  }

  public class Question
  {
    public Question()
    {
      Answers = new HashSet<Answer>();
      Tags = new HashSet<Tag>();
    }
    [Key, ForeignKey("Post")]
    public int PostId { get; set; }
    public virtual Post Post { get; set; }
    public virtual ICollection<Answer> Answers { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }
  }
  public class Tag
  {
    public Tag()
    {
      Questions = new HashSet<Question>();
    }
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public virtual ICollection<Question> Questions { get; set; }
  }
  public class Answer
  {
    public Answer()
    {
      Comments = new HashSet<Comment>();
    }
    [Key, ForeignKey("Post")]
    public int PostId { get; set; }
    public virtual Post Post { get; set; }
    [Required]
    [ForeignKey("Question")]
    public int QuestionId { get; set; }
    public virtual Question Question { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
  }
  public class Comment
  {
    public int Id { get; set; }
    [Required]
    public string CommentText { get; set; }
    [ForeignKey("Answer")]
    public int AnswerId { get; set; }
    public Answer Answer { get; set; }
  }
  public class Votes
  {
    public int Id { get; set; }
    [Required]
    public DateTime VotedDateTime { get; set; }
    [Required]
    public string UserId { get; set; }
    public virtual User User { get; set; }
    [Required]
    public int PostId { get; set; }
    public virtual Post Post { get; set; }
  }

  public class ApplicationDbContext : IdentityDbContext<User>
  {
    public DbSet<Post> Posts { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Votes> Votes { get; set; }
    public DbSet<Comment> Comments { get; set; }
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