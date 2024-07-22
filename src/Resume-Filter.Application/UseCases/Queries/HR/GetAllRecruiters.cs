using MediatR;
using Resume_Filter.Domain.Entities.HR;

namespace Resume_Filter.Application.UseCases.Queries.HR;

public class GetAllRecruiters:IRequest<List<Recruiter>>
{

}

