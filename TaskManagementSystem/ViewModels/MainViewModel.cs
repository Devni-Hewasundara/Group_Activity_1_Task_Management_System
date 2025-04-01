using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly DatabaseModel _database;
        private TaskHelper _selectedTask;
        private ObservableCollection<TaskHelper> _tasks = new ObservableCollection<TaskHelper>();
        private string _taskName;
        private DateTime _taskDate = DateTime.Now;
        private TimeSpan _taskTime = DateTime.Now.TimeOfDay;

        // Properties with manual implementation
        public ObservableCollection<TaskHelper> Tasks
        {
            get => _tasks;
            set => SetProperty(ref _tasks, value);
        }

        public string TaskName
        {
            get => _taskName;
            set => SetProperty(ref _taskName, value);
        }

        public DateTime TaskDate
        {
            get => _taskDate;
            set => SetProperty(ref _taskDate, value);
        }

        public TimeSpan TaskTime
        {
            get => _taskTime;
            set => SetProperty(ref _taskTime, value);
        }

        public TaskHelper SelectedTask
        {
            get => _selectedTask;
            set
            {
                SetProperty(ref _selectedTask, value);
                if (value != null)
                {
                    TaskName = value.Name;
                    TaskDate = value.Date;
                    TaskTime = value.Time;
                }
            }
        }

        // Commands
        public IRelayCommand AddTaskCommand { get; }
        public IRelayCommand UpdateTaskCommand { get; }
        public IRelayCommand DeleteTaskCommand { get; }

        public MainViewModel()
        {
            _database = new DatabaseModel();
            LoadTasks();

            AddTaskCommand = new RelayCommand(AddTask);
            UpdateTaskCommand = new RelayCommand(UpdateTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask);
        }

        private void LoadTasks()
        {
            try
            {
                var tasks = _database.GetTasks();
                Tasks = new ObservableCollection<TaskHelper>(tasks);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tasks: {ex.Message}",
                    "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddTask()
        {
            if (string.IsNullOrWhiteSpace(TaskName))
            {
                MessageBox.Show("Please enter a task name",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var newTask = new TaskHelper
                {
                    Name = TaskName,
                    Date = TaskDate,
                    Time = TaskTime,
                    IsCompleted = false
                };

                _database.AddTask(newTask);
                LoadTasks();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding task: {ex.Message}",
                    "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateTask()
        {
            if (SelectedTask == null)
            {
                MessageBox.Show("Please select a task to update",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                SelectedTask.Name = TaskName;
                SelectedTask.Date = TaskDate;
                SelectedTask.Time = TaskTime;

                _database.UpdateTask(SelectedTask);
                LoadTasks();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating task: {ex.Message}",
                    "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteTask()
        {
            if (SelectedTask == null)
            {
                MessageBox.Show("Please select a task to delete",
                    "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                _database.DeleteTask(SelectedTask.Id);
                LoadTasks();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting task: {ex.Message}",
                    "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearFields()
        {
            TaskName = string.Empty;
            TaskDate = DateTime.Now;
            TaskTime = DateTime.Now.TimeOfDay;
            SelectedTask = null;
        }
    }
}
