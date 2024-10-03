using Microsoft.AspNetCore.Mvc;
using Hadrian.CodingAssignment.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Hadrian.CodingAssignment.Infrastructure.Model;
using Hadrian.CodingAssignment.Infrastructure.Data;

namespace Hadrian.CodingAssignment.Api.Controllers;

[ApiController]
[Route("organizations/{organizationId}/risks")]
public class RisksController : ControllerBase
{
    private readonly RisksRepository _risksRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RisksController(
        RisksRepository risksRepository,
        IUnitOfWork unitOfWork)
    {
        _risksRepository = risksRepository;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<Risk[]> GetRisks(
        [FromRoute] Guid organizationId)
    {
        var risks = _risksRepository
            .BuildQuery()
            .Include(x => x.Organization)
            .Where(x => x.OrganizationId == organizationId)
            .ToArray();

        return risks;
    }

    [HttpPost]
    [Route("{riskId}/severity")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task ChangeSeverity(
        [FromRoute] Guid organizationId,
        [FromRoute] Guid riskId,
        [FromQuery] RiskSeverity severity,
        CancellationToken cancellationToken = default)
    {
        var risk = _risksRepository
            .BuildQuery()
            .Include(x => x.Organization)
            .Single(x => x.Id == riskId && x.OrganizationId == organizationId);

        risk.RiskSeverity = severity;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}