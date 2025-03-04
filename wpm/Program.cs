using wpm.Components;
using wpm.Dal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInMemoryWpmDb();
builder.Services.AddQuickGridEntityFrameworkAdapter();
/*
builder.Services.AddDbContext<WpmDbContext>(options =>
{
    options.UseInMemoryDatabase("Wpm");
});*/

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

app.Services.EnsureWpmDbIsCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(wpm.Client._Imports).Assembly);

app.Run();
