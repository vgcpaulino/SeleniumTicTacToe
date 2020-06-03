using System.IO;
using System.Reflection;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace TicTacToe
{
    public class DriverSetUp
    {
        // Set the Path where the binaries will be downloaded "bin\Debug\netcoreapp3.1";
        private static string PathExe => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        // ############ CHROME
        private readonly string chromeVersion = "83.0.4103.39";
        public string ChromeDriverFolder => PathExe + $"\\Chrome\\{chromeVersion}\\X64";
        private string ChromeBinaryPath => $"{ChromeDriverFolder}\\chromedriver.exe";

        // ############ FIREFOX
        private readonly string firefoxVersion = "0.26.0"; // GeckoDriver version;
        public string FirefoxDriverFolder => PathExe + $"\\Firefox\\{firefoxVersion}\\X64";
        private string FirefoxBinaryPath => $"{FirefoxDriverFolder}\\geckodriver.exe";


        // This method uses the WebDriverManager package to download the browser drivers;
        // DOC: https://github.com/rosolko/WebDriverManager.Net#usage
        public void SetUpDrivers()
        {
            // To avoid download the driver every execution;
            if (!Directory.Exists(ChromeDriverFolder) || !File.Exists(ChromeBinaryPath))
            {
                new DriverManager().SetUpDriver(new ChromeConfig(), chromeVersion, Architecture.X64);
            }

            // To avoid download the driver every execution;
            if (!Directory.Exists(FirefoxDriverFolder) || !File.Exists(FirefoxBinaryPath))
            {
                new DriverManager().SetUpDriver(new FirefoxConfig(), firefoxVersion, Architecture.X64);
            }
        }
    }
}