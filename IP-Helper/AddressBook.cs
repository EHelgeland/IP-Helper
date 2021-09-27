using System;
using System.Windows.Forms;

namespace IP_Helper
{
    public partial class AddressBook : Form
    {
        public AddressBook()
        {
            InitializeComponent();

            //load IP List
            LoadIPLIBList();
        }

        private void AddressBook_Load(object sender, EventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                textBoxInputName.Clear();
                textBoxInputIP.Clear();
                textBoxInputSubnet.Clear();
                textBoxInputGateway.Clear();

                IPInformation ipi = IPInformation.Instance();
                ipi.Load();

                string selected = "";

                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Selected) selected = item.Text;
                }

                try
                {
                    foreach (IpSetting ip in ipi.ipDictionary.Values)
                    {
                        if (ip.Name == selected)
                        {
                            textBoxInputName.AppendText(ip.Name);
                            textBoxInputIP.AppendText(ip.IPAddress);
                            textBoxInputSubnet.AppendText(ip.SubNet);
                            textBoxInputGateway.AppendText(ip.GateWay);
                        }
                    }
                }
                catch
                {

                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            LoadIPLIBList();
        }

        private void LoadIPLIBList()
        {
            listView1.Items.Clear();

            IPInformation ipi = IPInformation.Instance();
            ipi.Load();

            foreach (IpSetting ip in ipi.ipDictionary.Values)

            {
                if (ip.Name != null)
                {
                    ListViewItem Name = new ListViewItem(ip.Name);
                    ListViewItem.ListViewSubItem IP = new ListViewItem.ListViewSubItem(Name, ip.IPAddress);

                    Name.SubItems.Add(IP);
                    listView1.Items.Add(Name);
                }
            }

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxInputName.Text;
            string ipAddress = textBoxInputIP.Text;
            string subNet = textBoxInputSubnet.Text;
            string gWay = textBoxInputGateway.Text;

            IPInformation ipi = IPInformation.Instance();

            if (textBoxInputName.Text.Length > 0)
            {
                bool r = ipi.AddIP(name, ipAddress, subNet, gWay);
                ipi.Save();

                if (r)
                {
                    LoadIPLIBList();
                    MessageBox.Show("New IP Saved");
                }
                else
                {
                    DialogResult result = MessageBox.Show("IP already exists in library. Do you wish to overwrite?", "Error", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        ipi.RemoveIP(name);
                        bool overWriter = ipi.AddIP(name, ipAddress, subNet, gWay);
                        ipi.Save();
                        if (overWriter)
                        {
                            MessageBox.Show("IP is updated");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Input a name for the IP");
            }
        }

        private void TextBoxInputName_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonClr_Click(object sender, EventArgs e)
        {
            textBoxInputName.Clear();
            textBoxInputIP.Clear();
            textBoxInputSubnet.Clear();
            textBoxInputGateway.Clear();
            textBoxInputIP.Focus();
        }

        private void ButtonRm_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null)
            {
                IPInformation ipi = IPInformation.Instance();
                ipi.Load();

                foreach (ListViewItem items in listView1.SelectedItems)
                {
                    if (items.Selected) ipi.RemoveIP(items.Text);
                }
          
                ipi.Save();

                LoadIPLIBList();

                textBoxInputName.Clear();
                textBoxInputIP.Clear();
                textBoxInputSubnet.Clear();
                textBoxInputGateway.Clear();
                textBoxInputIP.Focus();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBoxInputName.Clear();
            textBoxInputIP.Clear();
            textBoxInputSubnet.Clear();
            textBoxInputGateway.Clear();

            //listView1.Clear();
            textBoxInputName.AppendText("New IP");
            textBoxInputName.SelectAll();
            textBoxInputName.Focus();
        }

        private void TextBoxInputIP_LostFocus(object sender, EventArgs e)
        {
            if (textBoxInputName.Text.Length == 0)
            {
                textBoxInputName.Text = textBoxInputIP.Text;
            }
            if (textBoxInputSubnet.Text.Length == 0 && textBoxInputIP.Text.Length > 0)
            {
                textBoxInputSubnet.AppendText("255.255.255.0");
            }
            if (textBoxInputGateway.Text.Length == 0)
            {
                try
                {
                    string autoGW = textBoxInputIP.Text;

                    int start = 0;
                    int end = autoGW.Length;
                    int at;
                    int count;
                    
                    while (start <= end)
                    {
                        count = end - start;
                        at = autoGW.IndexOf(".", start, count);
                        if (at == -1) break;
                        start = at + 1;
                    }

                    textBoxInputGateway.AppendText(autoGW.Remove(start) + "1");
                }
                catch
                {
                    
                }
            }
        }
    }
}
