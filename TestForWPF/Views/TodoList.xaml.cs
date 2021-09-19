using System.Windows.Controls;
using TestForWPF.ViewModels;

namespace TestForWPF.Views
{
    /// <summary>
    /// Interaction logic for TodoList.xaml
    /// </summary>
    public partial class TodoList : UserControl
    {
        public TodoList()
        {
            InitializeComponent();
            DataContext = new TodoListViewModel();
        }
    }
}
