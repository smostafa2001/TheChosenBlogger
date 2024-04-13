using TheChosenBlogger.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

Bootstrapper.Configure(builder.Services, builder.Configuration.GetConnectionString("TheChosenBloggerDb"));
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
