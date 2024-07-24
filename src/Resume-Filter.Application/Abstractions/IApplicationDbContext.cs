using Microsoft.EntityFrameworkCore;
using Resume_Filter.Domain.Entities.Form;
using Resume_Filter.Domain.Entities.HR;
using Resume_Filter.Domain.Entities.Vacancy;

namespace Resume_Filter.Application.Abstractions;

public interface IApplicationDbContext
{
    public DbSet<Forms> Forms { get; set; }
    public DbSet<Vacancies> Vacancies { get; set; }
    public DbSet<Recruiter> Recruiters { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

