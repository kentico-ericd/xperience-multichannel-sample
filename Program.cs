using Common;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKentico(features =>
{
    features.UsePageBuilder(new PageBuilderOptions
    {
        ContentTypeNames = [Home.CONTENT_TYPE_NAME]
    });
    features.UseWebPageRouting();
});

builder.Services.AddAuthentication();

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.InitKentico();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseDeveloperExceptionPage();

app.UseAuthentication();

app.UseKentico();

app.Kentico().MapRoutes();

app.Run();
