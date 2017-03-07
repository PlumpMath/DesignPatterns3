using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMemento
{
    // Memento Design Pattern Tutorial

   public class Caretaker
    {

        // Where all mementos are saved

        List<Memento> savedStatements = new List<Memento>();

        // Adds memento to the ArrayList

        public void addMemento(Memento m) { savedStatements.Add(m); }

        // Gets the memento requested from the ArrayList

        public Memento getMemento(int index) { return savedStatements[index]; }
    }
}
