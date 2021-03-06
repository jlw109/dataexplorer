﻿using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Persistence.Filters.Serializers
{
    public interface IFilterSerializer
    {
        XElement Serialize(Filter filter);

        Filter Deserialize(XElement xFilter, List<Column> columns);
    }
}
