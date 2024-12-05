


//Console.WriteLine("Приложение начало работу");

////using (var client = new httpclient())
////{
////    using var result = await client.getasync("https://localhost:7169/song");
////    string content = await result.content.readasstringasync();
////    console.writeline(content);
////}

//using var httpClient = new HttpClient();
//var responseMassege = await httpClient.GetAsync("https://localhost:7169/Group");
//var respons = await responseMassege.Content.ReadAsStringAsync();
//Console.WriteLine(respons);
//Console.WriteLine("=================================================\n");

////var responseMassegeById = await httpClient.GetAsync($"https://localhost:7169/Group/{1}");
////Console.WriteLine(respons);
//Console.WriteLine("=================================================\n");

////var date = new DateOnly(1986, 12, 1);
////var str = date.ToString("D");
////var dictionary = new Dictionary<string, string>
////{
////    {"id","0" },
////    {"title","Marilyn Manson"},
////    {"urlImage","upload.wikimedia.org/wikipedia/commons/thumb/9/95/2015_RiP_Marilyn_Manson_-_by_2eight_-_DSC7281.jpg/399px-2015_RiP_Marilyn_Manson_-_by_2eight_-_DSC7281.jpg"},
////    {"description","...." },
////    {"foundationDate", date.ToString() },
////};
////var formUrlEncodedContent = new FormUrlEncodedContent(dictionary);
////var responseMassege = await httpClient.PostAsync($"https://localhost:7169/Group/", formUrlEncodedContent);
////var respons = await responseMassege.Content.ReadAsStringAsync();

//Console.ReadKey();
//Console.WriteLine("Приложение завершило работу");




//using System.Reflection;

//->    // Пример Рефлексии
//var test = new Test();


//MethodInfo methodInfo = test.GetType().GetMethod("Draw", BindingFlags.Instance | BindingFlags.NonPublic);
//methodInfo.Invoke(test, null);  // -> Console.WriteLine(" Пример Рефлексии");

////typeof(Class1).GetField("aValue", BindingFlags.Instance | BindingFlags.NonPublic);
////int a = (int)fieldInfo.GetValue(cls);

//class Test
//{
//    private void Draw()
//    {
//        Console.WriteLine(" Пример Рефлексии");
//    }
//}



// ======================

//using System.Text.Json;
//using System.Text.Json.Serialization;

//using var client = new HttpClient();
//using var rezult = await client.GetAsync($"https://localhost:7169/Group/1");

//var rez = await rezult.Content.ReadAsStringAsync();
//Person? restoredPerson = JsonSerializer.Deserialize<Person>(rez);
//Console.WriteLine(restoredPerson);
//Console.ReadLine();

//class Person
//{
//    [JsonPropertyName("title")]
//    public string? Title { get; }

//    [JsonPropertyName("description")]
//    public string? Description { get; }

//    public Person(string title, string description)
//    {
//        Title = title;
//        Description = description;
//    }

//    public override string ToString()
//    {
//        return $" Title: {Title}, Description: {Description}";
//    }
//}


// -------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;


var groupsHandler = new GroupsHandler();
var groupsJson = await groupsHandler.GetGroups(0, 2);
var listSerialize = JsonSerializer.Deserialize<GroupsList>(groupsJson);

foreach(var group in listSerialize.Groups)
{
    Console.WriteLine(group.ToString());
}
Console.ReadLine();



class GroupsHandler
{
    public async Task<string> GetGroups(int countSkip, int countTake)
    {
        using var client = new HttpClient();
        using var rezult = await client
            .GetAsync($"https://localhost:7169/Groups?countSkipGroups={countSkip}&countTakeGroups={countTake}");

        var groupsJson = await rezult.Content.ReadAsStringAsync();
        return groupsJson;
    }
}

class Group(int id, string title)
{
    [JsonPropertyName("id")]
    public int Id { get; set; } = id;
    [JsonPropertyName("title")]
    public string Title { get; set; } = title;
    public override string ToString() =>
         $"ID: {Id}, Title: {Title}";
    
}
class GroupsList(List<Group> groups)
{
    [JsonPropertyName("groups")]
    public required List<Group> Groups { get; set; } = groups;
}
