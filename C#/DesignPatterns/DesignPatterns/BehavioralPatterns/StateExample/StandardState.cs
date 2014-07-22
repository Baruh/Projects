using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.StateExample
{
    internal class StandardState : EngineState
    {
        public override void Handle(Engine engine)
        {
            engine.Power = 300;
            engine.Depreciation = 10;
        }
    }
}
