using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading;
using System.Xml;
using InterpressExam.Entity;
using InterpressExam.Infrastructure.Parser;
using InterpressExam.Service.Windows.Downloader.ListenSrvRef;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using Quartz.Job;

namespace InterpressExam.Service.Windows.Downloader
{
    public class RssParserService : IJob
    {
        private readonly RssContext Entities = new RssContext();

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
                Entities.RssItem.Add(rssItem);
            }
            Entities.SaveChanges();
            ListenServiceClient aa = new ListenServiceClient();
            aa.FireDatabaseEvents();

        }

        public void Execute(IJobExecutionContext context)
        {
            var files = Entities.RssFile.ToList();

            foreach (RssFile file in files)
            {
                GetFeed(file);
            }
        }
    }
}