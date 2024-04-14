using laba_1.models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;


namespace laba_1.ViewModel

{
    internal class SetVM : BindableBase
    {
        #region Fields
        private String _newItem;
        private String _deleteItem;
        private String _itemToCheck;
        private String _containsResult;
        #endregion

        #region Commands
        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand RemoveCommand { get; private set; }
        public DelegateCommand CheckCommand { get; private set; }
        public DelegateCommand ClearCommand { get; private set; }
        public Set<string> Items { get; private set; } = new Set<string>();
        #endregion

        #region Constructors
        public SetVM()
        {
            AddCommand = new DelegateCommand(AddItem);
            RemoveCommand = new DelegateCommand(RemoveItem);
            CheckCommand = new DelegateCommand(CheckItem);
            ClearCommand = new DelegateCommand(ClearSet);
        }
        #endregion

        #region Private Realisation
        private void AddItem()
        {
            if (_newItem == "")
            {
                MessageBox.Show("You trying to add an empty element", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Items.Add(_newItem);
        }

        private void RemoveItem()
        {
            if (_deleteItem == "")
            {
                MessageBox.Show("You trying to delete an empty element", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Items.Remove(_deleteItem);
        }

        private void ClearSet()
        {
            Items.Clear();
        }
        private void CheckItem()
        {
            if (_itemToCheck == "")
            {
                MessageBox.Show("You trying to check an empty element", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (Items.Contains(_itemToCheck))
            {
                ContainsResult = $"Элемент {_itemToCheck} есть в Set";
            }
            else
            {
                ContainsResult = $"Элемента {_itemToCheck} нет в Set";
            }
        }
        #endregion

        #region Properties
        public string NewItem
        {
            get => _newItem;
            set => SetProperty(ref _newItem, value);

        }
        public string DeleteItem
        {
            get => _deleteItem;
            set => SetProperty(ref _deleteItem, value);

        }
        public string ItemToCheck
        {
            get => _itemToCheck;
            set => SetProperty(ref _itemToCheck, value);

        }
        public string ContainsResult
        {
            get => _containsResult;
            set => SetProperty(ref _containsResult, value);
        }
        #endregion

    }
}
