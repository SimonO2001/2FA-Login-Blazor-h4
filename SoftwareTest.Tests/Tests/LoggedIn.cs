using Bunit;
using Bunit.TestDoubles; // For AddTestAuthorization
using Xunit; // For [Fact]

namespace UnitTestProject;

public class LoggedInTests
{
    [Fact]
    public void AuthenticatedTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();

        // Simulate logged-in user who is NOT an Admin
        authContext.SetAuthorized("AuthenticatedUser");

        // Act
        var cut = ctx.RenderComponent<SoftwareTest.Components.Pages.Home>();

        // Assert
        cut.MarkupMatches(
            @"
            <div>Du er logget ind (from code)</div>
            <div>Du er IKKE Admin</div>
            ");
    }

}
