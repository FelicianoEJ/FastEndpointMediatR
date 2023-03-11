using FastEndpointMediatR.Application;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configure services
#region Service
builder.Services.AddAuthenticationCore(configureAuthentication);
builder.Services.AddAuthorizationCore(configureAuthorization);
builder.Services.AddApplicationMediatR();
builder.Services.AddCors();
builder.Services.AddExceptionHandler(configureExceptionHandling);
builder.Services.AddFastEndpoints();
#endregion

var app = builder.Build();

// Configure middleware
#region Middleware
app.UseExceptionHandler();
app.UseHsts();
app.UseHttpsRedirection();
app.UseCors(configureCorsPolicy);
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
#endregion

app.Run();

// Configuretions
#region Configurations

// Local configuration for CORS policy
void configureExceptionHandling(ExceptionHandlerOptions exceptionHandlerOptions)
{
    exceptionHandlerOptions.ExceptionHandler = async (HttpContext httpContext) =>
    {
        httpContext.Response.StatusCode = 500;
        await httpContext.Response.WriteAsync("Internal Server Error");
    };
}

// Local configuration for CORS policy
void configureCorsPolicy(CorsPolicyBuilder corsPolicyBuilder) => corsPolicyBuilder.AllowAnyOrigin();

// Local configuration for Authentication
void configureAuthentication(AuthenticationOptions authenticationOptions)
{ 
};

// Local configuration for Authentication
void configureAuthorization(AuthorizationOptions authorizationOptions)
{ 
};

#endregion
