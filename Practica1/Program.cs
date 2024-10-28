using Application.IMapper;
using Application.Interface;
using Application.Mappers;
using Application.UseCase;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Query;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ConnectionString"];

builder.Services.AddDbContext<ApiContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddScoped<ICampaignTypeServices, CampaignTypeServices>();
builder.Services.AddScoped<ICampaignTypeQuery, CampaignTypeQuery>();
builder.Services.AddScoped<ICampaignTypeCommand, CampaignTypeCommand>();
builder.Services.AddScoped<IGenericMapper, GenericMapper>();

builder.Services.AddScoped<IInteractionTypeServices, InteractionTypeServices>();
builder.Services.AddScoped<IInteractionTypeQuery, InteractionTypeQuery>();
builder.Services.AddScoped<IInteractionTypeCommand, InteractionTypeCommand>();

builder.Services.AddScoped<IClientServices, ClientServices>();
builder.Services.AddScoped<IClientQuery, ClientQuery>();
builder.Services.AddScoped<IClientCommand, ClientCommand>();
builder.Services.AddScoped<IClientMapper, ClientMapper>();

builder.Services.AddScoped<IProjectServices, ProjectServices>();
builder.Services.AddScoped<IProjectQuery, ProjectQuery>();
builder.Services.AddScoped<IProjectCommand, ProjectCommand>();
builder.Services.AddScoped<IProjectMapper, ProjectMapper>();
builder.Services.AddScoped<IInformationProjectMapper, InformationProjectMapper>();

builder.Services.AddScoped<IInteractionServices, InteractionServices>();
builder.Services.AddScoped<IInteractionCommand, InteractionCommand>();
builder.Services.AddScoped<IInteractionQuery, InteractionQuery>();
builder.Services.AddScoped<IInteractionMapper, InteractionMapper>();

builder.Services.AddScoped<ITaskServices, TaskServices>();
builder.Services.AddScoped<ITaskCommand, TaskCommand>();
builder.Services.AddScoped<ITaskQuery, TaskQuery>();
builder.Services.AddScoped<ITaskMapper, TaskMapper>();

builder.Services.AddScoped<ITaskStatusServices, TaskStatusServices>();
builder.Services.AddScoped<ITaskStatusQuery, TaskStatusQuery>();

builder.Services.AddScoped<IUserQuery, UserQuery>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserMapper, UserMapper>();




// Definir la política de CORS antes de crear el builder
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Agregar servicios
builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

app.UseCors("AllowAll");
app.UseRouting();

//app.Run();

//var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
