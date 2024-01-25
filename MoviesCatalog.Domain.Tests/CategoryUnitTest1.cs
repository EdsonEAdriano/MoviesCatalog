using System.Collections.Specialized;
using FluentAssertions;
using MoviesCatalog.Domain.Entities;
using MoviesCatalog.Domain.Validation;

namespace MoviesCatalog.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CrateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");

        action
            .Should()
            .NotThrow<DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Create Category With Negative Id")]
    public void CrateCategory_WithNegativeId_ResultObjectValidState()
    {
        Action action = () => new Category(-1, "Category Name");

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }
    
    [Fact(DisplayName = "Create Category With Missing Name Value")]
    public void CrateCategory_WithMissingNameValue_ResultObjectValidState()
    {
        Action action = () => new Category(1, "");

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name.\nName is required");
    }
    
    [Fact(DisplayName = "Create Category With Short Name Value")]
    public void CrateCategory_WithShortNameValue_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Ca");

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name.\nName is too short, minimum 3 characters");
    }
}