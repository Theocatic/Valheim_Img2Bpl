namespace Valheim_Image_Converter
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        static Form1 formRef;
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            formRef = new Form1();
            Application.Run(formRef);
          
        }

        public static void ThrowError(String error, ErrorLocation location)
        {
            formRef.ThrowError(error, location);
        }
    }
}