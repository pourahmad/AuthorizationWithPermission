using AuthenticationSample.Services;
using AuthorizationWithPermission.API.Data;
using AuthorizationWithPermission.API.Helpers;
using AuthorizationWithPermission.API.Services;
using AuthorizationWithPermission.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AuthDbContext>(options =>
    {
        options.UseSqlite("DataSource=Data\\db_Authoriz.db");
    });

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddClaimsPrincipalFactory<AuthUserClaimsPrincipalFactory>();

builder.Services.AddScoped<UserClaimsPrincipalFactory<IdentityUser>, AuthUserClaimsPrincipalFactory>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPermissionsService, PermissionsService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
