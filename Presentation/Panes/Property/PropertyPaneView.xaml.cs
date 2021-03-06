﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataExplorer.Presentation.Panes.Property
{
    /// <summary>
    /// Interaction logic for PropertyPane.xaml
    /// </summary>
    public partial class PropertyPane : UserControl
    {
        public PropertyPane()
        {
            InitializeComponent();
        }

        private void HandleLinkClick(object sender, RoutedEventArgs e)
        {
            var button = (Button) e.Source;

            var viewModel = (IPropertyViewModel) button.DataContext;

            viewModel.HandleLinkClick();
        }
    }
}
