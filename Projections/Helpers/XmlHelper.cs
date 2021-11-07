using Projections.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;

namespace Projections.Helpers
{
    public class XmlHelper : IXmlHelper
    {
        private readonly IConfiguration _configuration;

        public XmlHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<T> DeserializeXml<T>(string xmlString)
        {
            List<T> result = new List<T>();
            string dataNodeName = _configuration["XmlDataNode"];

            using (var stringReader = new StringReader(xmlString))
            {

                using (XmlReader xmlReader = XmlReader.Create(stringReader))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));

                    while (!xmlReader.EOF)
                    {
                        if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == dataNodeName)
                        {
                            var element = (T)xmlSerializer.Deserialize(xmlReader);
                            result.Add(element);
                        }
                        else
                        {
                            xmlReader.Read();
                        }
                    }
                }
            }

            return result;
        }

    }
}
