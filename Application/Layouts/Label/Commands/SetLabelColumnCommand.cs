﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Layouts.Label.Commands
{
    public class SetLabelColumnCommand : EntityIdCommand
    {
        public SetLabelColumnCommand(int id) : base(id)
        {
            
        }
    }
}
