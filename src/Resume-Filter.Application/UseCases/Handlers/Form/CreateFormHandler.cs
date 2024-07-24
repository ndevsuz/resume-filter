using AutoMapper;
using MediatR;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Commands.Form;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
            string imageFilePath = "";
            if(request.Resume != null)
            {
                string UploadFolder = Path.Combine(PathHelper.WebRootPath, "files");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + request.Resume.FileName;
                imageFilePath = Path.Combine(UploadFolder, uniqueFileName);
                request.Resume.CopyTo(new FileStream(imageFilePath, FileMode.Create));
                form.Resume = imageFilePath;
            }

            var gptrequest = @$"
I have the following resume text and vacancy requirements. Please analyze the resume against the vacancy requirements and return a JSON object with the matching skills, match percentage, and whether the user is accepted or not.

**Resume:**
{FileHelper.ExtractTextFromPdf(imageFilePath)}

**Vacancy:**
{JsonConvert.SerializeObject(await _applicationDbContext.Vacancies.FirstOrDefaultAsync(v => v.Id == form.VacancyId))}

Return the result as a JSON object with the following structure(if no info property can be null(id, fullname, email, resume others cant be null)):
" + @"
```json
{
  ""Id"":""1""
  ""FullName"": ""John Doe"",
  ""Email"": ""john.doe@example.com"",
  ""VacancyId"": 123,
  ""Resume"": ""[Insert resume text here]"",
  ""Match"": 75, // Percentage match
  ""MatchingSkills"": ""skill1, skill2, skill3"",
  ""IsAccepted"": true // or false
}
";
            var gptForm = JsonConvert.DeserializeObject<Forms>(await GPTHelper.SendRequest(gptrequest));
            form.Match = gptForm.Match;
            form.MatchingSkills = "gptForm.MatchingSkills";
            form.IsAccepted = gptForm.IsAccepted;
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

