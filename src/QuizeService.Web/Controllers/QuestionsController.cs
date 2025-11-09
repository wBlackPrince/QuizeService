using Microsoft.AspNetCore.Mvc;
using QuizeService.Application.UseCases;
using QuizeService.Contracts;

namespace QuizeService.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionsController: ControllerBase
{
    [HttpPost("{testId:guid}/match-question")]
    public async Task<ActionResult<Guid>> AddMatchQuestion(
        [FromBody] AddMatchQuestionDto request,
        [FromServices] AddMatchQuestionUseCase useCase,
        CancellationToken cancellationToken)
    {
        var result = await useCase.Execute(request, cancellationToken);

        return Ok(result);
    }
    
    [HttpPost("{testId:guid}/text-input-answer")]
    public async Task<ActionResult<Guid>> AddTextInputQuestion(
        [FromBody] AddTextInputQuestionDto request,
        [FromServices] AddTextInputQuestionUseCase useCase,
        CancellationToken cancellationToken)
    {
        var result = await useCase.Execute(request, cancellationToken);

        return Ok(result);
    }
    
    [HttpPost("{testId:guid}/single-choice-question")]
    public async Task<ActionResult<Guid>> AddSingleChoiceQuestion(
        [FromBody] AddTextInputQuestionDto request,
        [FromServices] AddTextInputQuestionUseCase useCase,
        CancellationToken cancellationToken)
    {
        var result = await useCase.Execute(request, cancellationToken);

        return Ok(result);
    }
}


