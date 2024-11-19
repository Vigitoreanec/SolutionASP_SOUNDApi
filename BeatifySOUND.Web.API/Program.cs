using Beatify.DataBase.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("BeatifyDBContext");
// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<BeatifyDBContext>(options =>
    options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
