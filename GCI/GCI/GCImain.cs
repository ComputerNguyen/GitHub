using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCI
{
    public partial class GCImain : Form
    {
        public GCImain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Khi chạy chương trình sẽ tự động trích xuất thông tin ra màn hình hiển thị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GCImain_Load(object sender, EventArgs e)
        {
            //
            //Lấy thông tin cơ bản về Vi xử lí thông qua Class "Win32_Processor"
            //
            #region
            txtCPUName.Text = GCI.GetInfo("Win32_Processor", "Name");
            txtCPUCaption.Text = GCI.GetInfo("Win32_processor", "Caption");
            txtCPUManufacturer.Text = GCI.GetInfo("Win32_processor", "Manufacturer");
            txtCPUAssetTag.Text = GCI.GetInfo("Win32_processor", "AssetTag");
            txtCPUProcessor.Text = GCI.GetInfo("Win32_processor", "ProcessorId");
            txtCPUCurrentVoltage.Text = GCI.GetInfo("Win32_processor", "CurrentVoltage");
            txtCPUL3CacheSize.Text = GCI.GetInfo("Win32_processor", "L3CacheSize");
            txtCPURevision.Text = GCI.GetInfo("Win32_processor", "Revision");
            txtCPUNumberOfCores.Text = GCI.GetInfo("Win32_processor", "NumberOfCores");
            txtCPUThreadCount.Text = GCI.GetInfo("Win32_processor", "ThreadCount");
            txtCPUMaxClockSpeed.Text = GCI.GetInfo("Win32_processor", "MaxClockSpeed");
            txtCPUDataWidth.Text = GCI.GetInfo("Win32_processor", "DataWidth");
            //
            //Tìm và đưa ra màn hình hiển thị hình ảnh tương ứng với CPU 
            //Hình ảnh của vi xử lí Core i3,Core i5 và Core i7
            //
            string s1 = txtCPUName.Text;
            if (s1.IndexOf("i7") >= 0)
                pictureCPU.Image = Properties.Resources.core_i7;
            else if (s1.IndexOf("i5") >= 0)
                pictureCPU.Image = Properties.Resources.core_i5;
            else if (s1.IndexOf("i3") >= 0)
                pictureCPU.Image = Properties.Resources.core_i3;
            //
            #endregion
            //
            //Get Mainboard Information
            //
            #region
            //Lấy thông tin về Base Board thông qua Class "Win32_BaseBoard"
            //
            txtMainManufacturer.Text = GCI.GetInfo("Win32_BaseBoard", "Manufacturer");
            txtMainCaption.Text = GCI.GetInfo("Win32_BaseBoard", "Caption");
            txtMainProduct.Text = GCI.GetInfo("Win32_BaseBoard", "Product");
            txtMainVersion.Text = GCI.GetInfo("Win32_BaseBoard", "Version");
            txtMainSerial.Text = GCI.GetInfo("Win32_BaseBoard", "SerialNumber");
            //Lấy thông tin về Bios và xuất ra màn hình 
            //Sử dụng Class "Win32_BIOS"
            txtBiosManufacturer.Text = GCI.GetInfo("Win32_BIOS", "Manufacturer");
            txtBiosReleaseDate.Text = GCI.GetInfo("Win32_BIOS", "ReleaseDate");
            txtBiosSMBios.Text = GCI.GetInfo("Win32_BIOS", "SMBIOSBIOSVersion");
            txtBiosVersion.Text = GCI.GetInfo("Win32_BIOS","Version");
            txtBiosSerialNumber.Text = GCI.GetInfo("Win32_BIOS", "SerialNumber");
            //
            #endregion
            //
            //Lấy thông tin về Bộ nhớ máy tính bao gồm Ram và Ổ cứng
            //Lấy thông tin về Ổ cứng và xuất ra TextBox
            //Sử dụng Class "Win32_DiskDrive"
            //
            #region
            txtDiskModel.Text = GCI.GetInfo("Win32_DiskDrive", "Model");
            txtDiskSerialNumber.Text = GCI.GetInfo("Win32_DiskDrive", "SerialNumber");
            txtDiskSize.Text = GCI.GetInfo("Win32_DiskDrive", "Size");
            txtDiskPartitions.Text = GCI.GetInfo("Win32_DiskDrive", "Partitions");
            txtDiskBytesPerSector.Text = GCI.GetInfo("Win32_DiskDrive", "BytesPerSector");
            txtDiskTotalSectors.Text = GCI.GetInfo("Win32_DiskDrive", "TotalSectors");
            txtDiskInterfaceType.Text = GCI.GetInfo("Win32_DiskDrive", "InterfaceType");
            txtDiskTotalCylinders.Text = GCI.GetInfo("Win32_DiskDrive", "TotalCylinders");
            //
            //Lấy thông tin về Ram và xuất ra TextBox
            //Sử dụng Class "Win32_PhysicalMemory"
            //
            txtRamTotalSize.Text = GCI.GetRamSize();
            txtRamSlots.Text = GCI.GetNoRamSlots();
            txtRamManufacturer.Text = GCI.GetInfo("Win32_PhysicalMemory", "Manufacturer");
            txtRamSpeed.Text = GCI.GetInfo("Win32_PhysicalMemory", "Speed");
            //
            #endregion
            //
            //Lấy thông tin cơ bản về Pin xuất ra TextBox
            //Sử dụng Class "Win32_Battery"
            //
            #region
            //
            txtBatCaption.Text = GCI.GetInfo("Win32_Battery", "Caption");
            txtBatDevice.Text = GCI.GetInfo("Win32_Battery", "DeviceID");
            txtBatStatus.Text = GCI.GetInfo("Win32_Battery", "BatteryStatus");
            txtBatDesignVoltage.Text = GCI.GetInfo("Win32_Battery", "DesignVoltage");
            txtBatECR.Text = GCI.GetInfo("Win32_Battery", "EstimatedChargeRemaining");
            txtBatERT.Text = GCI.GetInfo("Win32_Battery", "EstimatedRunTime");
            txtBatEBLife.Text = GCI.GetInfo("Win32_Battery", "ExpectedBatteryLife");
            txtBatELife.Text = GCI.GetInfo("Win32_Battery", "ExpectedLife");
            txtBatFullCharge.Text = GCI.GetInfo("Win32_Battery", "FullChargeCapacity");
            txtBatMaxRecharge.Text = GCI.GetInfo("Win32_Battery", "MaxRechargeTime");
            //
            #endregion
            //
            //Lấy thông tin về Hệ điều hành Windows xuất ra TextBox
            //Sử dụng Class "Win32_OperatingSystem"
            //
            #region
            //
            txtOSCaption.Text = GCI.GetInfo("Win32_OperatingSystem", "Caption") + " " + GCI.GetInfo("Win32_OperatingSystem", "OSArchitecture");
            txtOSVersion.Text = "Version: " + GCI.GetInfo("Win32_OperatingSystem", "Version");
            txtOSUser.Text = "Registered User: " + GCI.GetInfo("Win32_OperatingSystem", "RegisteredUser");
            txtOSSerialNumber.Text = "Serial Number: " + GCI.GetInfo("Win32_OperatingSystem", "SerialNumber");
            //
            #endregion
            //

        }

        #region
        /// <summary>
        /// Lựa chọn Class "Win32_DisplayControllerConfiguration",hoặc"Win32_DisplayConfiguration"
        /// Lấy thông tin GPU được chọn và xuất ra TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   //Gán tên Class được chọn từ ComboBox chuyển sang xâu vào biến xâu Cls
            string Cls = comboBox1.SelectedItem.ToString();
            //Nếu chọn vào Class "Win32_DisplayControllerConfiguration"-Lấy thông tin GPU Onboard
            if (Cls== "Win32_DisplayControllerConfiguration")
            //Trích xuất thông tin ra TextBox
            {
                txtGPUBitsPerPel.Text = GCI.GetInfo(Cls, "BitsPerPixel");
                txtGPUCaption.Text = GCI.GetInfo(Cls, "Caption");
                txtGPUDisplay.Text = GCI.GetInfo(Cls, "RefreshRate");
                txtGPUPelsHeight.Text = GCI.GetInfo(Cls, "HorizontalResolution");
                txtGPUPelsWidth.Text = GCI.GetInfo(Cls, "VerticalResolution");
                txtGPULogPixels.Text = GCI.GetInfo(Cls, "LogPixels");
                txtGPUVideoMode.Text = GCI.GetInfo(Cls, "VideoMode");
            }
            //Nếu chọn vào Class "Win32_DisplayConfiguration"-Lấy thông tin GPU rời
            else
            //Trích xuất thông tin ra TextBox
            {
                txtGPUBitsPerPel.Text = GCI.GetInfo(Cls, "BitsPerPel");
                txtGPUCaption.Text = GCI.GetInfo(Cls, "Caption");
                txtGPUDisplay.Text = GCI.GetInfo(Cls, "DisplayFrequency");
                txtGPUPelsHeight.Text = GCI.GetInfo(Cls, "PelsHeight");
                txtGPUPelsWidth.Text = GCI.GetInfo(Cls, "PelsWidth");
                txtGPULogPixels.Text = GCI.GetInfo(Cls, "LogPixels");
                txtGPUVideoMode.Text = GCI.GetInfo(Cls, "VideoMode");
            }
                      
        }
        /// <summary>
        /// Gán link vào LinkLabel để đến đường dẫn cá nhân
        /// Khi click vào LinkLabel sẽ chuyển đến trang web cá nhân
        /// </summary>
        /// <param name="sender"></param> 
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("www.facebook.com/computer.nvt");
        }
        //
        #endregion
        //
    }
}
