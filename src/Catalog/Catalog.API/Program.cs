var builder = WebApplication.CreateBuilder(args);

//add services to the container.
builder.Services.AddCarter(); //http api
builder.Services.AddMediatR(config =>
{
	config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddMarten(options =>
{
	options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

//configure the HTTP request pipeline.
app.MapCarter();


app.Run();
 