﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Strider.Domain.Commands.Post.Commands;
using System.Threading.Tasks;

namespace Strider.Api.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePostCommand command)
        {
            var result = _mediator.Send(command);
            return Ok(result);
        }
    }
}