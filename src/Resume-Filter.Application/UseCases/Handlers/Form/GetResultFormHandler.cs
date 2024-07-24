using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.DTO.Form;
using Resume_Filter.Application.Helpers;
using Resume_Filter.Application.UseCases.Queries.Form;
using Resume_Filter.Domain.Entities.Form;

namespace Resume_Filter.Application.UseCases.Handlers.Form;

public class GetResultFormHandler:IRequestHandler<GetFormsById, string>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetResultFormHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<string> Handle(GetFormsById request, CancellationToken cancellationToken)
    {
        Forms form = await _applicationDbContext.Forms.FirstOrDefaultAsync(form=>form.Id == request.Id);
        if (form is null)
            throw new Exception("Form not found with this ID");

        string resume = FileHelper.ExtractTextFromPdf(form.Resume);
        var vacancy = await _applicationDbContext.Vacancies.FirstOrDefaultAsync(x => x.Id == form.VacancyId);

        string requestText = @$"
{resume}
//bir nimala chatgpt bizni modelga togri keladigan json qaytarish kere
{vacancy}
";
        string jsonfile = await GPTHelper.SendRequest(requestText);

        return jsonfile;    
    }

}