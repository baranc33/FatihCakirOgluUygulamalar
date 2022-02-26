
Console.WriteLine("");

Task myTask = new HttpClient().GetStringAsync("https://www.google.com")
    .ContinueWith((data) =>
    {
        Console.WriteLine(data.Result.ToString());
    });


await myTask;




static class test
{
    public static void MyMetot(string Data)
    {
        Console.WriteLine(Data);
    }
    public static void MyMetot2(string Data)
    {
        Console.WriteLine(Data.Length);
    }
}


