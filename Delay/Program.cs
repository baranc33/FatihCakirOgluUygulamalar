/*
 
 */




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


Console.WriteLine("Delay metodundan önce");
Content[] contents = await Task.WhenAll(taskList.ToArray());

contents.ToList().ForEach(x =>
{
    Console.WriteLine(x.Site);
});




static async Task<Content> GetContentAsync(string url)
{
    Content c = new Content();
    var data = await new HttpClient().GetStringAsync(url);

    // burası
    await Task.Delay(1000);

    c.Site = url;
    c.Len = data.Length;
    Console.WriteLine("GetContentAsync Thraead " + Thread.CurrentThread.ManagedThreadId);

    return c;
}
