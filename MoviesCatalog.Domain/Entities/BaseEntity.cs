using MoviesCatalog.Domain.Validation;

namespace MoviesCatalog.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; protected set; }

    public BaseEntity()
    {
    }
    
    public BaseEntity(int id)
    {
        DomainExceptionValidation.When(id < 0,
            "Invalid Id value");

        Id = id;
    }
}