
using TaskoMask.Infrastructure.Data.ReadModel.DataProviders;
using TaskoMask.Infrastructure.Data.WriteModel.DataProviders;
using TaskoMask.Presentation.Framework.Web.Configuration.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvcProjectConfigureServices(builder.Configuration, builder.Environment);


var app = builder.Build();

app.UseMvcProjectConfigure(app.Services, builder.Environment);

WriteDbSeedData.SeedAdminPanelTempData(app.Services);
ReadDbSeedData.SyncAdminPanelTempData(app.Services);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Account}/{action=login}/{id?}");

});

app.Run();
