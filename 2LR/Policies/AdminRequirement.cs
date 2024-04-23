using Microsoft.AspNetCore.Authorization;

namespace _2LR.Policies
{
    public class AdminRequirement : IAuthorizationRequirement
    {
    }

    public class AdminRequirementHandler : AuthorizationHandler<AdminRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            AdminRequirement requirement)
        {
            if (context.User.IsInRole("Admin"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
