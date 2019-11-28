using AskMe.DataAccessLayer;
using AskMe.Models;
using AskMe.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace AskMe.BusinessLayer
{
    public class QuestionBusinessLayer
    {
        QuestionDataAccessLayer QDL = new QuestionDataAccessLayer();

        public List<Question> GetAllQuestions()
        {
            return QDL.GetAllQuestions();
        }

        public List<Question> GetQuestionsBySelectedTags(int[] selectedId)
        {
            return QDL.GetQuestionsBySelectedTags(selectedId);
        }
        public List<Tag> GetAllTags()
        {
            return QDL.GetAllTags();
        }
        public List<Tag> GetSelectedAllTags(int[] selectedId)
        {

            return QDL.GetSelectedAllTags(selectedId);
        }

        public void CreateQuestion(QuestionCreateViewModel questionViewModel)
        {
            Post post = new Post()
            {
                Content = questionViewModel.Content,
                Title = questionViewModel.Title,
                CreatedTime = DateTime.Now,
                CreatedById = questionViewModel.UserId,
            };
            Question question = new Question()
            {

                Post = post,
                Tags = QDL.GetSelectedAllTags(questionViewModel.TagsId),
            };
            QDL.CreatePost(post);
            QDL.CreateQuestion(question);
        }
        public void CreateAnswer(QuestionDetailViewModel viewModel)
        {
            Post post = new Post()
            {
                Content = viewModel.AnswerContent,
                CreatedTime = DateTime.Now,
                CreatedById = viewModel.UserId,
            };
            Answer answer = new Answer()
            {
                Post = post,
                Question = GetQuestions(viewModel.QuestionId),
            };
            QDL.CreatePost(post);
            QDL.CreateAnswer(answer);
        }

        public Question GetQuestions(int id)
        {
            return QDL.GetQuestions(id);
        }
    }
}