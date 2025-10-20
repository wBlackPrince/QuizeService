using Microsoft.AspNetCore.Mvc;
using QuizeService.Application.UseCases;
using QuizeService.Contracts;

namespace QuizeService.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        [FromBody] CreateTestRequestDto request,
        [FromServices] CreateTestUseCase useCase,
        CancellationToken cancellationToken)
    {
        var result = await useCase.Execute(request, cancellationToken);

        return Ok(result);
    }
}