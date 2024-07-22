using MediatR;

namespace Resume_Filter.Application.UseCases.Commands.Property;

public class DeleteProperty:IRequest<bool>
{
    public int Id { get; set; }
}

