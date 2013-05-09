namespace GameFifteen
{
    using System;
    using System.Linq;

    public interface IRenderer
    {
        void Display(string toDisplay);

        string Read(string message); 
    }
}
