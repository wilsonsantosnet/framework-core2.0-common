using Common.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Model
{
    public class Tool
    {
        public Tool()
        {
            this.CanWrite = true;
            this.CanRead = true;
            this.CanDelete = true;
        }

        public string Name { get; set; }
        public string Icon { get; set; }
        public string Route { get; set; }
        public string Key { get; set; }
        public string ParentKey { get; set; }
        public ETypeTools Type { get; set; }
        public Boolean CanWrite { get; set; }
        public Boolean CanRead { get; set; }
        public Boolean CanDelete { get; set; }

    }
}
