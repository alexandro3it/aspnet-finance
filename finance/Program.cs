using ASPFinance.Application.Services;
using ASPFinance.Infraestructure.Repositories;
using ASPFinance.Model;
using ASPFinance.Model.Mapping;
using AutoMapper;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

IMapper mapper = Mapping.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

AddModule(builder);

var app = builder.Build();

CultureInfo cultureInfo = new("pt-BR");
app.UseRequestLocalization(new RequestLocalizationOptions()
{
	DefaultRequestCulture = new RequestCulture(cultureInfo),
	SupportedCultures = new List<CultureInfo> { cultureInfo },
	SupportedUICultures = new List<CultureInfo> { cultureInfo }
});

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

static void AddModule(WebApplicationBuilder builder)
{
	builder.Services.AddDbContext<FinanceContext>
			(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

	builder.Services.AddScoped<ICreditRepository, CreditRepository>();
	builder.Services.AddScoped<IDebitRepository, DebitRepository>();

	builder.Services
		.AddScoped<IDebitsApplicationServices, DebitsApplicationServices>()
		.AddScoped<ICreditsApplicationServices, CreditsApplicationServices>();

	builder.Services.AddScoped<FinanceApplicationServices>();
}