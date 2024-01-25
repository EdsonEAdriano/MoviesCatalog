﻿using FluentAssertions;
using MoviesCatalog.Domain.Entities;
using MoviesCatalog.Domain.Validation;

namespace MoviesCatalog.Tests;

public class MovieUnitTest1
{
    [Fact(DisplayName = "Create Movie With Valid Parameters")]
    public void CrateMovie_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Movie(1, "Movie title", "Movie description", new DateOnly(), "Image path");

        action
            .Should()
            .NotThrow<DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Create Movie With Negative Id")]
    public void CrateMovie_WithNegativeId_ResultObjectValidState()
    {
        Action action = () => new Movie(-1, "Movie title", "Movie description", new DateOnly(), "Image path");

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }
    
    [Fact(DisplayName = "Create Movie With Missing Title Value")]
    public void CrateMovie_WithMissingTitleValue_ResultObjectValidState()
    {
        Action action = () => new Movie(1, "", "Movie description", new DateOnly(), "Image path");

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid title.\nTitle is required");
    }
    
    [Fact(DisplayName = "Create Movie With Short Title Value")]
    public void CrateMovie_WithShortTitleValue_ResultObjectValidState()
    {
        Action action = () => new Movie(1, "Mo", "Movie description", new DateOnly(), "Image path");

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid title.\nTitle is too short, minimum 3 characters");
    }
    
    [Fact(DisplayName = "Create Movie With Missing Description Value")]
    public void CrateMovie_WithMissingDescriptionValue_ResultObjectValidState()
    {
        Action action = () => new Movie(1, "Movie title", "", new DateOnly(), "Image path");

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid description.\nDescription is required");
    }
    
    [Fact(DisplayName = "Create Movie With Short Description Value")]
    public void CrateMovie_WithShortDescriptionValue_ResultObjectValidState()
    {
        Action action = () => new Movie(1, "Movie Title", "Movi", new DateOnly(), "Image path");

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid description.\nDescription is too short, minimum 5 characters");
    }
    
    [Fact(DisplayName = "Create Movie With Long Image Path Value")]
    public void CrateMovie_WithShortImagePathValue_ResultObjectValidState()
    {
        Action action = () => new Movie(1, "Movie Title", "Movie description", new DateOnly(), "Image pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage pathImage path1");

        action
            .Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid image path.\nImage Path is too long, maximum 250 characters");
    }
}