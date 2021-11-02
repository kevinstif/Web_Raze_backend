using System;
using Raze.Api.Domain.Models;
using Raze.Api.Resources.CommentResources;

namespace Raze.Api.Domain.Services.Comunications
{
    public class CommentsResponse:BaseResponse<Comment>
    {
        public CommentsResponse(Comment comment):base(comment){}
        public CommentsResponse(string message):base(message){}
    }
}