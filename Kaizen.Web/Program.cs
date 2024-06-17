using Kaizen.Business.Interface;
using Kaizen.Business.Worker;
using Kaizen.Data.DataContent;
using Kaizen.Data.DataServices;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Add services to the container.

builder.Services.AddRazorPages();
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

app.Run();
