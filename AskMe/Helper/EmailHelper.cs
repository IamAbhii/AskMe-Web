using AskMe.Models;
using AskMe.Models.ViewModel;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AskMe.Helper
{
  public class EmailHelper
  {
    ApplicationDbContext applicationDbContext = new ApplicationDbContext();

    public void notifyQuestionOwner(QuestionDetailViewModel viewModel)
    {
      var user = viewModel.Question.Post.CreatedBy;
      try
      {
        //this method will work only if you provided correct email 
        //for security perpose we are removing credentials from here.
        var senderEmail = new MailAddress("sender@gmail.com", "senderPassword");
        var receiverEmail = new MailAddress(user.Email, "Receiver");
        var password = "Enter your password here.";
        var sub = "MITT job notification";
        var body = GetBody(viewModel);
        var smtp = new SmtpClient
        {
          Host = "smtp.gmail.com",
          Port = 587,
          EnableSsl = true,
          DeliveryMethod = SmtpDeliveryMethod.Network,
          UseDefaultCredentials = false,
          Credentials = new NetworkCredential(senderEmail.Address, password)
        };
        var mess = new MailMessage(senderEmail, receiverEmail)
        {
          Subject = sub,
          Body = body,
        };
        mess.IsBodyHtml = true;
        smtp.Send(mess);
      }
      catch (Exception e)
      {

      }
    }
    public string GetBody(QuestionDetailViewModel viewModel)
    {
      StringBuilder htmlBuilder = new StringBuilder();
      var hr = "<hr />";
      var div = "<div style=\"width: 100 %; border: 1px solid orange; padding: 5px; \">";
      htmlBuilder.Append(div);
      var questionHeader = "<h1>" + "Congrats someone answered question." + "</h1>";
      htmlBuilder.Append(questionHeader);
      htmlBuilder.Append(hr);
      div = "</div>";
      htmlBuilder.Append(div);
      return htmlBuilder.ToString();
    }
  }
}