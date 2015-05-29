// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.AspNet.Mvc;

namespace MvcSample.Web
{
    public class ActionListEntry
    {
        public ActionListEntry(ActionDescriptor action)
        {
            Action = action;

            Routes = new List<string>();
        }

        public ActionDescriptor Action { get; }

        public List<string> Routes { get; }
    }
}
