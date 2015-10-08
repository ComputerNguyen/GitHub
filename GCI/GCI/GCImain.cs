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
        //
        //Get Information
        //
        private void GCImain_Load(object sender, EventArgs e)
        {
            //
            //Get CPU Info
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
            //Open Picture Of Processor
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
            //groupBaseBoard
            txtMainManufacturer.Text = GCI.GetInfo("Win32_BaseBoard", "Manufacturer");
            txtMainCaption.Text = GCI.GetInfo("Win32_BaseBoard", "Caption");
            txtMainProduct.Text = GCI.GetInfo("Win32_BaseBoard", "Product");
            txtMainVersion.Text = GCI.GetInfo("Win32_BaseBoard", "Version");
            txtMainSerial.Text = GCI.GetInfo("Win32_BaseBoard", "SerialNumber");
            //groupBios
            txtBiosManufacturer.Text = GCI.GetInfo("Win32_BIOS", "Manufacturer");
            txtBiosReleaseDate.Text = GCI.GetInfo("Win32_BIOS", "ReleaseDate");
            txtBiosSMBios.Text = GCI.GetInfo("Win32_BIOS", "SMBIOSBIOSVersion");
            txtBiosVersion.Text = GCI.GetInfo("Win32_BIOS","Version");
            txtBiosSerialNumber.Text = GCI.GetInfo("Win32_BIOS", "SerialNumber");
            //
            #endregion
            //
            //Get Memory Information
            //
            #region
            //
            //Disk Device Information
            //
            txtDiskModel.Text = GCI.GetInfo("Win32_DiskDrive", "Model");
            txtDiskSerialNumber.Text = GCI.GetInfo("Win32_DiskDrive", "SerialNumber");
            txtDiskSize.Text = GCI.GetInfo("Win32_DiskDrive", "Size");
            txtDiskPartitions.Text = GCI.GetInfo("Win32_DiskDrive", "Partitions");
            txtDiskBytesPerSector.Text = GCI.GetInfo("Win32_DiskDrive", "BytesPerSector");
            txtDiskTotalSectors.Text = GCI.GetInfo("Win32_DiskDrive", "TotalSectors");
            txtDiskInterfaceType.Text = GCI.GetInfo("Win32_DiskDrive", "InterfaceType");
            txtDiskTotalCylinders.Text = GCI.GetInfo("Win32_DiskDrive", "TotalCylinders");
            //
            //Ram Information
            //
            txtRamTotalSize.Text = GCI.GetRamSize();
            txtRamSlots.Text = GCI.GetNoRamSlots();
            txtRamManufacturer.Text = GCI.GetInfo("Win32_PhysicalMemory", "Manufacturer");
            txtRamSpeed.Text = GCI.GetInfo("Win32_PhysicalMemory", "Speed");
            //
            #endregion
            //
            //Get Battery Information
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
            //Get Information Operating System
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
        //
        //Get Graphics Information
        //
        #region
        //
        //Select Display Device and Get info 
        //
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            
            string res = comboBox1.SelectedItem.ToString();
            if (res== "Win32_DisplayControllerConfiguration")
            //
            //Select Display Controller Configuration
            //
            {
                txtGPUBitsPerPel.Text = GCI.GetInfo(res, "BitsPerPixel");
                txtGPUCaption.Text = GCI.GetInfo(res, "Caption");
                txtGPUDisplay.Text = GCI.GetInfo(res, "RefreshRate");
                txtGPUPelsHeight.Text = GCI.GetInfo(res, "HorizontalResolution");
                txtGPUPelsWidth.Text = GCI.GetInfo(res, "VerticalResolution");
                txtGPULogPixels.Text = GCI.GetInfo(res, "LogPixels");
                txtGPUVideoMode.Text = GCI.GetInfo(res, "VideoMode");
            }
            else
            //
            //Select Display Configuration
            //
            {
                txtGPUBitsPerPel.Text = GCI.GetInfo(res, "BitsPerPel");
                txtGPUCaption.Text = GCI.GetInfo(res, "Caption");
                txtGPUDisplay.Text = GCI.GetInfo(res, "DisplayFrequency");
                txtGPUPelsHeight.Text = GCI.GetInfo(res, "PelsHeight");
                txtGPUPelsWidth.Text = GCI.GetInfo(res, "PelsWidth");
                txtGPULogPixels.Text = GCI.GetInfo(res, "LogPixels");
                txtGPUVideoMode.Text = GCI.GetInfo(res, "VideoMode");
            }
                      
        }

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
