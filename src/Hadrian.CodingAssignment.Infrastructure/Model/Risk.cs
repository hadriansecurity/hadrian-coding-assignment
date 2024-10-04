using System.Text.Json.Serialization;

namespace Hadrian.CodingAssignment.Infrastructure.Model;

public class Risk
{
    public Guid Id { get; }

    public DateTimeOffset Created { get; set; }

    public RiskSeverity RiskSeverity { get; set; }

    public RiskStatus RiskStatus { get; set; }

    public string Title { get; set; }

    public string? VulnerabilityId { get; set; }

    public Guid OrganizationId { get; init; }

    [JsonIgnore]
    public Organization? Organization { get; }

    public Risk(Guid organizationId, string title, RiskSeverity riskSeverity, RiskStatus riskStatus)
    {
        Id = Guid.NewGuid();
        OrganizationId = organizationId;
        Title = title;
        RiskSeverity = riskSeverity;
        RiskStatus = riskStatus;
        Created = DateTimeOffset.UtcNow;
    }
}