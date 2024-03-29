﻿using Strider.Domain.Queries.Post.Queries;
using Strider.Infrastructure.Data.Repository.PostRepository;
using Strider.Lib.Strider.Lib.Domain.Queries;
using Strider.Lib.Strider.Lib.Domain.Queries.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Strider.Domain.Queries.Post.QueryHandlers
{
    public class GetUserLastPostsQueryHandler : IQueryHandler<GetUserLastPostsQuery>
    {
        private readonly IPostRepository _postRepository;

        public GetUserLastPostsQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<QueryResult> Handle(GetUserLastPostsQuery request, CancellationToken cancellationToken)
        {
            var response = await _postRepository.WhereAsync(PostQueries.GetUserLastPost(request.UserId), request.Page, request.PageSize);
            return new QueryResult(true, response);
        }
    }
}
