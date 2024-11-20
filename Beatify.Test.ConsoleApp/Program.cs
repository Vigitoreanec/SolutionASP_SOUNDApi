Console.WriteLine("Приложение начало работу");

using (var client = new HttpClient())
{
    using var result = await client.GetAsync("https://localhost:7169/Song");
    string content = await result.Content.ReadAsStringAsync();
    Console.WriteLine(content);
}




Console.WriteLine("Приложение завершило работу");
