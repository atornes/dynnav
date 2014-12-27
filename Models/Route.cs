using System.ComponentModel.DataAnnotations;

namespace DynNav.Models
{
    public class Route
    {
        public string Path { get; set; }
        public string ViewPath { get; set; }
        public string ControllerPath { get; set; }
    }
}