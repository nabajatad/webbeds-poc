namespace WebBeds.Utility
{
    public interface ILogger
    {
        /// <summary>
        /// Write error log by LogInput
        /// </summary>
        /// <param name="LogInput"></param>
        void WriteErrorLog(string logInput);
    }
}
