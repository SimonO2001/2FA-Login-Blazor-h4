using Bunit;
using Bunit.TestDoubles; // For AddTestAuthorization
using Xunit; // For [Fact]

namespace UnitTestProject;

public class AdminLoggedInTests
{
    [Fact]
    public void AdminAuthenticatedTest()
    {
        // Arrange
        using var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();

        // Simulate logged-in user with Admin role
        authContext.SetAuthorized("AdminUser");
        authContext.SetRoles("Admin");

        // Act
        var cut = ctx.RenderComponent<SoftwareTest.Components.Pages.Home>();

        // Assert
        cut.MarkupMatches("<div>Du er logget ind (from code)</div> <div>Du er Admin</div>");
    }
}
