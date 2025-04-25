var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // Agregar sesi�n

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles(); // ?? �Debe ir antes de UseRouting()!
app.UseRouting();

app.UseSession(); // ?? La sesi�n va despu�s de UseRouting()
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Admin}/{action=Index}/{id?}");

app.Run();
