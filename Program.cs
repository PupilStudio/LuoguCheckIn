using PuppeteerSharp;
Console.Write("Downloading Browser Core... ");
await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
Console.WriteLine("Done.");
string cid = "", uid = "";
Console.Write("Input __client_id:");
cid = Console.ReadLine();
Console.Write("Input _uid:");
uid = Console.ReadLine();

while (true)
{
    using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = false });
    using var page = await browser.NewPageAsync();
    await page.SetCookieAsync(
        new CookieParam { Name = "__client_id", Value = cid, Domain = "www.luogu.com.cn" },
        new CookieParam { Name = "_uid", Value = uid, Domain = "www.luogu.com.cn" });
    page.DefaultNavigationTimeout = 250000;
    page.DefaultTimeout = 250000;
    await page.GoToAsync("https://www.luogu.com.cn/");
    await (await page.QuerySelectorAsync("a[title='hello']")).ClickAsync();
    Thread.Sleep(10000);
    await browser.CloseAsync();
    Thread.Sleep(86400000 - 10000);
}