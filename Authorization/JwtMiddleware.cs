using WebApi.Interfaces;
using WebApi.Services;

namespace WebApi.Authorization;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserService userService, IJwt jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = jwtUtils.ValidateToken(token);
        if (!userId.Equals(null))
            context.Items["User"] = userService.GetById(userId.Value);

        await _next(context);
    }
}