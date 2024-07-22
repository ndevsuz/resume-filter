using MediatR;

namespace Resume_Filter.Application.UseCases.Commands.HR;

public class CreateRecruiter:IRequest<bool>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

