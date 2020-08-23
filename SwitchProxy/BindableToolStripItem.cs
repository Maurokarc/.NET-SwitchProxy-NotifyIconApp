using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SwitchProxy
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class BindableToolStripItem : ToolStripMenuItem, IBindableComponent
    {
        [Browsable(false)]
        public BindingContext BindingContext { get; set; }

        public ControlBindingsCollection DataBindings { get; set; }

        public BindableToolStripItem()
        {
            BindingContext = new BindingContext();
            DataBindings = new ControlBindingsCollection(this);
        }

    }
}