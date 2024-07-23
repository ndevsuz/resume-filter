using AutoMapper;
using MediatR;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Commands.Form;
using Microsoft.AspNetCore.Http;
using Resume_Filter.Application.Helpers;
using Resume_Filter.Domain.Entities.Form;

namespace Resume_Filter.Application.UseCases.Handlers.Form;

public class CreateFormHandler:IRequestHandler<CreateForm, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateFormHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateForm request, CancellationToken cancellationToken)
    {
        try
        {
            Forms form = new Forms
            {
                FullName=request.FullName,
                Email=request.Email,
                VacancyId=request.VacancyId
            };

            if(request.Resume != null)
            {
                string UploadFolder = Path.Combine(PathHelper.WebRootPath, "resumes");
            }
            //Forms form = _mapper.Map<Forms>(request);
            await _applicationDbContext.Forms.AddAsync(form);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

