using MediatR;

namespace Resume_Filter.Application.UseCases.Commands.Form;

public class DeleteForm:IRequest<bool>
{
    public int Id { get; set; }
}

