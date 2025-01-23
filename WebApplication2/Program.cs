using WebApplication2.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// MET TA CLÉ API
string apiKey = "";
builder.Services.AddEndpointsApiExplorer();
// AJOUTER LE SINGLETON AU SERVICE 
builder.Services.AddSingleton(new GeminiApiClient(apiKey));
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Y FAUT TOUT CA 
app.UseCors(option => option
    .AllowAnyOrigin()
    .AllowAnyMethod().
    AllowAnyHeader().
    WithExposedHeaders("Content-Disposition"));
// JUSQUA ICI

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
