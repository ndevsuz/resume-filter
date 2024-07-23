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

            string uniqueFileName = string.Empty;

            if(request.Resume != null)
            {
                string UploadFolder = Path.Combine(PathHelper.WebRootPath, "files");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + request.Resume.FileName;
                string imageFilePath = Path.Combine(UploadFolder, uniqueFileName);
                request.Resume.CopyTo(new FileStream(imageFilePath, FileMode.Create));
                form.Resume = "images/" + uniqueFileName;
            }

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

