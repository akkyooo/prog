using System.Windows;

namespace lb6.Main
{
    public static class Launcher
    {
        public static void Run()
        {
            Main.MainWindow window = new Main.MainWindow();
            Application.Current.MainWindow = window;
            window.Show();
        }
    }
}