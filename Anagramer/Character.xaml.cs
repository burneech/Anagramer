using System.Windows.Controls;

namespace Anagramer
{
    /// <summary>
    /// Draggable character display object for the Source and Target panels
    /// </summary>
    public partial class Character : UserControl
    {
        private string _displayedCharacter;

        /// <inheritdoc cref="Character"/>
        /// <param name="displayCharacter">Character/letter/number to be displayed</param>
        public Character(string displayedCharacter)
        {
            InitializeComponent();
            _displayedCharacter = TextBox_DisplayedCharacter.Text = displayedCharacter;
        }
    }
}
