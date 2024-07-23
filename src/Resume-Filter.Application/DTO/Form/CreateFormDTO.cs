
using Microsoft.AspNetCore.Http;

namespace Resume_Filter.Application.DTO.Form;

public class CreateFormDTO
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public int VacancyId { get; set; }
    public IFormFile Resume { get; set; }
}

