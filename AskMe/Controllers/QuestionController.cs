using AskMe.BusinessLayer;
using AskMe.Helper;
using AskMe.Models.ViewModel;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace AskMe.Controllers
{
  [Authorize]
  public class QuestionController : Controller
  {
    QuestionBusinessLayer QBL = new QuestionBusinessLayer();
    EmailHelper emailHelper = new EmailHelper();
    // GET: Question
    public ActionResult Index()
    {
      QuestionListViewModel questionListViewModel = new QuestionListViewModel
      {
        Questions = QBL.GetAllQuestions(),
        Tags = QBL.GetAllTags(),
        CurrentUserId = User.Identity.GetUserId(),
      };

      return View(questionListViewModel);
    }

    [HttpPost]
    public ActionResult Index(QuestionListViewModel questionListViewModel)
    {
      if (questionListViewModel.TagsId == null)
        return RedirectToAction("Index");

      var tagsId = questionListViewModel.TagsId;
      var questions = QBL.GetQuestionsBySelectedTags(tagsId);
      QuestionListViewModel questionListByTag = new QuestionListViewModel
      {
        Questions = questions,
        Tags = QBL.GetAllTags(),
        CurrentUserId = User.Identity.GetUserId(),
      };
      return View(questionListByTag);
    }


    public ActionResult CreateQuestion()
    {
      QuestionCreateViewModel viewModel = new QuestionCreateViewModel()
      {
        Tags = QBL.GetAllTags(),
        UserId = User.Identity.GetUserId(),
      };
      return View(viewModel);
    }
    [HttpPost]
    [ValidateInput(false)]
    public ActionResult CreateQuestion(QuestionCreateViewModel questionViewModel)
    {
      QBL.CreateQuestion(questionViewModel);
      return RedirectToAction("Index");
    }

    public ActionResult QuestionDetails(int Id)
    {
      QuestionDetailViewModel questionDetailViewModel = new QuestionDetailViewModel
      {
        Question = QBL.GetQuestions(Id),
        UserId = User.Identity.GetUserId(),
        QuestionId = Id,
      };
      return View(questionDetailViewModel);
    }
    [HttpPost]
    [ValidateInput(false)]
    public ActionResult QuestionDetails(QuestionDetailViewModel questionDetailViewModel)
    {
      QBL.CreateAnswer(questionDetailViewModel);
      emailHelper.notifyQuestionOwner(questionDetailViewModel);
      return RedirectToAction("QuestionDetails", new { Id = questionDetailViewModel.QuestionId });
    }
  }
}