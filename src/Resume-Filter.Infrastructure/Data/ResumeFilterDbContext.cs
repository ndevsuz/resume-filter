using Microsoft.EntityFrameworkCore;
using Resume_Filter.Application.Abstractions;
using Resume_Filter.Domain.Entities.Form;
using Resume_Filter.Domain.Entities.HR;
using Resume_Filter.Domain.Entities.Vacancy;

namespace Resume_Filter.Infrastructure.Data;

public class ResumeFilterDbContext :DbContext, IApplicationDbContext
{
    public ResumeFilterDbContext(DbContextOptions<ResumeFilterDbContext> options):base(options)
    {
    
    }

    public DbSet<Vacancies> Vacancies { get; set; }
    public DbSet<Recruiter> Recruiters { get; set; }
    public DbSet<Forms> Forms { get; set; }

}

