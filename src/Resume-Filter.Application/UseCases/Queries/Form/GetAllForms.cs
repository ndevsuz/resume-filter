using iTextSharp.text;
using MediatR;
using Resume_Filter.Domain.Entities.Form;

namespace Resume_Filter.Application.UseCases.Queries.Form;

public class GetAllForms:IRequest<List<Forms>>
{
    
}