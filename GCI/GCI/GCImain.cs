//.................Get Computer Information...................
//......................Version: 1.0.0........................
//.......................October 2015.........................
//..................Tác giả: Nguyễn Văn Tú....................
//...............www.facebook.com/computer.nvt................
//............GCI là mã nguồn mở có thể tùy biến..............

using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Media;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;


namespace GCI
{
    public partial class GCImain : Form
    { 
        //
        //Khai báo các biến toàn cục
        //
        #region 
        public static string 
            saveCPU,
            saveMain,
            saveMem,
            saveGra = ">>>>>>>>>>>>Graphics<<<<<<<<<<<<" + "\r\n\r\n",
            saveBat,
            saveOS;
        #endregion
        
        /// <summary>
        /// Hàm khởi tạo các đối tượng trên Form
        /// </summary>
        public GCImain()
        {
            //
            //Hàm InitializeComponent() dùng để khởi tạo các đối tượng có trên form như textbox,combobox...
            //
            InitializeComponent();
        }
        
        /// <summary>
        /// Lấy thông tin CPU,Main,Memory,Battery,OS và hiển thị
        /// </summary>
        /// <param name="sender">Đối tượng phát sinh ra event</param>
        /// <param name="e">Đối tượng e chứa danh sách các thuộc tính bổ xung khi đối tượng phát sinh event</param>
        public void GCImain_Load(object sender, EventArgs e)
        {
            //
            //Lấy thông tin cơ bản về Vi xử lí 
            //Sử dụng Class "Win32_Processor"
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
            //Lấy thông tin cơ bản về MainBoard xuất ra TextBox
            //Sử dụng Class "Win32_BaseBoard" và "Win32_BIOS"
            //
            #region
            //Lấy thông tin về Base Board
            //Class "Win32_BaseBoard"
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
            //Lấy thông tin về Ổ cứng và Ram xuất ra TextBox
            //Sử dụng Class "Win32_DiskDrive" và "Win32_PhysicalMemory"
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
            //Lưu thông tin máy tính dưới dạng xâu kí tự
            //Lưu vào các biến xâu saveCPU,saveMain,saveMem,saveBat,saveOS
            //
            #region
            
            saveCPU =
                 //Lưu thông tin CPU vào string saveCPU
                 "...............Get Computer Information..........\r\n" +
                 "...................Version 1.0.0.................\r\n" +
                 "..............Produced by: Nguyen Van Tu.........\r\n\r\n" +
                 "Your Computer Information :\r\n\r\n" +
                 ">>>>>>>>>>>>CPU<<<<<<<<<<<<" +
                 "\r\n\r\nName: " + txtCPUName.Text +
                 "\r\nCaption: " + txtCPUCaption.Text +
                 "\r\nManufacturer: " + txtCPUManufacturer.Text +
                 "\r\nAssetTag: " + txtCPUAssetTag.Text +
                 "\r\nProcessor: " + txtCPUProcessor.Text +
                 "\r\nCurrentVoltage: " + txtCPUCurrentVoltage.Text +
                 "\r\nL3CacheSize: " + txtCPUL3CacheSize.Text +
                 "\r\nRevision: " + txtCPURevision.Text +
                 "\r\nNumberOfCores: " + txtCPUNumberOfCores.Text +
                 "\r\nThreadCount: " + txtCPUThreadCount.Text +
                 "\r\nMaxClockSpeed: " + txtCPUMaxClockSpeed.Text +
                 "\r\nDataWidth: " + txtCPUDataWidth.Text + "\r\n\r\n";
            saveMain =
                 //Lưu thông tin MainBoard vào string saveMain
                 ">>>>>>>>>>>>MainBoard<<<<<<<<<<<<" +
                 "\r\n\r\n=> Base Board: \r\n" +
                 "\r\nManufacturer: " + txtMainManufacturer.Text +
                 "\r\nCaption: " + txtMainCaption.Text +
                 "\r\nProduct: " + txtMainProduct.Text +
                 "\r\nVesion: " + txtMainVersion.Text +
                 "\r\nSerialNumber: " + txtMainSerial.Text +
                 "\r\n\r\n=> Bios: \r\n" +
                 "\r\nManafacturer: " + txtBiosManufacturer.Text +
                 "\r\nReleaseDate: " + txtBiosReleaseDate.Text +
                 "\r\nSMBiosVersion: " + txtBiosSMBios.Text +
                 "\r\nVersion: " + txtBiosVersion.Text +
                 "\r\nSerialNumber: " + txtBiosSerialNumber.Text + "\r\n\r\n";
            saveMem =
                 //Lưu thông tin Memory vào string saveMem
                 ">>>>>>>>>>>>Memory<<<<<<<<<<<<" + "\r\n"+
                 "\r\n=> Disk : \r\n"+
                 "\r\nModel: " +txtDiskModel.Text+
                 "\r\nSize: " +txtDiskSize.Text+
                 "\r\nPartitions: " +txtDiskPartitions.Text+
                 "\r\nBytesPerSector: " +txtDiskBytesPerSector.Text+
                 "\r\nTotalSectors: " +txtDiskTotalSectors.Text+
                 "\r\nInterfaceType" +txtDiskInterfaceType.Text+
                 "\r\nTotalCylinders: " +txtDiskTotalCylinders.Text+
                 "\r\nSerialNumber: " +txtDiskSerialNumber.Text+"\r\n"+
                 "\r\n=> Ram : \r\n" +
                 "\r\nTotalSize: "+txtRamTotalSize.Text+
                 "\r\nSlots: "+txtRamSlots.Text+
                 "\r\nManufacturer: "+ txtRamManufacturer.Text +
                 "\r\nSpeed: " + txtRamSpeed.Text+ "\r\n\r\n";
            saveBat =
                 //Lưu thông tin Battery vào string saveBat
                 ">>>>>>>>>>>>Battery<<<<<<<<<<<<" + "\r\n" +
                 "\r\nCaption: " +txtBatCaption.Text+
                 "\r\nDeviceID: " +txtBatDevice.Text+
                 "\r\nBatteryStatus: " +txtBatStatus+
                 "\r\nDesignVoltage: " +txtBatDesignVoltage.Text+
                 "\r\nEstimatedChargeRemaining: " +txtBatECR.Text+
                 "\r\nEstimatedRunTime: " +txtBatERT.Text+
                 "\r\nExpectedBatteryLife: " +txtBatEBLife.Text+
                 "\r\nExpectedLife: " +txtBatELife.Text+
                 "\r\nFullChargeCapacity: " +txtBatFullCharge.Text+
                 "\r\nMaxReChargeTime: " +txtBatMaxRecharge.Text + "\r\n\r\n";
            saveOS =
                 //Lưu thông tin OS vào string saveOS
                 ">>>>>>>>>>>>Operating Systems<<<<<<<<<<<<" + "\r\n" +
                 "\r\nCaption: "+txtOSCaption.Text+
                 "\r\nVersion: " +txtOSVersion.Text+
                 "\r\nRegistered User: " +txtOSUser.Text+
                 "\r\nSerial Number: " +txtOSSerialNumber.Text+ "\r\n\r\n"
                 ;

            #endregion
        }
        
        /// <summary>
        /// Lấy thông tin GPU và hiển thị
        /// Lựa chọn thiết bị cần lấy thông tin
        /// </summary>
        /// <param name="sender">Đối tượng phát sinh ra event</param>
        /// <param name="e">Đối tượng e chứa danh sách các thuộc tính bổ xung khi đối tượng phát sinh event</param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   //Gán tên Class được chọn từ ComboBox chuyển sang xâu vào biến xâu Cls
            string Cls = comboBox1.SelectedItem.ToString();
            //
            //Lấy thông tin về Display Controller Configuration
            //Sử dụng Class "Win32_DisplayControllerConfiguration" và "Win32_DisplayConfiguration"
            //
            #region
            if (Cls== "DisplayControllerConfiguration")
            {
                //
                //Lấy thông tin về Display Controller Configuration
                //Sử dụng Class "Win32_DisplayControllerConfiguration" 
                //
                #region
                Cls = "Win32_DisplayControllerConfiguration";
                txtGPUCaption.Text = GCI.GetInfo(Cls, "Caption");
                txtGPUBitsPerPel.Text = GCI.GetInfo(Cls, "BitsPerPixel");
                txtGPUDisplay.Text = GCI.GetInfo(Cls, "RefreshRate");
                txtGPUPelsHeight.Text = GCI.GetInfo(Cls, "HorizontalResolution");
                txtGPUPelsWidth.Text = GCI.GetInfo(Cls, "VerticalResolution");
                txtGPULogPixels.Text = GCI.GetInfo(Cls, "LogPixels");
                txtGPUVideoMode.Text = GCI.GetInfo(Cls, "VideoMode");
                #endregion
                //
                //Lưu thông tin Graphhics vào stringGra
                //
                #region
                saveGra = saveGra +
                 //Lưu thông tin Graphics
                 "=> Display Controller Configuration : \r\n" +
                 "\r\nCaption: " + txtGPUBitsPerPel.Text +
                 "\r\nBitsPerPel: " + txtGPUCaption.Text +
                 "\r\nDisplayFrequency: " + txtGPUDisplay.Text +
                 "\r\nPelsHeight: " + txtGPUPelsHeight.Text +
                 "\r\nPelsWidth: " + txtGPUPelsWidth.Text +
                 "\r\nLogPixels: " + txtGPULogPixels.Text +
                 "\r\nVideoMode: " + txtGPUVideoMode.Text + "\r\n\r\n"
                 ;
                #endregion
            }
            else
            {
                //
                //Lấy thông tin về Display Configuration
                //Sử dụng Class "Win32_DisplayConfiguration"
                //
                #region
                Cls = "Win32_DisplayConfiguration";
                txtGPUCaption.Text = GCI.GetInfo(Cls, "Caption");
                txtGPUBitsPerPel.Text = GCI.GetInfo(Cls, "BitsPerPel");
                txtGPUDisplay.Text = GCI.GetInfo(Cls, "DisplayFrequency");
                txtGPUPelsHeight.Text = GCI.GetInfo(Cls, "PelsHeight");
                txtGPUPelsWidth.Text = GCI.GetInfo(Cls, "PelsWidth");
                txtGPULogPixels.Text = GCI.GetInfo(Cls, "LogPixels");
                txtGPUVideoMode.Text = GCI.GetInfo(Cls, "VideoMode");
                #endregion
                //
                //Lưu thông tin Graphhics vào stringGra
                //
                #region
                saveGra = saveGra +
                 //Lưu thông tin Graphics
                 "=> Display Configuration : \r\n" +
                 "\r\nCaption: " + txtGPUBitsPerPel.Text +
                 "\r\nBitsPerPel: " + txtGPUCaption.Text +
                 "\r\nDisplayFrequency: " + txtGPUDisplay.Text +
                 "\r\nPelsHeight: " + txtGPUPelsHeight.Text +
                 "\r\nPelsWidth: " + txtGPUPelsWidth.Text +
                 "\r\nLogPixels: " + txtGPULogPixels.Text +
                 "\r\nVideoMode: " + txtGPUVideoMode.Text + "\r\n\r\n"
                 ;
                #endregion
            }
            #endregion
            //
            //Hiển thị hình ảnh của GPU
            //Hỗ trợ: Intel,AMD,NVIDIA,NVIDIA Geforce
            //
            #region
            string GPU = txtGPUCaption.Text;
            if (GPU.IndexOf("Intel") >= 0)
                pictureGPU.Image = Properties.Resources.IntelG;
            else if (GPU.IndexOf("AMD") >= 0)
                pictureGPU.Image = Properties.Resources.AMD;
            else if (GPU.IndexOf("GeForce") >= 0)
                pictureGPU.Image = Properties.Resources.Geforce;
            else if (GPU.IndexOf("NVIDIA") >= 0)
                pictureCPU.Image = Properties.Resources.nvidia;
            #endregion
            
        }
        
        /// <summary>
        /// Tao đường dẫn website
        /// </summary>
        /// <param name="sender">Đối tượng phát sinh ra event</param>
        /// <param name="e">Đối tượng e chứa danh sách các thuộc tính bổ xung khi đối tượng phát sinh event</param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("www.facebook.com/computer.nvt");
        }
        
        /// <summary>
        /// Lưu thông tin đã xem ra file
        /// </summary>
        /// <param name="sender">Đối tượng phát sinh ra event</param>
        /// <param name="e">Đối tượng e chứa danh sách các thuộc tính bổ xung khi đối tượng phát sinh event</param>
        private void button_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName,saveCPU+saveMain+saveMem+saveGra+saveBat+saveOS);
            }
        }
    }
}
