﻿using Strider.Domain.Queries.Contracts;
using Strider.Domain.Queries.Users.Queries;
using Strider.Infra.Data.Repository.UserRepository;
using System.Threading;
using System.Threading.Tasks;

namespace Strider.Domain.Queries.Users.QueryHandlers
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<QueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FirstOrDefaultAsync(UserQueries.GetById(request.Id));
            return new QueryResult(true, user);
        }
    }
}
