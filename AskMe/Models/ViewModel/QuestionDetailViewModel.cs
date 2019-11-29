using System.ComponentModel.DataAnnotations;

namespace AskMe.Models.ViewModel
{
    public class QuestionDetailViewModel
    {
        ApplicationDbContext _context = new ApplicationDbContext();
 
        public virtual Question question { get; set; }
        [Display(Name = "Add your answer.")]
        public string AnswerContent { get; set; }
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int VoteCount { get; set; }
    }
}