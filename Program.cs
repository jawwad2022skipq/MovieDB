using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
// This creates a WebApplicationBuilder with preconfigured defaults
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add Razor Pages support to the Dependency Injection (DI) container
builder.Services.AddRazorPages();
// The data context RazorPagesMovieContext:
// Derives from Microsoft.EntityFrameworkCore.DbContext.
// Specifies which entities are included in the data model.
// Coordinates EF Core functionality, such as Create, Read, Update and Delete, for the Movie model.
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

// Build the WebApplication
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The following code sets the exception endpoint to /Error and enables HTTP Strict Transport Security Protocol (HSTS) when the app is not running in development mode
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Redirects HTTP requests to HTTPS.
app.UseHttpsRedirection();
// Enables static files, such as HTML, CSS, images, and JavaScript to be served.
app.UseStaticFiles();

// Adds route matching to the middleware pipeline. 
app.UseRouting();

// Authorizes a user to access secure resources.
app.UseAuthorization();

// Configures endpoint routing for Razor Pages.
app.MapRazorPages();

// Starts the application.
app.Run();
