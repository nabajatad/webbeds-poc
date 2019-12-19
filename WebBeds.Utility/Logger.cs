namespace WebBeds.Utility
{
    using System;
    using System.IO;

    public class Logger : ILogger
    {
        /// <summary>
        /// Write error log by LogInput
        /// </summary>
        /// <param name="logInput"></param>
        public void WriteErrorLog(string logInput)
        {
            var path = Directory.GetCurrentDirectory();
            var filepath = path + "\\wwwroot\\ErrorLog\\";
            var filename = $"APIRequestJson_{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt";
            using (var sw = new StreamWriter(filepath + filename))
            {
                sw.WriteLine(logInput);

                sw.Close();
            }
        }
    }
}
