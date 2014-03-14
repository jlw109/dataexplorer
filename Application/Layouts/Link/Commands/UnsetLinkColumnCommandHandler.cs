﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Link.Commands
{
    public class UnsetLinkColumnCommandHandler
        : ICommandHandler<UnsetLinkColumnCommand>
    {
        private readonly IViewRepository _viewRepository;
        private readonly IEventBus _eventBus;

        public UnsetLinkColumnCommandHandler(
            IViewRepository viewRepository,
            IEventBus eventBus)
        {
            _viewRepository = viewRepository;
            _eventBus = eventBus;
        }

        public void Execute(UnsetLinkColumnCommand command)
        {
            var scatterPlot = _viewRepository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            layout.LinkColumn = null;

            _eventBus.Raise(new LayoutChangedEvent());
        }
    }
}