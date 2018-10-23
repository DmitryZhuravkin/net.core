using System;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.BuiltIn.Tag.Helpers.Components
{
    public class TimeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View(DateTime.Now);
    }
}