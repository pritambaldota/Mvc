// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.Routing.Template;

namespace MvcSample.Web.Controllers
{
    public class ActionListController : Controller
    {
        private readonly IActionDescriptorsCollectionProvider _actionDescriptorsCollectionProvider;

        public ActionListController(IActionDescriptorsCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorsCollectionProvider = actionDescriptorCollectionProvider;
        }

        public IActionResult Index()
        {
            var actions = _actionDescriptorsCollectionProvider.ActionDescriptors.Items;

            var templateRoutes = new List<string>();
            var routeCollection = ActionContext.RouteData.Routers[0] as RouteCollection;
            if (routeCollection != null)
            {
                for (var i = 0; i < routeCollection.Count; i++)
                {
                    var route = routeCollection[i] as TemplateRoute;
                    if (route != null)
                    {
                        templateRoutes.Add(route.RouteTemplate);
                    }
                }
            }

            var entries = new List<ActionListEntry>();
            foreach (var action in actions)
            {
                var entry = new ActionListEntry(action);
                entries.Add(entry);

                if (action.AttributeRouteInfo?.Template == null)
                {
                    entry.Routes.AddRange(templateRoutes);
                }
                else
                {
                    entry.Routes.Add(action.AttributeRouteInfo.Template);
                }
            }

            return View(entries);
        }
    }
}
