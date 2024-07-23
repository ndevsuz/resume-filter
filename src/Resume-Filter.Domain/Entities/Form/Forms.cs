namespace Resume_Filter.Domain.Entities.Form;

public class Forms : BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public int VacancyId { get; set; }
    public string Resume { get; set; }
}