
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

// 1. senaryoda direk işlem yabiliriz
//var contents = await Task.WhenAll(taskList.ToArray());
//contents.ToList().ForEach(x =>
//{
//    Console.WriteLine($"{x.Site} boyu:{ x.Len}");
//});

// 2. senaryoda araya farklı işlemler sokarakta yapabiliriz
var contents = Task.WhenAll(taskList.ToArray());
///burda farklı işlemler yapabiliriz
///
var data = await contents;

data.ToList().ForEach(x =>
{
    Console.WriteLine($"{x.Site} boyu:{ x.Len}");
});








static async Task<Content> GetContentAsync(string url)
{
    Content c = new Content();
    var data = await new HttpClient().GetStringAsync(url);

    c.Site = url;
    c.Len = data.Length;
    Console.WriteLine("GetContentAsync Thraead " + Thread.CurrentThread.ManagedThreadId);

    return c;
}
