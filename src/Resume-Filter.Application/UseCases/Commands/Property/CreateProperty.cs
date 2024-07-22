using MediatR;

namespace Resume_Filter.Application.UseCases.Commands.Property;

public class CreateProperty:IRequest<bool>
{
    public int VacancyId { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }

}

