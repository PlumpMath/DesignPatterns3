using DemoMemento;
using System.Windows;
using static System.Diagnostics.Debug;

// This Memento patter will create a caretaker that contains the collection 
// with all the Statements in it. It can add and
// retrieve Statements from the collection

namespace Memento
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Caretaker caretaker = new Caretaker();

        // The originator sets the value for the statement,
        // creates a new memento with a new statement, and 
        // gets the statement stored in the current memento

        Originator originator = new Originator();

        int saveFiles = 0, currentStatement = -1;

        // ---------------------------------------------

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Get text in TextBox
            string text = theStatement.Text;

            // Set the value for the current memento
            originator.set(text);

            // Add new statement to the collection
            caretaker.addMemento(originator.storeInMemento());

            // saveFiles monitors how many statements are saved
            // Number of mementos I have
            saveFiles++;
            currentStatement++;

            System.Threading.Thread.Sleep(500);          
            WriteLine("Saved Files " + saveFiles + "\n");          

            btnUndo.IsEnabled = true;
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            if (currentStatement >= 1)
            {
                currentStatement--;

                string textBoxString = originator.restoreFromMemento(caretaker.getMemento(currentStatement));

                theStatement.Text = textBoxString;

                btnRedo.IsEnabled = true;
            }
            else {
                btnUndo.IsEnabled = false;
            }
        }

        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            if ((saveFiles - 1)> currentStatement) 
            {
                currentStatement++;

                string textBoxString = originator.restoreFromMemento(caretaker.getMemento(currentStatement));

                theStatement.Text = textBoxString;

                btnUndo.IsEnabled = false;
            }
            else
            {
                btnRedo.IsEnabled = false;
            }

            btnUndo.IsEnabled = true;
        }
    }
}
