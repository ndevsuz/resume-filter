using AutoMapper;
using MediatR;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Commands.Vacancy;
using Resume_Filter.Domain.Entities.Vacancy;

namespace Resume_Filter.Application.UseCases.Handlers.Vacancy;

public class CreateVacancyHandler : IRequestHandler<CreateVacancy, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateVacancyHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }


    public async Task<bool> Handle(CreateVacancy request, CancellationToken cancellationToken)
    {
        try
        {
            Vacancies vacancy = _mapper.Map<Vacancies>(request);
            await _applicationDbContext.Vacancies.AddAsync(vacancy);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }

    }
}

