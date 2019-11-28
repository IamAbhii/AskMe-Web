using AskMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskMe.DTO
{
    public class QuestionDto
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}