using ExerciseDI_FeedReader;
using Moq;
using System.Diagnostics.Contracts;

namespace FeedReaderTest
{
    [TestClass]
    public class FeedServiceTest
    {
        [TestMethod]
        public void GetFeed()
        {
            // Order retrieves its dependency via the constructor
            // We can mock it and change its behavior for this test
            var mediumSender = new Mock<IFeedReader>();
            // The following code simulates the execution of the Contact() method and returns a value that we choose
            mediumSender.Setup(e => e.GetSingleFeed())
                .Returns("Type: item1");

            FeedService feedService = new FeedService(mediumSender.Object);

            var response = feedService.GetFeed();


            Assert.AreEqual("Type: item1", response);

        }
    }
}