using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using FilterListDemo.Annotations;
using FilterListDemo.Model;

namespace FilterListDemo.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> _usersList;

        public ObservableCollection<User> UsersList
        {
            get { return _usersList; }
            set
            {
                _usersList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<User> _usersFilterList;

        public ObservableCollection<User> UsersFilterList
        {
            get { return _usersFilterList; }
            set
            {
                _usersFilterList = value;
                OnPropertyChanged();
            }
        }

        private string _searchText = string.Empty;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterUsers();
            }
        }

        public MainPageViewModel()
        {
            Init();
        }

        private void Init()
        {
            UsersList = new ObservableCollection<User>()
            {
                new User()
                {
                    Id = 1,
                    Name = "Maciek"
                },

                new User()
                {
                    Id = 2,
                    Name = "Dawid"
                },
                new User()
                {
                    Id = 3,
                    Name = "Robert"
                },
                new User()
                {
                    Id = 4,
                    Name = "Karol"
                },
                new User()
                {
                    Id = 5,
                    Name = "Piotrek"
                },
            };

            UsersFilterList = new ObservableCollection<User>(UsersList);
        }

        private void FilterUsers()
        {
            if (UsersList != null)
            {
                if (string.IsNullOrEmpty(_searchText))
                {
                    Init();
                }

                else
                {
                    var filterUsers = UsersList.Where(x =>
                            x.Id.ToString().Equals(_searchText) || x.Name.ToLower().Contains(_searchText.ToLower()))
                        .ToList();

                    UsersFilterList = new ObservableCollection<User>(filterUsers);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}