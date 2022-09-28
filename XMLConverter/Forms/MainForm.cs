using Core.Controllers;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace XMLConverter.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();             
        }

        private void btnSelect_Click(object sender, System.EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    txtPath.Text = filePath;

                    var direction = Path.GetDirectoryName(filePath);
                    var fileName = Path.GetFileName(filePath);

                    txtName.Text = $"{direction}\\new_{fileName}";
                }
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            var path = txtPath.Text;
            if (string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("Укажите путь исходного файла");
                return;
            }

            var filePath = txtName.Text;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Укажите путь выходного файла");
                return;
            }

            var query = OriginalController.GetQueryFromXML(path);
            var obj = FinalController.GetIndividualization(query);
            FinalController.GetXML(obj, filePath, encoding: Encoding.UTF8);

            MessageBox.Show("Операция успешно завершена");

            var direction = Path.GetDirectoryName(filePath);
            Process.Start(direction);
        }
    }
}
