﻿using DataExplorer.Application.Clipboard;
using DataExplorer.Application.Rows;
using DataExplorer.Presentation.Shell.MainMenu.EditMenu;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Shell.MainMenu.EditMenu
{
    [TestFixture]
    public class EditMenuViewModelTests
    {
        private EditMenuViewModel _viewModel;
        private Mock<IClipboardService> _mockClipboard;

        [SetUp]
        public void SetUp()
        {
            _mockClipboard = new Mock<IClipboardService>();

            _viewModel = new EditMenuViewModel(_mockClipboard.Object);
        }

        [Test]
        public void TestExecuteCopyCommandShouldCopy()
        {
            _viewModel.CopyCommand.Execute(null);
            _mockClipboard.Verify(p => p.Copy(), Times.Once());
        }

        [Test]
        public void TestExecuteCopyImageShouldCopyImage()
        {
            _viewModel.CopyImageCommand.Execute(null);
            _mockClipboard.Verify(p => p.CopyImage(), Times.Once());
        }

        [Test]
        public void TestHandleSelectedRowsChangedShouldRaiseCanCopyChangedEvent()
        {
            var wasRaised = false;
            _viewModel.CopyCommand.CanExecuteChanged += (s, e) => wasRaised = true;
            _viewModel.Handle(new SelectedRowsChangedEvent());
            Assert.That(wasRaised, Is.True);
        }
    }
}