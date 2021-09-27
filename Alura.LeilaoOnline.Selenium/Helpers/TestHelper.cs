using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public static class TestHelper
    {
        public static string PastaDoExecutavel => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
