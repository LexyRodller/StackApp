using StackApp.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StackApp.ViewModels
{
    public class StackViewModel : INotifyPropertyChanged
    {
        private Stack<string> stack;

        public StackViewModel()
        {
            stack = new StackApp.Models.Stack<string>();
        }

        public string? CurrentItem => stack.Count > 0 ? stack.CurrentItem : null; 

        public int Count => stack.Count;
        public bool IsEmpty => stack.IsEmpty;

        public void Push(string item)
        {
            stack.Push(item);
            OnPropertyChanged(nameof(CurrentItem));
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(IsEmpty));
        }

        public string Pop()
        {
            string item = stack.Pop();
            OnPropertyChanged(nameof(CurrentItem));
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(IsEmpty));
            return item;
        }

        public void Clear()
        {
            stack.Clear();
            OnPropertyChanged(nameof(CurrentItem));
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(IsEmpty));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}