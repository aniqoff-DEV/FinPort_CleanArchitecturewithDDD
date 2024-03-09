using Domain.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace WPF.App.Pages
{
    /// <summary>
    /// Логика взаимодействия для NotePage.xaml
    /// </summary>
    public partial class NotePage : Page
    {
        private readonly INoteService noteService;

        public NotePage(INoteService noteService)
        {
            InitializeComponent();
            this.noteService = noteService;
        }

        private async void createNote_Click(object sender, RoutedEventArgs e)
        {
            string typeOperationNote = typeOfOperation.SelectedItem as string;
            Guid transationNoteId = transationType.SelectedItem as Guid;
            string descriptionNote = description.Text;
            decimal costNote = decimal.Parse( cost.Text);

            await noteService.Insert(
                typeOperationNote,
                transationNoteId,
                descriptionNote,
                costNote,
                DateTime.Now);
        }
    }
}
