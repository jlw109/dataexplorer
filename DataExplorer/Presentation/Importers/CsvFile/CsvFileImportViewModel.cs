﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Application.Importers.CsvFile;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Events;
using DataExplorer.Presentation.Dialogs;

namespace DataExplorer.Presentation.Importers.CsvFile
{
    public class CsvFileImportViewModel : BaseViewModel, ICsvFileImportViewModel
    {
        private const string FileFilter = "CSV documents|*.csv";
        private const string DefaultFileExtension = ".csv";

        private readonly ICsvFileImportService _service;
        private readonly IDialogFactory _dialogFactory;
        private readonly DelegateCommand _browseCommand;
        private readonly DelegateCommand _importCommand;
        private readonly DelegateCommand _cancelCommand;
        
        public event DialogClosedEvent DialogClosed;

        public string FilePath
        {
            get { return _service.GetFilePath(); }
            set { _service.SetFilePath(value);}
        }

        public CsvFileImportViewModel(
            ICsvFileImportService service,
            IDialogFactory dialogFactory)
        {
            _service = service;
            _dialogFactory = dialogFactory;
            _browseCommand = new DelegateCommand(Browse);
            _importCommand = new DelegateCommand(Import, CanImport);
            _cancelCommand = new DelegateCommand(Cancel);

            _service.FilePathChanged += HandleFilePathChanged;
            _service.DataImported += HandleDataImported;
        }

        public ICommand BrowseCommand
        {
            get { return _browseCommand; }
        }

        public ICommand ImportCommand
        {
            get { return _importCommand; }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
        }

        private void Browse(object parameter)
        {
            var dialog = _dialogFactory.CreateOpenFileDialog();
            dialog.SetDefaultExtension(DefaultFileExtension);
            dialog.SetFilter(FileFilter);
            var result = dialog.ShowDialog();

            if (result == true)
                _service.SetFilePath(dialog.GetFilePath());
        }

        private bool CanImport(object parameter)
        {
            return _service.CanImport();
        }

        private void Import(object obj)
        {
            _service.Import();
        }

        private void Cancel(object obj)
        {
            if (DialogClosed != null)
                DialogClosed(this, EventArgs.Empty);
        }

        private void HandleFilePathChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(() => FilePath);
            _importCommand.RaiseCanExecuteChanged();
        }

        private void HandleDataImported(object sender, EventArgs e)
        {
            if (DialogClosed != null)
                DialogClosed(this, EventArgs.Empty);
        }
    }
}
