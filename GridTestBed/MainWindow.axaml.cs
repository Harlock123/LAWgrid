using Avalonia.Controls;

namespace GridTestBed;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        TheGridInTest.TestPopulate();
    }
}