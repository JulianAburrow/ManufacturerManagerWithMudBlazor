var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddRazorPages(options =>
{
    options.RootDirectory = "/Features";
});

builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.ConfigureSqlConnections(configuration);
builder.Services.AddDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Features/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
