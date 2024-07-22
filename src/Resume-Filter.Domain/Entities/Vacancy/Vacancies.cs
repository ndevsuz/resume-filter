namespace Resume_Filter.Domain.Entities.Vacancy;

public class Vacancies:BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int RecruiterId { get; set; }
}

