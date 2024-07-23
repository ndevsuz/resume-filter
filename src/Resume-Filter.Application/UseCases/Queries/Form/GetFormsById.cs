using MediatR;
using Resume_Filter.Domain.Entities.Form;

namespace Resume_Filter.Application.UseCases.Queries.Form;

public class GetFormsById:IRequest<Forms>
{
    public int Id { get; set; }
}