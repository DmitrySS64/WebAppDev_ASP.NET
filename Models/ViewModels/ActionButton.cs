using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LW_1.Models.ViewModels
{
    public enum ERole
    {
        cashier = 1,
        manager = 2,
        admin = 3
    }
    public class ActionButton
    {
        public string Text { get; set; }
        public string Method { get; set; }
        public string Controller { get; set; }
        public List<ERole> Roles { get; set; } = new List<ERole> { ERole.admin };
        public object Parameters { get; set; }
    }
}