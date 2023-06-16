using ExerciseDI_FeedReader;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Authentication.ExtendedProtection;
using System.Xml;

internal class Program
{
    private static IServiceProvider _serviceProvider;
    private static void RegisterServices()
    {
        var services = new ServiceCollection();
        // We get the correct instances from the xml file
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.IgnoreWhitespace = true;

        // Load the document and set the root element.  
        XmlDocument doc = new XmlDocument();
        doc.Load("config\\di_configuration.xml");
        
        XmlNode root = doc.DocumentElement;


        XmlNodeList nodeList = root.SelectNodes("implementation");
        foreach (XmlNode service in nodeList)
        {
            //firstchild = interface
            //lastchild = instance
            services.AddSingleton(
                Type.GetType(service.FirstChild.InnerText),
                Type.GetType(service.LastChild.InnerText)
                );
        }
        _serviceProvider = services.BuildServiceProvider(true);
    }
    private static void DisposeServices()
    {
        if (_serviceProvider == null)
        {
            return;
        }
        if (_serviceProvider is IDisposable)
        {
            ((IDisposable)_serviceProvider).Dispose();
        }
    }
    private static void Main(string[] args)
    {
        /*FeedService servicePodcast = new FeedService();
		string feed = servicePodcast.GetFeed();
		*/
        RegisterServices();

        var services = new ServiceCollection();

        /*services.AddSingleton<IFeedReader, BlogFeedReader>();
		services.AddSingleton<IFeedReader, YouTubeFeedReader>();
		services.AddSingleton<IFeedReader, PodcastFeedReader>();

		serviceProvider= services.BuildServiceProvider(true);*/

        /*FeedService feedService1 = new FeedService(serviceProvider.GetServices<IFeedReader>().ElementAt(0));
        FeedService feedService2 = new FeedService(serviceProvider.GetServices<IFeedReader>().ElementAt(1));
        FeedService feedService3 = new FeedService(serviceProvider.GetServices<IFeedReader>().ElementAt(2));*/


        FeedService feedService = new FeedService(_serviceProvider.GetService<IFeedReader>());


        Console.WriteLine(feedService.GetFeed());
        Console.ReadLine();

    }
}