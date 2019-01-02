using System;
using System.Collections.Generic;
using System.Text;

namespace Nomoni.Examples.Basic.Shared
{
    public class MenuItem
    {
        public string Name { get; }
        public string Url { get; }
        public int Position { get; }
       
        public MenuItem(string name, int position, string url)
        {
            this.Name = name;
            this.Position = position;
            this.Url = url;
        }
    }
}
