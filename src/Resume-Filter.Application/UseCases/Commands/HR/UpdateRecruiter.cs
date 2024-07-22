using MediatR;

namespace Resume_Filter.Application.UseCases.Commands.HR;

public class UpdateRecruiter:IRequest<bool>
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
}

