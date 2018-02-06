using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult DebugDemo()
        {
            ViewBag.Message = "Hello, World";
            ViewBag.Time = DateTime.Now.ToString("HH:mm:ss");
            return View("DebugData");
        }

        public ViewResult List() => View();

        // this method will call a result located in the razor view engine
        //razar parses the view into a class; the name is a string representation of the path and is derived from the RazorPage class or RazorPage<T> class if a @model T has been provided
        //properties are filled with info about the view and content, as well as properties that generate content. @Model is used to access the data in the object
        //the ExecuteAsync() method of the view class parses the actual html content into a series off WriteLiteral and Write methods.
        //all of the data is compiled into the C# class, then when instantiated -- builds the display
        public ViewResult Index() => View(new string[] { "Apple", "Orange", "Pear" });

        //sends an object to view, that is serialized to Json and rendered by Jquery
        public ViewResult JsonDemo() => View(new string[] { "Apple", "Orange", "Pear" });
    }
}
