using Todo.Core.Abstraction;
using Todo.Core.DataContext;
using Todo.Core.Services;
using Todo.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoGenericDb"));
});





builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddTransient<ITodoRepository, TodoRepository>();


builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
