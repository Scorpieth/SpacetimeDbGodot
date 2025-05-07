using SpacetimeDB;
using StdbModule.domain;

namespace StdbModule.Features.HelperMethods;

public static class ReducerContextExtensions
{
    public static User GetCurrentUser(this ReducerContext ctx) =>
        ctx.Db.Users.Identity.Find(ctx.Sender);
}