using System.Web;
using System.Web.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.EnableEndpointRouting=false);

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
//app.UseRouting();
app.UseAuthorization();

app.UseMvcWithDefaultRoute();
//app.UseMvc(routes =>
//{
//  routes.MapRoute(
//      name: "default",
//      template: "api/{controller=Home}/{action=Index}/{id?}");
//});

app.Run();


