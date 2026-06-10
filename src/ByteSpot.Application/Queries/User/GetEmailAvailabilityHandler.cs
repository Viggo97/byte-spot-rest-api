using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.User;

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