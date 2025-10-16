using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using FluentValidation;

public class CreateAvisoCommandValidator : AbstractValidator<CreateAvisoCommand>
{
    public CreateAvisoCommandValidator()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty().WithMessage("O título é obrigatório.");


        RuleFor(x => x.Mensagem)
            .NotEmpty().WithMessage("A mensagem é obrigatória.");
    }
}
