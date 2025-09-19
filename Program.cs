using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Services;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Repositories.IRepository;
using PresupuestitoBack;

var builder = WebApplication.CreateBuilder(args);

var AllowSpecificOrigins = "";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


#region Services and Repositories

builder.Services.AddScoped<BudgetService>();
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();

builder.Services.AddScoped<StatService>();

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddScoped<ClientHistoryService>();
builder.Services.AddScoped<IClientHistoryRepository, ClientHistoryRepository>();

builder.Services.AddScoped<CostService>();
builder.Services.AddScoped<ICostRepository, CostRepository>();

builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<EmployeeHistoryService>();
builder.Services.AddScoped<IEmployeeHistoryRepository, EmployeeHistoryRepository>();

builder.Services.AddScoped<FixedCostService>();
builder.Services.AddScoped<IFixedCostRepository, FixedCostRepository>();

builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

builder.Services.AddScoped<InvoiceItemService>();
builder.Services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();

builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddScoped<MaterialService>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();

builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<SalaryService>();
builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();

builder.Services.AddScoped<SubCategoryMaterialService>();
builder.Services.AddScoped<ISubCategoryMaterialRepository, SubCategoryMaterialRepository>();

builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

builder.Services.AddScoped<SupplierHistoryService>();
builder.Services.AddScoped<ISupplierHistoryRepository, SupplierHistoryRepository>();

builder.Services.AddScoped<WorkService>();
builder.Services.AddScoped<IWorkRepository, WorkRepository>();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(AllowSpecificOrigins);
app.MapControllers();

app.Run();
