using AskMe.DTO;
using AskMe.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskMe.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Domain to dto
            Mapper.CreateMap<Question, QuestionDto>();

            //Dto To domain
            Mapper.CreateMap<QuestionDto,Question>()
                .ForMember(q=>q.PostId,opt=>opt.Ignore());
        }
    }
}