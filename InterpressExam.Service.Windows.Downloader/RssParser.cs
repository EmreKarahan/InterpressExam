using System.ServiceModel.Syndication;
using InterpressExam.Data.Contract;
using InterpressExam.Entity;
using InterpressExam.Infrastructure.IoC;
using InterpressExam.Infrastructure.Parser;
using InterpressExam.Service.Windows.Downloader.ListenSrvRef;
using Quartz;

namespace InterpressExam.Service.Windows.Downloader
{
    public class RssParserService : IJob
    {
        private readonly IRssItemRepository _rssItemRepository;

        public RssParserService()
        {
            _rssItemRepository = ContainerManager.Container.Resolve<IRssItemRepository>();
        }

        public void GetFeed(RssFile file)
        {
            var rssFormatter = RssParser.GetFeed(file.AtomLink);
      
            file.LastUpdateDate = rssFormatter.LastUpdatedTime;
            file.Description = rssFormatter.Description.Text;
            file.Language = rssFormatter.Language;
            file.Title = rssFormatter.Title.Text;


            foreach (SyndicationItem item in rssFormatter.Items)
            {
                RssItem rssItem = new RssItem
                {
                    Title = item.Title.Text,
                    Description = item.Summary.Text,
                    PublishDate = item.PublishDate.DateTime,
                    RssFileId = file.Id,
                    Link = item.Id

                };
                _rssItemRepository.Add(rssItem);
            }           
            ListenServiceClient aa = new ListenServiceClient();
            aa.FireDatabaseEvents();

        }

        public void Execute(IJobExecutionContext context)
        {
            var files = _rssItemRepository.GetList();

            foreach (RssFile file in files)
            {
                GetFeed(file);
            }
        }
    }
}