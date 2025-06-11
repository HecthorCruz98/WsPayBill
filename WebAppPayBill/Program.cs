using WebAppPayBill.Services;
using WebAppPayBill.Services.DocumentServices;
using WebAppPayBill.Services.Enterprise;
using WebAppPayBill.Services.EnterpriseType;
using WebAppPayBill.Services.Rol;
using WebAppPayBill.Services.State;
using WebAppPayBill.Services.Transaction;
using WebAppPayBill.Services.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEnterpriseService, EnterpriseService>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IEnterpriseTypeService, EnterpriseTypeService>();








var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
