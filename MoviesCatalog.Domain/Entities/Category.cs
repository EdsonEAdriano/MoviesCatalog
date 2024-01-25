using MoviesCatalog.Domain.Validation;

namespace MoviesCatalog.Domain.Entities;

public sealed class Category : BaseEntity
{
    public string Name { get; private set; }

    public Category(string name) : base()
    {
        ValidateDomain(name);
    }
    
    public Category(int id, string name) : base(id)
    {
        ValidateDomain(name);
    }

    public void Update(int id, string name)
    {
        DomainExceptionValidation.When(id < 0,
            "Invalid Id value");

        Id = id;
        
        ValidateDomain(name);
        Name = name;
    }
    

    public ICollection<Movie> Movies { get; set; }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
            "Invalid name.\nName is required");
        
        DomainExceptionValidation.When(name.Length < 3, 
            "Invalid name.\nName is too short, minimum 3 characters");

        Name = name;
    }
}