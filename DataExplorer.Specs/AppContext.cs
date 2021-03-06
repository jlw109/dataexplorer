﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Logs;
using DataExplorer.Application.Projects;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Infrastructure.Importers.CsvFile;
using DataExplorer.Presentation.Importers.CsvFile;
using DataExplorer.Presentation.Shell.MainMenu.FileMenu;
using DataExplorer.Presentation.Shell.MainWindow;
using DataExplorer.Specs.Importers;
using Moq;

namespace DataExplorer.Specs
{
    public class AppContext
    {
        public MainWindowViewModel MainWindowViewModel;
        public ICsvFileImportViewModel CsvFileImportViewModel;
        public IFileMenuViewModel FileMenuViewModel;

        public Mock<IApplication> MockApplication;
        public Mock<IDialogService> MockDialogService;
        public Mock<IXmlFileService> MockXmlFileService;
        public Mock<ICsvFileParser> MockCsvFileParser;
        public Mock<ILogFolder> MockLogFolder;
        public Mock<ILogFile> MockLogFile;

        public XElement XProject;
        public Project Project;
        public CsvFileSource CsvFileSource;
        public Column Column;
        public Row Row;
        public Filter Filter;
        public ScatterPlot ScatterPlot;

        public FakeCsvFile FakeCsvFile;

        public IDataContext DataContext;
    }
}
