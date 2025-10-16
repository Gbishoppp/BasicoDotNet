using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using FluentValidation;

public class UpdateAvisoCommandValidator : AbstractValidator<UpdateAvisoCommand>
{
    public UpdateAvisoCommandValidator()
    {
        RuleFor(x => x.Mensagem)
            .NotEmpty().WithMessage("A mensagem é obrigatória.");
    }
}
