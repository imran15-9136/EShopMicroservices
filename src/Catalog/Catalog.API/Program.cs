var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCarter(); // HTTP API
builder.Services.AddMediatR(config =>
{
	config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddMarten(options =>
{
	options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.MapCarter();

app.Run();