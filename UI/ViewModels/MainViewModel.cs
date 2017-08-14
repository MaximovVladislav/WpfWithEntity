using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;
using Services.Messaging;
using Services.UserData;
using UI.Commands;
using UI.ViewModels.Base;

namespace UI.ViewModels
{
    /// <summary>
    /// Главная модель представления
    /// </summary>
    public class MainViewModel : LazyInitializableViewModel, IEditable<User>
    {
        private readonly IUserDataService _userDataService;

        private ICommand _editUserCommand;
        private ICommand _addUserCommand;
        private ICommand _refreshCommand;
        private ICommand _removeUserCommand;

        private ObservableCollection<User> _users;
        private User _selectedUser;

        public MainViewModel(IMessenger messenger, IUserDataService userDataService) : base(messenger)
        {
            _userDataService = userDataService;
        }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { Set(ref _users, value); }
        }

        public User SelectedUser
        {
            get { return _selectedUser; }
            set { Set(ref _selectedUser, value); }
        }

        public ICommand EditUserCommand
        {
            get { return _editUserCommand ?? (_editUserCommand = new RelayCommand(x => Edit(x as User))); }
        }

        public ICommand AddUserCommand
        {
            get { return _addUserCommand ?? (_addUserCommand = new RelayCommand(x => AddUser())); }
        }

        public ICommand RefreshCommand
        {
            get { return _refreshCommand ?? (_refreshCommand = new RelayCommand(async x => await Go(RefreshAsync))); }
        }

        public ICommand RemoveUserCommand
        {
            get
            {
                return _removeUserCommand ??
                       (_removeUserCommand = new RelayCommand(x => RemoveUser(), y => SelectedUser != null));
            }
        }

        protected override async Task RefreshAsync()
        {
            var users = await Go(() => _userDataService.GetUsersAsync());

            Users = new ObservableCollection<User>(users);
        }

        public async void Edit(User user)
        {
            if (user == null) return;

            await Go(() => _userDataService.UpdateUser(user), "Сохранение...");
        }

        private async void AddUser()
        {
            Users.Add(await Go(() => _userDataService.CreateUser(), "Сохранение..."));
        }

        private async void RemoveUser()
        {
            var user = SelectedUser;

            bool result = await Go(() => _userDataService.DeleteUser(SelectedUser), "Удаление...");

            if (result) Users.Remove(user);
        }
    }
}