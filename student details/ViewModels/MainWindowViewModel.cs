using student_details.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace student_details.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Student> Students { get; } = new(
            Enumerable.Range(1, 10)
                .Select((n) => new Student($"Student {n}", $"student{n}@example.com", $"#{n}"))
        );


        public MainWindowViewModel()
        {
            SaveCmd = new SaveCommand(this);
        }

        public SaveCommand SaveCmd { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private Student? _SelectedStudent = null;

        public Student? SelectedStudent
        {
            get { return _SelectedStudent; }
            set
            {
                _SelectedStudent = value;
                Debug.WriteLine("Setter of SelectedStudent invoked");

                if (_SelectedStudent != null)
                {
                    StudentName = _SelectedStudent.Name;
                    StudentEmail = _SelectedStudent.Email;
                    ContactNumber = _SelectedStudent.ContactNumber;

                }
            }
        }

        private string _StudentName = String.Empty;
        public string StudentName
        {
            get { return _StudentName; }
            set 
            {
                _StudentName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StudentName"));
            }
        }

        private string _ContactNumber = String.Empty;
        public string ContactNumber
        {
            get { return _ContactNumber; }
            set
            {
                _ContactNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ContactNumber"));
            }
        }

        private string _Email = String.Empty;
        public string StudentEmail
        {
            get { return _Email; }
            set
            {
                _Email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StudentEmail"));
            }
        }
    }
    public class SaveCommand : ICommand
    {
        private readonly MainWindowViewModel vm;

        public SaveCommand(MainWindowViewModel vm)
        {
            this.vm = vm;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            // Create a Student object from the view model properties.
            var student = new Student(vm.StudentName, vm.ContactNumber, vm.StudentEmail);

            // Store a list of student models somewhere in the ViewModel.
            vm.Students.Add(student);   

            MessageBox.Show($"Done saving, {student}");
        }
    }
}
