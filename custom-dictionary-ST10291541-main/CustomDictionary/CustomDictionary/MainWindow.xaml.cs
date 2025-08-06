using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomDictionary
{
    public partial class MainWindow : Window
    {
        private CustomDictionary<string, string> devices = new CustomDictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddDevice_Click(object sender, RoutedEventArgs e)
        {
            string id = txtDeviceID.Text.Trim();
            string status = (cmbStatus.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(id) || status == null)
            {
                MessageBox.Show("Please enter a Device ID and select a Status.");
                return;
            }

            try
            {
                devices.Add(id, status);
                RefreshDeviceList();
            }
            catch
            {
                MessageBox.Show("Device ID already exists.");
            }
        }

        private void UpdateStatus_Click(object sender, RoutedEventArgs e)
        {
            string id = txtDeviceID.Text.Trim();
            string status = (cmbStatus.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (devices.Update(id, status))
            {
                RefreshDeviceList();
            }
            else
            {
                MessageBox.Show("Device not found.");
            }
        }

        private void RemoveDevice_Click(object sender, RoutedEventArgs e)
        {
            string id = txtDeviceID.Text.Trim();

            if (devices.Remove(id))
            {
                RefreshDeviceList();
            }
            else
            {
                MessageBox.Show("Device not found.");
            }
        }

        private void RefreshDeviceList()
        {
            lstDevices.Items.Clear();
            foreach (var item in devices.GetAllItems())
            {
                lstDevices.Items.Add($"ID: {item.Key} - Status: {item.Value}");
            }
        }
    }
}