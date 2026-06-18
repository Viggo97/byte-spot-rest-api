using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Security;
using ByteSpot.Domain.Exceptions.User;
using ByteSpot.Domain.Repositories;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Application.Commands.Company;

public sealed class AddCompanyHandler : ICommandHandler<AddCompanyCommand>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IUserRepository _userRepository;

    public AddCompanyHandler(
        ICompanyRepository companyRepository,
        IPasswordManager passwordManager,
        IUserRepository userRepository
        )
    {
        _companyRepository = companyRepository;
        _passwordManager = passwordManager;
        _userRepository = userRepository;
    }
    
    public async Task HandleAsync(AddCompanyCommand command)
    {
        var email = new Email(command.Email);
        var password = new Password(command.Password);
        var role = Role.Employer();
        var firstName = new FirstName(command.UserFirstName);
        var lastName = new LastName(command.UserLastName);
        
        if (await _userRepository.GetByEmailAsync(email) is not null)
        {
            throw new EmailAlreadyInUseException(email);
        }
        
        var securedPassword = _passwordManager.Secure(password);
        
        var user = Domain.Entities.User.Create(Identifier.Create(), email, securedPassword, role, firstName, lastName,
            DateTimeOffset.UtcNow);
        
        var id = Identifier.Create(command.Id);
        var name = new Name(command.Name);
        var company = Domain.Entities.Company.Create(id, name);
        company.AddUsers([user]);
        
        await _userRepository.AddAsync(user);
        await _companyRepository.AddAsync(company);
    }
}