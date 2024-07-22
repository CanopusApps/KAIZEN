using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Kaizen.Business.Interface;
using Kaizen.Business.Worker;
using Kaizen.Data.DataContent;
using Kaizen.Data.DataServices;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.NewKaizen;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<NewKaizenModel>(builder.Configuration.GetSection("Information"));


// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IDashboard, DashboardWorker>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<IBlock, BlockWorker>();
builder.Services.AddScoped<IBlockRepository, BlockRepository>();
builder.Services.AddScoped<IAddUser, AddUserWorker>();
builder.Services.AddScoped<IAddUserRepository, AddUserRepository>();
builder.Services.AddScoped<IViewuser, ViewuserWorker>();
builder.Services.AddScoped<IViewuserRepository, ViewuserRepository>();
builder.Services.AddScoped<IDomain, DomainWorker>();
builder.Services.AddScoped<IDomainRepository, DomainRepository>();
builder.Services.AddScoped<IDepartment, DepartmentWorker>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ILogin, LoginWorker>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IEditUser, EditUserWorker>();
builder.Services.AddScoped<IEditUserRepository, EditUserRepository>();
builder.Services.AddScoped<ISubmittedKaizen, SubmittedKaizenWorker>();
builder.Services.AddScoped<ISubmittedKaizenRepository, SubmittedKaizenRepository>();
builder.Services.AddScoped<ICreateNewKaizen, CreateNewKaizenWorker>();
builder.Services.AddScoped<ICreateNewKaizenRepository,CreateNewKaizenRepository>();
builder.Services.AddScoped<IReport, ReportWorker>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IWinnersList, WinnersListWorker>();
builder.Services.AddScoped<IWinnersListRepository, WinnersListRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");
app.UseSession();

app.Run();
