using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDataProtection();

//If you would like to store the key in the file system, you need to configure the data protection
//builder.Services.AddDataProtection().PersistKeysToFileSystem(
//    new System.IO.DirectoryInfo(@"C:\Hooman\Temp")
//    );

//To configure the system to use a default key lifetime of 14 days instead of 90 days
//builder.Services.AddDataProtection().SetDefaultKeyLifetime(TimeSpan.FromDays(14));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDirectoryBrowser();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Hooman:Forwarded Headers Middleware helps your ASP.NET Core application to look for headers added by an upstream proxy or load balancer.
//If you are using another proxy besides IIS,  you need to add this. IIS takes care of Forwarded Headers by default.
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
}
    );

app.UseHttpsRedirection();
app.UseStaticFiles();

//var fileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.WebRootPath, "WebGPU"));
//var requestPath = "/WebGPU";

//// Enable displaying browser links.
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = fileProvider,
//    RequestPath = requestPath
//});

//app.UseDirectoryBrowser(new DirectoryBrowserOptions
//{
//    FileProvider = fileProvider,
//    RequestPath = requestPath
//});


app.MapGet("/WebGPU", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/WebGPU/index.html");
});


var fileProvider2 = new PhysicalFileProvider(Path.Combine(builder.Environment.WebRootPath, "WebGL2"));
var requestPath2 = "/WebGL2";

// Enable displaying browser links.
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = fileProvider2,
    RequestPath = requestPath2
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = fileProvider2,
    RequestPath = requestPath2
});



//for webgl
//var fileProvider3 = new PhysicalFileProvider(Path.Combine(builder.Environment.WebRootPath, "DinoRun"));
//var requestPath3 = "/DinoRun";

//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = fileProvider3,
//    RequestPath = requestPath3
//});

//app.UseDirectoryBrowser(new DirectoryBrowserOptions
//{
//    FileProvider = fileProvider3,
//    RequestPath = requestPath3
//});

app.UseStaticFiles(new StaticFileOptions()
{
    ContentTypeProvider = new FileExtensionContentTypeProvider(new Dictionary<string, string>
    {
     {
         ".data",
         "application/octet-stream"
       }
    })
});

app.UseRouting();

app.UseAuthorization();


app.MapGet("/EggCatcher", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/EggCatcher/index.html");
});

app.MapGet("/DinoRun", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/DinoRun/index.html");
});

app.MapGet("/BlockDodge", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/BlockDodge/index.html");
});

app.MapGet("/MazeBall", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/MazeBall/index.html");
});

app.MapGet("/CubeRunner", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/CubeRunner/index.html");
});

app.MapGet("/CoinCollector", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/CoinCollector/index.html");
});


app.MapGet("/HouseProject1", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/HouseProject1/index.html");
});

app.MapGet("/HouseProject2", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/HouseProject2/index.html");
});

app.MapGet("/GAME2012", async context =>
{
    context.Response.Redirect("https://github.com/hsalamat/OpenGL");
});

app.MapGet("/GAME3111", async context =>
{
    context.Response.Redirect("https://github.com/hsalamat/DirectX");
});

app.MapGet("/GAME3015", async context =>
{
    context.Response.Redirect("https://github.com/hsalamat/GameEngineDevelopment2");
});

app.MapGet("/GAME3121", async context =>
{
    context.Response.Redirect("https://github.com/hsalamat/GAME3121");
});


//app.MapGet("/DinoRun",  async context => 
//{
//     context.Response.Redirect("/DinoRun/index.html");
//});

//app.MapGet("/EggCatcher", async context =>
//{
//    context.Response.Redirect("/EggCatcher/index.html");
//});

app.MapGet("/ImageRecognition", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/ML5/src/ml5003/index.html");
});

app.MapGet("/AStar", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/AI/index.html");
});

app.MapGet("/NavMesh", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/NavMesh/index.html");
});

app.MapGet("/SportsAnalytics", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/SportsAnalytics/dist/index.html");
});

app.MapGet("/Brain", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/Brain/index.html");
});

app.MapGet("/TensorFlow", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/TensorFlow/index.html");
});

app.MapGet("/Animation1", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/Animation1/index.html");
});

app.MapGet("/Animation2", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/Animation2/index.html");
});

app.MapGet("/Animation3", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/Animation3/index.html");
});

app.MapGet("/Animation4", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/Animation4/index.html");
});


app.MapGet("/Food1", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/Food/How_To_Make_Focaccia_From_Scratch.htm");
});

app.MapGet("/Food2", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/Food/How_To_Make_Pizza_From_Scratch.htm");
});

app.MapGet("/Food3", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/Food/How_To_Make_Vegan_Cinnamon_Buns_From_Scratch.htm");
});

app.MapGet("/Food4", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/Food/How_To_Make_Vegan_No_Knead_Bread_From_Scratch.htm");
});

app.MapGet("/Food5", async context =>
{
    context.Response.Redirect("https://hoomanator.github.io/Food/How_To_Make_Vegan_Whole_Wheat_Bread_Loaves_From_Scratch.htm");
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
