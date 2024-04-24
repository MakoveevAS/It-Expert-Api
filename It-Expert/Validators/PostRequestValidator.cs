using FluentValidation;
using It_Expert.Domain;

namespace It_Expert.Validators;

public class PostRequestValidator : AbstractValidator<PostRequest>
{
    public PostRequestValidator()
    {
        RuleFor(d => d.Data).NotNull().NotEmpty().WithMessage("Data can't be null or empty");
        RuleForEach(data => data.Data)
            .ChildRules(x => { 
                x.RuleFor(d => d.Code).NotNull().WithMessage("Code can't be null");
                x.RuleFor(d => d.Code).GreaterThan(0).WithMessage("Code must be greater than 0");
                x.RuleFor(d => d.Value).NotNull().WithMessage("Value can't be null");
            });
    }
}
