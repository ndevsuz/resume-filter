﻿namespace Resume_Filter.Application.DTO.Vacancy;

public class UpdateVacancyDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? RecruiterId { get; set; }
}

