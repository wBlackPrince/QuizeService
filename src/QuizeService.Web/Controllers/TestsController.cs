using Microsoft.AspNetCore.Mvc;
using QuizeService.Application.UseCases;
using QuizeService.Contracts;

namespace QuizeService.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TestsController : ControllerBase
{

    [HttpGet("{testId:guid}")]
    public async Task<ActionResult<GetTestByIdResponseDto>> GetById(
        [FromRoute] Guid testId,
        [FromServices] GetTestByIdUseCase useCase,
        CancellationToken cancellationToken)
    {
        var request = new GetTestByIdRequestDto(testId);
        var result = await useCase.Execute(request, cancellationToken);

        return Ok(result);
    }
    
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