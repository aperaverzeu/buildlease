using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buildlease.Views
{
    public class CaregoryView
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }
    }
}
