using MediatR;

namespace Resume_Filter.Application.UseCases.Commands.HR;

public class DeleteRecruiter:IRequest<bool>
{
    public int Id { get; set; }
}

