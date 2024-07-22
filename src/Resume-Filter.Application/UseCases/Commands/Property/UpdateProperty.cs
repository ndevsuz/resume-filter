using MediatR;

namespace Resume_Filter.Application.UseCases.Commands.Property;

public class UpdateProperty:IRequest<bool>
{
    public int Id { get; set; }
    public int? VacancyId { get; set; }
    public string? Name { get; set; }
    public int? Value { get; set; }

}

