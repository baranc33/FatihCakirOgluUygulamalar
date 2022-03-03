// whenall metodundan farkı Ana Thradi kitler
// diğer bir farkı istersen milisaniye cinsiden bir parametre alır eğer
// belirtilen süre içersinde cevap dönerse true dönmezse işlemi iptal eder false döner





List<string> urlList = new List<string>()
{
    "https://www.google.com",
    "https://www.microsoft.com",
    "https://www.amazon.com",
    "https://www.n11.com",
    "https://www.haberturk.com",
};


List<Task<Content>> taskList = new List<Task<Content>>();


urlList.ToList().ForEach(x =>
{
    taskList.Add(GetContentAsync(x));
});


Console.WriteLine("WaitAll metodundan önce");
bool result=Task.WaitAll(taskList.ToArray(),3000);
// istersek saniye vermiyede biliriz
//bool result=Task.WaitAll(taskList.ToArray());
Console.WriteLine("3 saniyede geldi mi : " + result);

Console.WriteLine("WaitAll methodundan sonra");

Console.WriteLine($"{taskList.First().Result.Site} - {taskList.First().Result.Len}");



static async Task<Content> GetContentAsync(string url)
{
    Content c = new Content();
    var data = await new HttpClient().GetStringAsync(url);

    c.Site = url;
    c.Len = data.Length;
    Console.WriteLine("GetContentAsync Thraead " + Thread.CurrentThread.ManagedThreadId);

    return c;
}
