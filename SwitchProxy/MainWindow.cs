using System.Windows.Forms;

namespace SwitchProxy
{
    public partial class MainWindow : Form
    {
        private readonly ViewModel _Model;

        public MainWindow()
        {
            InitializeComponent();
            _Model = new ViewModel((text) => ntyIcon.ShowBalloonTip(0, "Information", text, ToolTipIcon.Info));
        }

        private void MainWindow_Load(object sender, System.EventArgs e)
        {
            this.Hide();
            EventDesign();
            DataBind();
        }

        private void EventDesign()
        {
            this.exitToolStripMenuItem.Click += (s, e) => this.Close();
            this.switchProxyToolStripMenuItem.Click += (s, e) => _Model.SetProxy(!_Model.IsProxyOpened);
        }

        private void DataBind()
        {
            switchProxyToolStripMenuItem.DataBindings.Add(nameof(Text), _Model, nameof(ViewModel.SwitcherText));
        }
    }
}
