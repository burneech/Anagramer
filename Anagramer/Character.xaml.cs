using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace Anagramer
{
    /// <summary>
    /// Draggable character display object for the Source and Target panels
    /// </summary>
    public partial class Character : UserControl
    {
        /// <inheritdoc cref="Character"/>
        /// <param name="displayCharacter">Character/letter/number to be displayed</param>
        public Character(string displayedCharacter)
        {
            InitializeComponent();
            TextBox_DisplayedCharacter.Text = displayedCharacter;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("Object", this);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            }
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);
            e.Effects = DragDropEffects.None;

            // Source/sender character object
            Character _sourceCharacter = (Character)e.Data.GetData("Object");
            if (_sourceCharacter != null)
            {
                e.Effects = DragDropEffects.Move;
            }

            e.Handled = true;
        }

        private void Character_Drop(object sender, DragEventArgs e)
        {
            if (e.Handled == false)
            {
                // Source/sender character object
                Character _sourceCharacter = (Character)e.Data.GetData("Object");

                if (_sourceCharacter != null)
                {
                    // Switch source and target character
                    string originalSourceCharacter = _sourceCharacter.TextBox_DisplayedCharacter.Text;          // Keep original temporarily
                    _sourceCharacter.TextBox_DisplayedCharacter.Text = this.TextBox_DisplayedCharacter.Text;    // Source <= Target
                    this.TextBox_DisplayedCharacter.Text = originalSourceCharacter;                             // Target => Source (original)
                }
            }
        }
    }
}
