using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace Anagramer
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main application window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Key press event from main word/character input TextBox
        /// </summary>
        /// <param name="sender">Word/character input TextBox</param>
        /// <param name="e">Key event arguments</param>
        private void MainInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && sender is TextBox textBox && textBox.Text.Length > 2)
            {
                CharacterSourcePanel.Children.Clear();
                CharacterTargetPanel.Children.Clear();

                foreach (var character in textBox.Text)
                {
                    if (character.ToString() == " ")
                    {
                        continue;
                    }
                    CharacterSourcePanel.Children.Add(new Character(character.ToString()));
                    CharacterTargetPanel.Children.Add(new Character(" "));
                }
            }
        }
    }
}
