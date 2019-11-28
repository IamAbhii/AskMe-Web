using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AskMe.Models.ViewModel
{
  public class QuestionCreateViewModel
  {
    public string Content { get; set; }
    public string Title { get; set; }
    public List<Tag> Tags { get; set; }
    [Display(Name = "Select Tags")]
    public int[] TagsId { get; set; }
    public string UserId { get; set; }

  }
}