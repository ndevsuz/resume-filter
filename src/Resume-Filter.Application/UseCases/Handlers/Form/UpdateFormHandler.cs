using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Commands.Form;

namespace Resume_Filter.Application.UseCases.Handlers.Form;

public class UpdateFormHandler : IRequestHandler<UpdateForm, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateFormHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(UpdateForm request, CancellationToken cancellationToken)
    {
        try
        {
            var form = await _applicationDbContext.Forms.FirstOrDefaultAsync(form=>form.Id==request.Id);

            if (form is null)
                return false;

            form.FullName = request.FullName ?? form.FullName;
            form.Email = request.Email ?? form.Email;
            form.VacancyId = request.VacancyId ?? form.VacancyId;
            form.Resume = request.Resume ?? form.Resume;

            _applicationDbContext.Forms.Update(form);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

