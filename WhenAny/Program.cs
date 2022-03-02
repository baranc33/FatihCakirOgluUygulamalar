
Console.WriteLine("Main Thraead " + Thread.CurrentThread.ManagedThreadId);

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


var FirstData=await Task.WhenAny(taskList);


Console.WriteLine($"{FirstData.Result.Site} - {FirstData.Result.Len} ");




static async Task<Content> GetContentAsync(string url)
{
    Content c = new Content();
    var data = await new HttpClient().GetStringAsync(url);

    c.Site = url;
    c.Len = data.Length;
    Console.WriteLine("GetContentAsync Thraead " + Thread.CurrentThread.ManagedThreadId);

    return c;
}
