using System.Windows.Forms;

namespace TacticalOpsQuickJoin {
    public partial class FormError : Form {
        public FormError() {
            InitializeComponent();
        }

        public FormError(string message) {
            InitializeComponent();
            lblMessage.Text = message;
        }
    }
}
