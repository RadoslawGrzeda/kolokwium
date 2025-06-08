using kolokwium.Properties.Data;
using kolokwium.Properties.Services;
using Microsoft.EntityFrameworkCore;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;

 
var builder = WebApplication.CreateBuilder(args);
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddAuthorization();
 
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
 
builder.Services.AddDbContext<Database>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
 
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IGetPurchaseCustomer,GetPurchaseCustomer>();
var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}
 
app.UseHttpsRedirection();
 
app.UseAuthorization();
app.MapControllers();
 
        
 
app.Run();