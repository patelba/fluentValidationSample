using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.FluentLibrary
{
    public class Parcel
    {
        public string OrderNumber { get; set; }
        public string Description { get; set; }
        public string NodeType { get; set; }
        public int NodeId { get; set; }
        public string NodeName { get; set; }
        public Address Address { get; set; }
    }
}
