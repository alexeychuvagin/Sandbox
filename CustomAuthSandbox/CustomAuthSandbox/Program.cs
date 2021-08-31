using CustomAuthSandbox.Authentication.Basic;
using CustomAuthSandbox.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services
    .AddAuthentication()
    .AddBasic<MockAuthenticationService>(cfg => cfg.Realm = "CustomAuthSandbox");

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "CustomAuthSandbox", Version = "v1" });
    c.AddSecurityDefinition(
        BasicAuthenticationDefaults.AuthenticationScheme,
        new OpenApiSecurityScheme
        {
            Name = BasicAuthenticationDefaults.HeaderName,
            Type = SecuritySchemeType.Http,
            Scheme = BasicAuthenticationDefaults.AuthenticationScheme,
            In = ParameterLocation.Header,
            Description = "Basic Authorization header using the Bearer scheme."
        });
    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = BasicAuthenticationDefaults.AuthenticationScheme
                    }
                },
                Array.Empty<string>()
            }
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomAuthSandbox v1"));
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
