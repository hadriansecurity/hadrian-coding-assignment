using System.Net.Http.Json;
using FluentAssertions;
using Hadrian.Coding.Assignment.Api;
using Hadrian.CodingAssignment.Infrastructure.Model;
using Hadrian.CodingAssignment.Tests.Extensions;
using Hadrian.CodingAssignment.Tests.Fixtures;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Hadrian.CodingAssignment.Tests;

public class RisksControllerTests : TestBase
{
    private static Organization _organization = new Organization("test org");
    private static Risk _riskUnderTest = new Risk(_organization.Id, "Test risk", RiskSeverity.Low, RiskStatus.New);

    public RisksControllerTests(PostgresFixture postgresFixture, WebApplicationFactory<Program> webAppFactory) : base(postgresFixture, webAppFactory)
    {

    }

    public override async Task InitializeAsync()
    {
        using var ctx = Database.CreateContext();

        ctx.Add(_organization);

        ctx.Add(_riskUnderTest);

        await ctx.SaveChangesAsync();
    }

    [Fact]
    public async Task GetRisks()
    {
        var client = CreateHttpClient();

        var response = await client.GetAsync($"organizations/{_organization.Id}/risks");

        var result = await response.AsAsync<Risk[]>();

        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task ChangeSeverity()
    {
        var client = CreateHttpClient();

        var response = await client.PostAsJsonAsync($"organizations/{_organization.Id}/risks/{_riskUnderTest.Id}/severity?severity=High", "");

        using var ctx = Database.CreateContext();
        var result = ctx.Set<Risk>().Should().Contain(x => x.Id == _riskUnderTest.Id).Which;
        result.RiskSeverity.Should().Be(RiskSeverity.High);
    }
}