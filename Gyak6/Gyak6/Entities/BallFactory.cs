using Gyak6.Abstractions;
using Gyak6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak6
{
    public class BallFactory : Abstractions.IToyFactory
    {
        public Toy CreateNew()
        {
            return new Ball();
        }

    }
}
