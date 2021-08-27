using Contracts;
using DTO;
using System;
using System.Collections.Generic;
using System.Xml;

namespace GetData
{
    public class RSS : IRSS
    {
        private List<Report> _news;
 
        public List<Report> News
        {
            get 
            {
                if (_news == null)
                    SetNews();
                return _news;
            }
        }
        public void SetNews()
        {
            try
            {
                setNews();
            }
            catch
            {
                _news = null;
            }
        }
        public void setNews()
        {
            string url = @"https://www.google.com/alerts/feeds/13583186640397089815/5906306061878099971";
            XmlTextReader reader = new XmlTextReader(url);
            _news = new List<Report>();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "entry")
                {
                    var toAdd = new Report();
                    goToElement(reader, "title");
                    toAdd.Title = replace(reader.ReadContentAsString());
                    goToElement(reader, "link");
                    toAdd.Link = reader.GetAttribute("href");
                    goToElement(reader, "updated");
                    toAdd.Updated = reader.Value.Replace('Z',' ').Replace('T',' ');
                    goToElement(reader, "content");
                    toAdd.Content = replace(reader.ReadContentAsString());
                    _news.Add(toAdd);
                }
            }
        }
        private void goToElement(XmlTextReader reader, String name)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == name)
                {
                    break;
                }
            }
            if (!name.Equals("link"))
                reader.ReadStartElement(name);
        }
        private string replace(string v)
        {
            string retval = "";
            int length = v.Length;
            for (int i=0;i<v.Length; i++)
            {
                if (i + 3 < length && v.Substring(i, 3).Equals("<b>"))
                    i += 2;
                else if (i + 4 < length && v.Substring(i, 4).Equals("</b>"))
                    i += 3;
                else if (i + 5 < length && v.Substring(i, 5).Equals("&#38;"))
                {
                    i += 4;
                    retval = retval + '&';
                }
                else if (i + 5 < length && v.Substring(i, 5).Equals("&#39;"))
                {
                    i += 4;
                    retval = retval + '\'';
                }
                else if (i + 6 < length && v.Substring(i, 6).Equals("&quot;"))
                {
                    i += 5;
                    retval = retval + '\"';
                }
                else if (i + 5 < length && v.Substring(i, 5).Equals("&#34;") )
                {
                    i += 4;
                    retval = retval + '\"';
                }
                else if (i + 6 < length && v.Substring(i, 6).Equals("&nbsp;"))
                    i += 5;
                else
                    retval = retval + v[i];
            }
            return retval;
        }
    }
}
