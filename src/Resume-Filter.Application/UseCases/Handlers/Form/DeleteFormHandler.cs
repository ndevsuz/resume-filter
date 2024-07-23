using MediatR;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Application.UseCases.Commands.Form;
using Resume_Filter.Domain.Entities.Form;

namespace Resume_Filter.Application.UseCases.Handlers.Form;

public class DeleteFormHandler : IRequestHandler<DeleteForm, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteFormHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteForm request, CancellationToken cancellationToken)
    {
        try
        {
            Forms form = _applicationDbContext.Forms.FirstOrDefault(form=>form.Id==request.Id);

            if (form is null)
                return false;
            _applicationDbContext.Forms.Remove(form);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

