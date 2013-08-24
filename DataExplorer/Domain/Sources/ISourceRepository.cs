﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Sources
{
    public interface ISourceRepository
    {
        T GetSource<T>() where T : ISource;
        void SetSource<T>(T source) where T : ISource;
        bool HasSource<T>() where T : ISource;
    }
}