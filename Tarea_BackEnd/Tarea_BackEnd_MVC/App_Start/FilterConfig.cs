﻿using System.Web;
using System.Web.Mvc;

namespace Tarea_BackEnd_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
