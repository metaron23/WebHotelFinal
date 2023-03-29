using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebHotel.Data;
using WebHotel.Service.NotifiHub;
using WebHotel.Startup;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
#region Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
                      });
});
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region DB Context
builder.Services.AddDbContext<MyDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));
#endregion
#region Service Custom
builder.SwaggerService();
builder.Services.IdentityService();
builder.Services.RepositoryService();
builder.AuthenJWTService();
builder.Services.AuthorService();
#endregion
builder.Services.AddSignalR();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();
// Configure the HTTP request pipeline.
#region Swagger
app.UseSwagger();
app.UseSwaggerUI();
#endregion
app.UseDefaultFiles();
app.UseStaticFiles();
#region Master
app.UseHttpsRedirection();
app.UseFileServer();
#endregion
#region Cors
app.UseCors(MyAllowSpecificOrigins);
#endregion

#region Master
app.MapHub<ChatHub>("hub");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
#endregion
