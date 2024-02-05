using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MoviesCatalog.Domain.Entities;

namespace MoviesCatalog.Application.DTOs;

public class MovieDTO
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Title")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "The Description is Required")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Description")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "The Release Date is Required")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    [DisplayName("Release Date")]
    public DateOnly ReleaseDate { get; set; }
    
    [MaxLength(250)]
    [DisplayName("Movie Image")]
    public string? ImagePath { get; set; }
    
    public Category? Category { get; set; }
    
    [DisplayName("Categories")]
    public int CategoryId { get; set; }
    
}