using System;
using Raze.Api.Domain.Models;

namespace Raze.Api.Domain.Services.Comunications
{
    public class CommentsResponse:BaseResponse
    {
        public Comment Comment { get; private set; }
        public CommentsResponse(bool success, string message, Comment comment) : base(success, message)
        {
            Comment = comment;
        }
        
        public CommentsResponse(Comment comment):this(true,string.Empty, comment){}
        public CommentsResponse(string message):this(false,message,null){}
    }
}