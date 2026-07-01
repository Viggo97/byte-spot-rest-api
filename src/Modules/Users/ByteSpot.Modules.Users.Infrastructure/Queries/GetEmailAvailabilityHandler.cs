using ByteSpot.Modules.Users.Application.Queries;
using ByteSpot.Modules.Users.Domain.Repositories;
using ByteSpot.Shared.Abstractions.Queries;

namespace ByteSpot.Modules.Users.Infrastructure.Queries;

public class GetEmailAvailabilityHandler : IQueryHandler<GetEmailAvailabilityQuery, bool>
{
    private readonly IUserRepository _userRepository;

    public GetEmailAvailabilityHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<bool> HandleAsync(GetEmailAvailabilityQuery query)
    {
        return _userRepository.IsEmailAvailableAsync(query.Email);
    }
}