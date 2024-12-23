using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Text;
using System.Xml;

namespace UIFrameworkLayer.Utilities
{
    public static class Helper
    {
        public static string RandomString(int size = 6)
        {
            string str = "abcdefghijklmnopqrstuvwxyz";
            string ran = string.Empty;
            for (int i = 0; i < size; i++)
                ran = ran + str[new Random().Next(26)];
            return ran;
        }

        public static List<string> ReadDataFromTextFile()
        {
            string readContents;
            using (StreamReader streamReader = new StreamReader(@"C:\Users\ashokreddy_kesari\Desktop\Test.txt", Encoding.UTF8))
            {
                readContents = streamReader.ReadToEnd();
            }

            return readContents.Split("\r\n").ToList();
        }

        public static void GetUsernameAndPasswordFromXMl(out string? username, out string? password)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\Ashok\Desktop\Test.xml");

            username = string.Empty;
            password = string.Empty;

            if (xDoc.DocumentElement != null)
            {
                foreach (XmlNode node in xDoc.DocumentElement.ChildNodes)
                {
                    username = node.FirstChild?.InnerText;
                    password = node.LastChild?.InnerText;
                }
            }
            else
            {
                throw new InvalidOperationException("The XML document is null or does not have a root element.");
            }

        }

        public static string GetDataFromJsonFile(string Key)
        {
            var settings = new ConfigurationBuilder()
                            .AddJsonFile("AppSettings.json")
                            .Build();
            return settings[Key];
        }

        public static double ConvertStringToDouble(string price)
        {
            string costprice = price.Split("$")[1];

            if (double.TryParse(costprice, NumberStyles.Currency, CultureInfo.InvariantCulture, out double costPriceVal))
            {
                return costPriceVal;
            }
            else
            {
                throw new FormatException("Numeric part of the price string could not be converted to a double.");
            }


        }


    }
}

