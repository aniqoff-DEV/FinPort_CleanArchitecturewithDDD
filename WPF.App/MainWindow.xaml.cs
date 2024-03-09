using Application.Services;
using Domain.Abstractions;
using System.Windows;
using WPF.App.Pages;

namespace WPF.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NoteService noteService = new NoteService();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new NotePage(noteService));
            NavManager.MainFrame = MainFrame;
        }

        private void createReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void createTransaction_Click(object sender, RoutedEventArgs e)
        {

        }

        private void createNote_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(new NotePage());
        }
    }
}