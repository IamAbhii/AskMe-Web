using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskMe.Models.ViewModel
{
    public class QuestionListViewModel
    {
        public List<Question> Questions { get; set; }
        public List<Tag> Tags { get; set; }
        public int[] TagsId { get; set; }
        public string CurrentUserId { get; set; }
    }
}