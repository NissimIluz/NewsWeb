using Contracts;
using DTO;
using GetData;
using NUnit.Framework;
using System.Net.NetworkInformation;
using System.Xml;

namespace TestProject1
{
    public class Tests
    {
        IRSS _rss;
        string _url = @"https://www.google.com/alerts/feeds/13583186640397089815/5906306061878099971";

        [SetUp]
        public void Setup()
        {
            _rss = new RSS();
        }

        [Test]
        public void Test1()
        {

            try //check if there is internet connection
            {
                /*this piece of code I took from stackoverflow
                 * https://stackoverflow.com/questions/2031824/what-is-the-best-way-to-check-for-internet-connectivity-using-net
                 * */
                Ping myPing = new Ping();
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send("google.com", timeout, buffer, pingOptions);
                Assert.IsNotNull(_rss.News);
            }
            catch
            {
                Assert.IsNull(_rss.News);
            }

        }
        [Test]
        public void Test2()
        {
            if (_rss.News == null)
                Assert.Pass();
            else
            {
                XmlTextReader reader = new XmlTextReader(_url);
                int count = 0;
                while (reader.ReadToFollowing("entry"))
                {
                    count++;
                }
                Assert.AreEqual(count, _rss.News.Count);
            }
        }
        [Test]
        public void Test3()
        {
            if (_rss.News == null)
                Assert.Pass();
            else
            {
                var list = _rss.News;
                foreach (Report report in list)
                {
                    Assert.IsNotNull(report.Content);
                    Assert.IsNotNull(report.Link);
                    Assert.IsNotNull(report.Title);
                    Assert.IsNotNull(report.Updated);

                    Assert.IsTrue(report.Content.Length>0);
                    Assert.IsTrue(report.Link.Length > 0);
                    Assert.IsTrue(report.Title.Length > 0);
                    Assert.IsTrue(report.Updated.Length > 0);
                }
            }
        }
    }
}