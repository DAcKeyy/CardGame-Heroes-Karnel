using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_Heroes.Kernel.Mechanics.Atributes
{
    public struct ConditionAtribute
    {
        public object objectA {  get; set; }   
        public string conditionOperator { get; set; }
        public object objectB { get; set; }
    }

}
