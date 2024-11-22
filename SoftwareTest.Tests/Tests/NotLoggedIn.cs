using Bunit;
using Bunit.TestDoubles; // For AddTestAuthorization
using Xunit; // For [Fact]

namespace UnitTestProject;

public class NotLoggedInTests
{
    [Fact]
    public void NotAuthenticatedTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();

        // Simulate unauthenticated user
        authContext.SetNotAuthorized();

        // Act
        var cut = ctx.RenderComponent<SoftwareTest.Components.Pages.Home>();

        // Assert
        cut.MarkupMatches(
            @"
            <div>Du er IKKE logget ind (from code)</div>
            <div>Du er IKKE Admin</div>
            ");
    }

}
