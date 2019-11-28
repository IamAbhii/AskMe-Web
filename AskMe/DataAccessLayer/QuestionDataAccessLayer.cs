using AskMe.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace AskMe.DataAccessLayer
{
    public class QuestionDataAccessLayer
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public List<Question> GetAllQuestions()
        {
            return _context.Questions.Include(q => q.Post).ToList();
        }

        public List<Tag> GetAllTags()
        {
            return _context.Tags.ToList();
        }
        public List<Tag> GetSelectedAllTags(int[] selectedId)
        {
            List<Tag> result = new List<Tag>();
            foreach (var id in selectedId)
            {
                var tag = _context.Tags.Find(id);
                result.Add(tag);
            }
            return result;
        }
        public bool isTagInQuestion(List<Question> questions,Tag tag)
        {
            foreach(var question in questions)
            {
                if (question.Tags.Contains(tag))
                {
                    return true;
                }
            }
            return false;
        }
        public List<Question> GetQuestionsBySelectedTags(int[] selectedId)
        {
            List<Tag> resultTags = new List<Tag>();
            foreach (var id in selectedId)
            {
                var tag = _context.Tags.Find(id);
                resultTags.Add(tag);
            }

            var questions = _context.Questions.ToList();
            List<Question> resultQuestions = new List<Question>();
            foreach (var tag in resultTags)
            {
                foreach(var question in questions )
                {
                    if (question.Tags.Contains(tag))
                    {
                        if(!resultQuestions.Contains(question))
                                resultQuestions.Add(question);
                    }
                }
               
            }
            return resultQuestions;
        }

        //public List<Question> GetAllQuestionBySelectedTag()
        //{

        //}

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            var id = post.PostId;
        }

        public void CreateQuestion(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }
        public void CreateAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        public Question GetQuestions(int id)
        {
            return _context.Questions.Find(id);
        }

    }
}