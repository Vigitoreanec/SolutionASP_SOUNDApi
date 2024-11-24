Console.WriteLine("Приложение начало работу");

//using (var client = new httpclient())
//{
//    using var result = await client.getasync("https://localhost:7169/song");
//    string content = await result.content.readasstringasync();
//    console.writeline(content);
//}

using var httpClient = new HttpClient();
var responseMassege = await httpClient.GetAsync("https://localhost:7169/Group");
var respons = await responseMassege.Content.ReadAsStringAsync();
Console.WriteLine(respons);
Console.WriteLine("=================================================\n");

//var responseMassegeById = await httpClient.GetAsync($"https://localhost:7169/Group/{1}");
//Console.WriteLine(respons);
Console.WriteLine("=================================================\n");

//var date = new DateOnly(1986, 12, 1);
//var str = date.ToString("D");
//var dictionary = new Dictionary<string, string>
//{
//    {"id","0" },
//    {"title","Marilyn Manson"},
//    {"urlImage","upload.wikimedia.org/wikipedia/commons/thumb/9/95/2015_RiP_Marilyn_Manson_-_by_2eight_-_DSC7281.jpg/399px-2015_RiP_Marilyn_Manson_-_by_2eight_-_DSC7281.jpg"},
//    {"description","...." },
//    {"foundationDate", date.ToString() },
//};
//var formUrlEncodedContent = new FormUrlEncodedContent(dictionary);
//var responseMassege = await httpClient.PostAsync($"https://localhost:7169/Group/", formUrlEncodedContent);
//var respons = await responseMassege.Content.ReadAsStringAsync();



Console.ReadKey();
Console.WriteLine("Приложение завершило работу");
