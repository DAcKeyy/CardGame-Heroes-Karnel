using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_Heroes.Kernel.Systems
{
    public class HandSystemFlyoutMenuItem
    {
        public HandSystemFlyoutMenuItem()
        {
            TargetType = typeof(HandSystemFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}