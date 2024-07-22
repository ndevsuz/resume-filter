using MediatR;
using Resume_Filter.Domain.Entities.Property;

namespace Resume_Filter.Application.UseCases.Queries.Property;

public class GetAllPropertyQuery:IRequest<List<Properties>>
{

}

