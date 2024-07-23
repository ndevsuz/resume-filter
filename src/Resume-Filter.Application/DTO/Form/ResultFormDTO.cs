using iTextSharp.text;

namespace Resume_Filter.Application.DTO.Form;

public class ResultFormDTO
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public int VacancyId { get; set; }
    public string Resume { get; set; }
    public int Match { get; set; } // foizda
    public List<string> MatchingSkills { get; set; }
    public bool IsAccepted { get; set; } = true;
}