using BeautifySOUND.Web.API;
using Microsoft.EntityFrameworkCore;


CreateHostBuilder(args).Build().Run();

//var builder = WebApplication.CreateBuilder(args);

//// �������� ������ ����������� �� ����� ������������

//// ��������� �������� ApplicationContext � �������� ������� � ����������


//builder.Services.AddControllers();


//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    webBuilder.UseStartup<Startup>());