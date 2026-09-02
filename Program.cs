using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using MockExam.Fluent;
using MockExam.Fluent.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddFluentUIComponents();
builder.Services.AddScoped<ExamSession>();
builder.Services.AddScoped<TrainingProgress>();
builder.Services.AddScoped<CourseState>();

await builder.Build().RunAsync();
