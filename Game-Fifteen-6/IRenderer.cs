using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
{
    public interface IRenderer
    {
        void Display(string toDisplay);
        string Read(string message); 
    }
}
