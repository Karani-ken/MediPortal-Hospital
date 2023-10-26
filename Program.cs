using Azure.Storage.Blobs;
using MediPortal_Hospital.Data;
using MediPortal_Hospital.Extensions;
using MediPortal_Hospital.Services;
using MediPortal_Hospital.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});
builder.Services.AddScoped(_ =>
{
    return new BlobServiceClient(builder.Configuration.GetConnectionString("blobstorage"));
});

builder.Services.AddScoped<IHospitalInterface, HospitalServices>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(options => options.AddPolicy("policy", build =>
{
    build.AllowAnyOrigin();
    build.AllowAnyMethod();
    build.AllowAnyHeader();
}));
builder.AddSwaggenGenExtension();
builder.AddAppAuthentication();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    if (!app.Environment.IsDevelopment())
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HOSPITAL API");
        c.RoutePrefix = string.Empty;
    }
});

app.UseHttpsRedirection();
app.UseMigration();
app.UseCors("policy");
app.UseAuthorization();

app.MapControllers();

app.Run();
