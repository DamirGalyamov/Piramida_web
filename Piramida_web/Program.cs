using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Piramida.Logic.Extations;
using Piramida.Storage.Database;
using Piramida.Storage.MS_SQL.Extensions;
using Piramida.Storage.MS_SQL.InitDatabase;
using Piramida_web.Extensions;
using Piramida_web.Features.Filters;
using System.Text;

// todo: ���������� �������� ����������� � ������

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o =>
    {
        // todo: ����������� � �������� ��������� ������, AsSplitQuery
        o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    }));
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<DevelopmentOnlyFilter>(); // ���� ��������� ���������� ����������
});
builder.Services.AddScoped<DevelopmentOnlyFilter>();

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddDataAnnotationsLocalization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddWebServices();

builder.Services.AddAutoMappers();
builder.Services.AddLogicServices();
builder.Services.AddStorageServices();

var key = Encoding.ASCII.GetBytes("my_secret_key_for_jwt_token"); // ��������� ����
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:7116", // ������� ��� Issuer
        ValidAudience = "http://localhost:7116", // ������� ���� Audience
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "C:/Users/User/Desktop/FPyramid1")), // ����� � HTML
    RequestPath = "" // ������ URL
});

app.MapControllers();


// ��������� �������� ��� ��������� ���� ��������
//app.MapFallback(async context =>
//{
//    var path = Path.Combine(Directory.GetCurrentDirectory(), "C:/Users/User/Desktop/FPyramid1", "index.html"); // ������� ����
//    context.Response.ContentType = "text/html";
//    await context.Response.SendFileAsync(path);
//});
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

var databaseInit = app.Services.GetRequiredService<DatabaseInit>();
databaseInit.InternalSeed();

app.Run();
