using System.Windows;
using System.Windows.Input;


namespace SpaceShooter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool Alreadystartet = false;

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!Alreadystartet)
            {
                Global.SpaceCanvas = SpaceCanvas;
                Global.TextBlockLeben = TextBlockLeben;
                Global.TextBlockScore = TextBlockScore;
                GameManager.Initialize();
                Alreadystartet = true;
            }
            Global.LastButton = e.Key;
        }
    }
}
