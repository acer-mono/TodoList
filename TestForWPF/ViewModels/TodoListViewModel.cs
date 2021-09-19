using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using TestForWPF.Annotations;
using TestForWPF.Models;
using TestForWPF.ViewModels.Commands;

namespace TestForWPF.ViewModels
{
    internal sealed class TodoListViewModel : INotifyPropertyChanged
    {
        private TodoItem? _selectedItem;

        public TodoListViewModel()
        {
            Todos = new ObservableCollection<TodoItem>
            {
                new("First", "First description")
            };

            RemoveTodo = new RelayCommand(todo =>
            {
                if (todo is TodoItem item)
                {
                    Todos.Remove(item);
                }
            });

            AddTodo = new RelayCommand(o =>
                {
                    if (o is not string title)
                    {
                        return;
                    }

                    var newTodo = new TodoItem(title);
                    Todos.Add(newTodo);
                },
                o => o is string title && !string.IsNullOrEmpty(title));
        }

        public ObservableCollection<TodoItem> Todos { get; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public TodoItem? SelectedTodo
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedTodo));
                OnPropertyChanged(nameof(ShowEditBlock));
            }
        }

        public bool ShowEditBlock => _selectedItem is not null;

        public RelayCommand RemoveTodo { get; }

        public RelayCommand AddTodo { get; }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}