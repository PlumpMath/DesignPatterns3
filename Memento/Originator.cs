using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMemento
{
    // Memento Design Pattern Tutorial

    public class Originator
    {

        private String statement;

        // Sets the value for the statement

        public void set(String newStatement)
        {
            Console.WriteLine("----");
            Console.WriteLine("From Originator: Current Version of Statement\n" + newStatement + "\n");
            this.statement = newStatement;
        }

        // Creates a new Memento with a new statement

        public Memento storeInMemento()
        {
            Console.WriteLine("From Originator: Saving to Memento");
            return new Memento(statement);
        }

        // Gets the statement currently stored in memento

        public String restoreFromMemento(Memento memento)
        {

            statement = memento.getState();

            Console.WriteLine("From Originator: Previous Statement Saved in Memento\n" + statement + "\n");

            return statement;

        }
    }
}
