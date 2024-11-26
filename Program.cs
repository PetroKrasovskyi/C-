namespace Fifteen
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            BL bl = new BL(4);

            Stats stats = new Stats(bl);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            MainForm main = new MainForm(bl, stats);

            Application.Run(main);
        }
    }
}