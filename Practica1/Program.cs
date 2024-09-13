using Application.IMapper;
using Application.Interface;
using Application.Mappers;
using Application.UseCase;
//using Infraestructure.Command;
using Infraestructure.Command;
//using Infraestructure.Query;
using Infraestructure.Persistence;
using Infraestructure.Query;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Propio
var connectionString = builder.Configuration["ConnectionString"];


//Esto es la coneccion con la base de datos
//////builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddDbContext<ApiContext>(option => option.UseSqlServer(connectionString));


//Injeccion de dependecias
//////builder.Services.AddScoped<IStudentServices, StudentServices>();
//////builder.Services.AddScoped<IStudentQuery, StudentQuery>();
//////builder.Services.AddScoped<IStudentCommand, StudentCommand>();
//////builder.Services.AddTransient<UserInterface, ServicesGetAll>();
builder.Services.AddScoped<ICampaignTypeServices, CampaignTypeServices>();
builder.Services.AddScoped<ICampaignTypeQuery, CampaignTypeQuery>();
builder.Services.AddScoped<ICampaignTypeCommand, CampaignTypeCommand>();
builder.Services.AddScoped<IGenericMapper, GenericMapper>();

builder.Services.AddScoped<IInteractionTypeServices, InteractionTypeServices>();
builder.Services.AddScoped<IInteractionTypeQuery, InteractionTypeQuery>();
builder.Services.AddScoped<IInteractionTypeCommand, InteractionTypeCommand>();
//Esto es agregar dependecia. Cuando quieras injectar una instancia de UserInterface, te va a pasar una instancia de ServicesGetAll
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
