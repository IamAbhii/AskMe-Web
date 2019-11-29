using AskMe.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Http;

namespace AskMe.API
{
    [Authorize]
    public class VotesController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult UpVote(int id)
        {
            var user = _context.Users.Find(User.Identity.GetUserId());
            var post = _context.Posts.Find(id);
            var upVotes = post.UpVotes.ToList();
            var downVotes = post.DownVotes.ToList();

            if (upVotes.FindAll(u => u.UserId == user.Id).Count == 0)
            {
                if (downVotes.Select(u => u.UserId).Contains(user.Id))
                {
                    var downVote = _context.DownVotes.Where(u => u.UserId == user.Id).FirstOrDefault();
                    _context.DownVotes.Remove(downVote);
                    _context.SaveChanges();
                }
                UpVotes upVote = new UpVotes
                {
                    VotedDateTime = DateTime.Now,
                    UserId = user.Id,
                    User = user,
                    Post = post,
                    PostId = id,
                };
                post.UpVotes.Add(upVote);
                _context.SaveChanges();
                return Ok();                
            }
            return BadRequest();
        }

        public IHttpActionResult DownVote(int id)
        {

            var user = _context.Users.Find(User.Identity.GetUserId());
            var post = _context.Posts.Find(id);
            var downVotes = post.DownVotes.ToList();
            var upVotes = post.UpVotes.ToList();

            if (downVotes.FindAll(u => u.UserId == user.Id).Count == 0)
            {
                if (upVotes.Select(u => u.UserId).Contains(user.Id))
                {
                    var upVote = _context.UpVotes.Where(u => u.UserId == user.Id).FirstOrDefault();
                    _context.UpVotes.Remove(upVote);
                }
                DownVotes downVote = new DownVotes
                {
                    VotedDateTime = DateTime.Now,
                    UserId = user.Id,
                    User = user,
                    Post = post,
                    PostId = id,
                };
                post.DownVotes.Add(downVote);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
