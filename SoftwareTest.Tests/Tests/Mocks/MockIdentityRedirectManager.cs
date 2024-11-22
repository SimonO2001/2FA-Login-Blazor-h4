using Microsoft.AspNetCore.Components;

namespace SoftwareTest.Tests.Mocks;

public class MockIdentityRedirectManager
{
    public void RedirectTo(string uri) { /* No-op */ }
    public void RedirectTo(string uri, IDictionary<string, object?> queryParameters) { /* No-op */ }
}
