using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExerciseDI_FeedReader
{
    public class FeedService
    {
        IFeedReader _medium;
        public FeedService(IFeedReader medium) 
        {
            _medium = medium; 
        }
        public string GetFeed()
        {
            return _medium.GetSingleFeed();      
        }
    }
}
