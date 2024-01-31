using MoviesCatalog.Domain.Validation;

namespace MoviesCatalog.Domain.Entities;

public sealed class Movie : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateOnly ReleaseDate { get; private set; }
    public string? ImagePath { get; private set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public Movie(string title, string description, DateOnly releaseDate, string imagePath) : base()
    {
        ValidateDomain(title, description, releaseDate, imagePath);
    }
    
    public Movie(int id, string title, string description, DateOnly releaseDate, string imagePath) : base(id)
    {
        ValidateDomain(title, description, releaseDate, imagePath);
    }
    
    public void Update(int id, string title, string description, DateOnly releaseDate, string imagePath)
    {
        DomainExceptionValidation.When(id < 0,
            "Invalid Id value");

        Id = id;
        
        ValidateDomain(title, description, releaseDate, imagePath);
    }

    private void ValidateDomain(string title, string description, DateOnly releaseDate, string imagePath)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(title), 
            "Invalid title.\nTitle is required");
        
        DomainExceptionValidation.When(title.Length < 3, 
            "Invalid title.\nTitle is too short, minimum 3 characters");
        
        
        DomainExceptionValidation.When(string.IsNullOrEmpty(description), 
            "Invalid description.\nDescription is required");
        
        DomainExceptionValidation.When(description.Length < 5, 
            "Invalid description.\nDescription is too short, minimum 5 characters");
        
        
        
        DomainExceptionValidation.When(imagePath?.Length > 250, 
            "Invalid image path.\nImage Path is too long, maximum 250 characters");

        Title = title;
        Description = description;
        ReleaseDate = releaseDate;
        ImagePath = imagePath;
    }
}