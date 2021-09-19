using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestForWPF.Annotations;

namespace TestForWPF.Models
{
    internal sealed class TodoItem : INotifyPropertyChanged
    {
        private string _title;
        private string? _description;

        public TodoItem(string title, string? description = null)
        {
            _title = title;
            _description = description;
            Id = GenerateId();
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string? Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Id { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}