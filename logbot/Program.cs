using logbot.Database;
using logbot.Services.CompanyService;
using logbot.Services.ConversationLogService;
using logbot.Services.ConversationService;
using logbot.Services.ConversationStepService;
using logbot.Services.EmployeeService;
using logbot.Services.MessageService;
using logbot.Services.OrderService;
using logbot.Services.PaymentService;
using logbot.Services.PermissionService;
using logbot.Services.ProductService;
using logbot.Services.UserResponseService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAutomatedReplyInterface, AutomatedReplyService>();
builder.Services.AddScoped<ICompanyInterface, CompanyService>();
builder.Services.AddScoped<IConversationLogInterface, ConversationLogService>();
builder.Services.AddScoped<IConversationInterface, ConversationService>();
builder.Services.AddScoped<IConversationStepInterface, ConversationStepService>();
builder.Services.AddScoped<IEmployeeInterface, EmployeeService>();
builder.Services.AddScoped<IMessageInterface, MessageService>();
builder.Services.AddScoped<IOrderItemInterface, OrderItemService>();
builder.Services.AddScoped<IOrderInterface, OrderService>();
builder.Services.AddScoped<IPaymentInterface, PaymentService>();
builder.Services.AddScoped<IPermissionInterface, PermissionService>();
builder.Services.AddScoped<IProductInterface, ProductService>();
builder.Services.AddScoped<IUserResponseInterface, UserResponseService>();

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
