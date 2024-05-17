using songcayawoncorelib.Model;
using songcayawoncorelib.Stores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add Model
//builder.Services.AddScoped<IStudentModel, StudentModel>();
//builder.Services.AddTransient<IStudentModel, StudentModel>();
builder.Services.AddSingleton<IStudentModel, StudentModel>();
// Add Store
//builder.Services.AddScoped<IStudentStore, StudentStore>();
//builder.Services.AddTransient<IStudentStore, StudentStore>();
builder.Services.AddSingleton<IStudentStore, StudentStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
