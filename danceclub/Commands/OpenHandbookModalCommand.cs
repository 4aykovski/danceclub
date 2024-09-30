using danceclub.Models;
using danceclub.Stores;
using danceclub.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace danceclub.Commands
{
    public class OpenHandbookModalCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly HandbookViewModel _handbookViewModel;
        private readonly DataContext _context; 

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(HandbookViewModel.SelectedHandbook))
            {
                OnCanExecuteChanged();
            }
        }

        public OpenHandbookModalCommand(ModalNavigationStore modalNavigationStore, HandbookViewModel handbookViewModel, DataContext context)
        {
            _modalNavigationStore = modalNavigationStore;
            _handbookViewModel = handbookViewModel;
            _context = context;

            _handbookViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_handbookViewModel.SelectedHandbook) &&
                base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            string selectedHandbook = _handbookViewModel.SelectedHandbook;

            if (string.IsNullOrEmpty(selectedHandbook))
            {
                MessageBox.Show("select handbook", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ViewModelBase currentModal;

            switch (selectedHandbook)
            {
                case "Teacher":
                    {
                        currentModal = new AddTeacherViewModel(_modalNavigationStore, _context);

                        break;
                    }
                case "DanceType":
                    {
                        currentModal = new AddDanceTypeViewModel(_modalNavigationStore, _context);

                        break;
                    }
                case "GroupDanceType":
                    {
                        currentModal = new AddGroupDanceTypeViewModel(_modalNavigationStore, _context);

                        break;
                    }
                case "Groups":
                    {
                        currentModal = new AddGroupsViewModel(_modalNavigationStore, _context);

                        break;
                    }
                case "GroupStudent":
                    {
                        currentModal = new AddGroupsStudentViewModel(_modalNavigationStore, _context);

                        break;
                    }
                case "Schedule":
                    {
                        currentModal = new AddScheduleViewModel(_modalNavigationStore, _context);

                        break;
                    }
                case "Students":
                    {
                        currentModal = new AddStudentsViewModel(_modalNavigationStore, _context);

                        break;
                    }
                case "StudentSchedule":
                    {
                        currentModal = new AddStudentScheduleViewModel(_modalNavigationStore, _context);

                        break;
                    }
                default:
                    MessageBox.Show("wrong handbook", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }

            _modalNavigationStore.CurrentViewModel = currentModal;

        }

        }
    }
