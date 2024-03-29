﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nivello.Lib.Nivello.Application;
using Strider.Domain.Commands.Post.Commands;
using Strider.Domain.Queries.Post.Queries;
using System;
using System.Threading.Tasks;

namespace Strider.Api.Controllers
{
    [Route("api/v1/post")]
    [ApiController]
    public class PostController : ControllerBaseAPI
    {
        public IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePostCommand command) 
            => ReturnCommandApi(await _mediator.Send(command));
        
        [HttpPost]
        [Route("repost")]
        public async Task<IActionResult> RePost([FromBody] CreateRepostCommand command) 
            => ReturnCommandApi(await _mediator.Send(command));

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string text, [FromQuery] int page) 
            => ReturnQueryApi(await _mediator.Send(new GetAllPostsQuery(text, page, 10)));
        
        [HttpGet]
        [Route("following/{userId}")]
        public async Task<IActionResult> GetAll(Guid userId, [FromQuery] string text, [FromQuery] int page) 
            => ReturnQueryApi(await _mediator.Send(new GetAllPostsOnlyFollowingQuery(userId, text, page, 10)));
    }
}
