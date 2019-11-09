using System;
using System.Collections.Generic;
using System.Text;

namespace OficinaMVVM.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }
    }
}
