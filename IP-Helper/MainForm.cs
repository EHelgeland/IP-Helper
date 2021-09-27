using System;
using System.Threading;
using System.Windows.Forms;
using System.Management;
using System.Net.NetworkInformation;

namespace IP_Helper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Load NIC's to the list
            LoadNICList();

            // Load IP Library
            LoadIPLibrary();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            LoadNICList();
        }

        private void ComboBoxNIC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nicDesc = GetDesc((string)comboBoxNIC.SelectedItem);
            GetIPSettings(nicDesc);
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            if (comboBoxIPSelect.Text.Equals("DHCP"))
            {
                SetDHCP();
            }
            else if (comboBoxNIC.Text.Length >= 1)
            {

                // Get the selected IP from library
                IPInformation ipi = IPInformation.Instance();
                ipi.Load();

                string ipAddress = "";
                string subNet = "";
                string gWay = "";

                string selectedIP = comboBoxIPSelect.Text;

                foreach (IpSetting ip in ipi.ipDictionary.Values)
                {
                    if (ip.Name == selectedIP)
                    {
                        ipAddress = ip.IPAddress;
                        subNet = ip.SubNet;
                        gWay = ip.GateWay;
                    }
                }

                // Apply IP settings to NIC

                string selected = GetDesc(comboBoxNIC.SelectedItem.ToString());
                
                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();
                if (comboBoxNIC.Text.Length > 1 && selectedIP != "Select IP")
                {
                    foreach (ManagementObject objMO in objMOC)
                    {
                        bool ipEnabled = (bool)objMO["IPEnabled"];
                        bool dhcpEnabled = (bool)objMO["DHCPEnabled"];
                        string nicDesc = (string)objMO["Description"];
                        string nicID = (string)objMO["SettingID"];
                        string[] ipCompare = (string[])objMO["IPAddress"];


                        if (ipEnabled && !dhcpEnabled && nicDesc != selected && ipCompare[0] == ipAddress)
                        {
                            MessageBox.Show("IP is already set on another NIC: \n" + nicDesc, "Duplicate IP");
                            break;
                        }
                        else
                        {                            
                            if (nicDesc == selected)
                            {
                                try
                                {
                                    // Set DefaultGateway
                                    ManagementBaseObject newGateway = objMO.GetMethodParameters("SetGateways");
                                    newGateway["DefaultIPGateway"] = new string[] { gWay };
                                    newGateway["GatewayCostMetric"] = new int[] { 2 };

                                    // Set IPAddress and Subnet Mask
                                    ManagementBaseObject newAddress = objMO.GetMethodParameters("EnableStatic");
                                    newAddress["IPAddress"] = new string[] { ipAddress };
                                    newAddress["SubnetMask"] = new string[] { subNet };

                                    objMO.InvokeMethod("EnableStatic", newAddress, null);
                                    objMO.InvokeMethod("SetGateways", newGateway, null);

                                    MessageBox.Show("IP is set");

                                    GetIPSettings((string)objMO["Description"]);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }                        
                    }
                }
                // Misc errors
                else if (comboBoxNIC.Text.Length < 1)
                {
                    MessageBox.Show("Select a Network Interface Card");
                    comboBoxNIC.DroppedDown = true;
                }
                else if (selectedIP == "Select IP")
                {
                    MessageBox.Show("Select IP");
                    comboBoxIPSelect.DroppedDown = true;
                }
            ((IDisposable)objMC).Dispose();
            }
        }

        private void SetDHCP()
        {
            // Set DHCP
            string nicDesc = GetDesc((string)comboBoxNIC.SelectedItem);
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            if (comboBoxNIC.Text.Length > 1)
            {
                foreach (ManagementObject objMO in objMOC)
                {
                    string description = (string)objMO["Description"];
                    if (string.Compare(description,
                        nicDesc, StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        try
                        {
                            objMO.InvokeMethod("EnableDHCP", null);

                            MessageBox.Show("DHCP is set");

                            GetIPSettings(description);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Unable to Set DHCP : " + ex.Message);
                        }
                    }
                }
            }
            // Error
            else
            {
                MessageBox.Show("Select a Network Interface Card");
                comboBoxNIC.DroppedDown = true;
            }
            ((IDisposable)objMC).Dispose();
        }

        //public void showinfo(string info)
        //{
        //    // display message in textboxinfo

        //    textboxinfo.appendtext(info);
        //    thread.sleep(1750);
        //    textboxinfo.clear();
        //}

        private void LoadIPLibrary()
        {
            // Load or refresh the IP dropdown list

            comboBoxIPSelect.Items.Clear();
            comboBoxIPSelect.Items.Add("DHCP");

            IPInformation ipi = IPInformation.Instance();
            ipi.Load();

            foreach (IpSetting ip in ipi.ipDictionary.Values)

            {
                if (ip.Name != null)
                {
                    comboBoxIPSelect.Items.Add(ip.Name);
                }
            }
        }
        private void LoadNICList()
        {
            comboBoxNIC.Items.Clear();

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ("Up" == ni.OperationalStatus.ToString() && !checkBox1.Checked)
                {
                    if (ni.NetworkInterfaceType.ToString() == "Ethernet" || ni.NetworkInterfaceType.ToString() == "Wireless80211")
                        comboBoxNIC.Items.Add(ni.Name);
                }
                else if (checkBox1.Checked)
                {
                    if (ni.NetworkInterfaceType.ToString() == "Ethernet" || ni.NetworkInterfaceType.ToString() == "Wireless80211")
                        comboBoxNIC.Items.Add(ni.Name);
                }
            }
        }


    public void GetIPSettings(string selectedNIC)
        {
            // Load or refresh the IP settings to the "Current IP settings" text boxes

            textBoxDHCP.Clear();
            textBoxCurrentIP.Clear();
            textBoxCurrentSubnet.Clear();
            textBoxCurrentGateway.Clear();

            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                string nicDesc = (string)objMO["Description"];

                if (nicDesc == selectedNIC)
                {
                    try
                    {
                        try
                        {                            
                            if ((bool)objMO["DHCPEnabled"])
                                textBoxDHCP.AppendText("DHCP");
                            else if (!(bool)objMO["DHCPEnabled"])
                                textBoxDHCP.AppendText("Static");
                            else if (!(bool)objMO["IPEnabled"])
                                textBoxDHCP.AppendText("Disconnected");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }

                        string[] ipAddress = (string[])objMO["IPAddress"];                        
                        string[] subNet = (string[])objMO["IPSubnet"];
                        string[] gateway = (string[])objMO["DefaultIPGateway"];

                        if (ipAddress != null)
                        {
                            textBoxCurrentIP.AppendText(ipAddress[0]);
                            textBoxCurrentSubnet.AppendText(subNet[0]);
                            textBoxCurrentGateway.AppendText(gateway[0]);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            ((IDisposable)objMC).Dispose();
        }

        public string GetDesc(string nicName)
        {
            string id = "";
            string nicDesc = "";

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nicName == ni.Name)
                {
                    id = ni.Id;
                }
            }

            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if (id == (string)objMO["SettingID"]) nicDesc = (string)objMO["Description"]; 
            }
            ((IDisposable)objMC).Dispose();

            return nicDesc;           
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            string nicDesc = GetDesc((string)comboBoxNIC.SelectedItem);
            GetIPSettings(nicDesc);
            LoadNICList();
        }


        private void Button1_Click_1(object sender, EventArgs e)
        {
            AddressBook AddressBook = new AddressBook();
            AddressBook.ShowDialog();
            AddressBook.Dispose();
            LoadIPLibrary();
        }

        private void TextBoxDHCP_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxInputIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxInputSubnet_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxInputGateway_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void ButtonOptionClick(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.ShowDialog();
            optionsForm.Dispose();
            LoadIPLibrary();
        }
    }
}