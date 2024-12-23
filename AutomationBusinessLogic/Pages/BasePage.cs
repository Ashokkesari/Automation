using log4net;
using System.Reflection;


namespace UIBusinessLayer.Pages
{
    public class BasePage
    {
        public static ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

    }
}
