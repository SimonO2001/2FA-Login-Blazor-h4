using Bunit;
using Bunit.TestDoubles; // For AddTestAuthorization
using Xunit; // For [Fact]

namespace UnitTestProject;

public class UserLoggedInTests
{
    [Fact]
    public void UserAuthenticatedNotAdminTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();

        // Simulate logged-in user without Admin role
        authContext.SetAuthorized("RegularUser");
        authContext.SetRoles(); // No roles assigned

        // Act
        var cut = ctx.RenderComponent<SoftwareTest.Components.Pages.Home>();

        // Assert
        cut.MarkupMatches("<div>Du er logget ind (from code)</div> <div>Du er IKKE Admin</div>");
    }
}
