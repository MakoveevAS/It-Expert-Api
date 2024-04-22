using FluentValidation.TestHelper;
using It_Expert.Domain.Requests;
using It_Expert.Validators;

namespace It_Expert.Unit.Tests;

public class PostRequestValidatorTests
{
    PostRequestValidator validator;

    public PostRequestValidatorTests()
    {
        validator = new PostRequestValidator();
    }

    [Fact]
    public void ShouldBeValid()
    {
        var data = new PostRequest()
        {
            Data =
            [
                new()
                {
                    Code = 1,
                    Value = string.Empty
                }
            ]
        };
        var validationResult = validator.TestValidate(data);
        Assert.True(validationResult.IsValid);
    }

    [Fact]
    public void ShouldBeInvalidWhenDataIsNull()
    {
        var data = new PostRequest()
        {
            Data = [ ]
        };
        var validationResult = validator.TestValidate(data);
        validationResult.ShouldHaveValidationErrorFor(param =>  param.Data);
        Assert.False(validationResult.IsValid);
    }

    [Fact]
    public void ShouldBeInvalidWhenCodeIsNull()
    {
        var data = new PostRequest()
        {
            Data =
           [
               new()
                {
                    Code = null,
                    Value = string.Empty,
                }
           ]
        };
        var validationResult = validator.TestValidate(data);
        validationResult.ShouldHaveValidationErrorFor("Data[0].Code").WithErrorCode("NotNullValidator");
        Assert.False(validationResult.IsValid);
    }

    [Fact]
    public void ShouldBeInvalidWhenCodeIsZero()
    {
        var data = new PostRequest()
        {
            Data =
           [
               new()
                {
                    Code = 0,
                    Value = string.Empty
                }
           ]
        };
        var validationResult = validator.TestValidate(data);
        validationResult.ShouldHaveValidationErrorFor("Data[0].Code").WithErrorCode("GreaterThanValidator");
        Assert.False(validationResult.IsValid);
    }

    [Fact]
    public void ShouldBeInvalidWhenValueIsNull()
    {
        var data = new PostRequest()
        {
            Data =
           [
               new()
                {
                    Code = 1,
                    Value = null
                }
           ]
        };
        var validationResult = validator.TestValidate(data);
        validationResult.ShouldHaveValidationErrorFor("Data[0].Value").WithErrorCode("NotNullValidator");
        Assert.False(validationResult.IsValid);
    }
}