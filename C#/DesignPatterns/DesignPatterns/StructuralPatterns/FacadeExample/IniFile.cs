namespace DesignPatterns.StructuralPatterns.FacadeExample
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public class IniFile
    {
        private string filePath;
        private const int MAX_BUFFER_SIZE = 1024;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def,
                                                            StringBuilder outValue, int size, string filePath);

        public IniFile(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                this.filePath = filePath;
            }
            else
            {
                throw new ArgumentNullException("A file name cannot be null or empty string.");
            }
        }

        public void WriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, this.filePath);
        }

        public string ReadValue(string section, string key)
        {
            StringBuilder stringBuilder = new StringBuilder(MAX_BUFFER_SIZE);
            int i = GetPrivateProfileString(section, key, string.Empty,
                                                stringBuilder, MAX_BUFFER_SIZE, this.filePath);
            return stringBuilder.ToString();
        }
    }
}
