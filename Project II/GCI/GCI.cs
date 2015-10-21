//.................Get Computer Information...................
//......................Version: 1.0.0........................
//.......................October 2015.........................
//..................Tác giả: Nguyễn Văn Tú....................
//...............www.facebook.com/computer.nvt................
//............GCI là mã nguồn mở có thể tùy biến..............

using System;
using System.Management;

namespace GCI
{

    /// <summary>
    /// Class GCI xử lí và đưa ra thông tin cần lấy
    /// </summary>
    public static class GCI
    {
        /// <summary>
        /// Truy vấn thông tin máy tính thông qua WMI và trả về kết quả tương ứng
        /// </summary>
        /// <param name="Class">Tên lớp trong WMI</param>
        /// <param name="Resuft">Thuộc tính cần lấy thông tin trong lớp </param>
        /// <returns>Trả về thông tin tương ứng dạng chuỗi kí tự</returns>
        public static String GetInfo(string Class, string Resuft)
        {
            //Khởi tạo lớp ManagementObjectSearcher của WMI với Class là lớp đại diện cho một tập thuộc tính Resuft
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + Class);

            foreach (ManagementObject wmi in searcher.Get())
            {   //Bẫy lỗi nếu không đúng cú pháp hoặc không tìm kiếm được trả về giá trị tên Resuft + ": Unknown"
                try
                {
                    return wmi.GetPropertyValue(Resuft).ToString();
                }

                catch { }

            }

            return Resuft + ": Unknown";
        }
        /// <summary>
        /// Truy vấn thông tin dung lượng Ram qua Class "Win32_PhysicalMemory" và tính tổng tất cả dung lượng của các Ram
        /// </summary>
        /// <returns>Trả về Giá trị dung lượng Ram dạng chuỗi kí tự MB</returns>
        public static string GetRamSize()
        {
            //Truy vấn thông qua Class ManagementScope
            ManagementScope oMs = new ManagementScope();
            ObjectQuery oQuery = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
            ManagementObjectCollection oCollection = oSearcher.Get();

            long MemSize = 0;
            long mCap = 0;

            //
            foreach (ManagementObject obj in oCollection)
            {
                mCap = Convert.ToInt64(obj["Capacity"]);
                MemSize += mCap;
            }
            MemSize = (MemSize / 1024) / 1024;
            return MemSize.ToString() + "MB";
        }
        /// <summary>
        /// Truy vấn thông tin về số khe Ram và trả về giá trị tương ứng
        /// </summary>
        /// <returns>Trả về số khe cắm Ram dạng chuỗi kí tự</returns>
        public static string GetNoRamSlots()
        {

            int MemSlots = 0;
            //Truy vấn thông qua Class ManagementScope
            ManagementScope oMs = new ManagementScope();
            ObjectQuery oQuery2 = new ObjectQuery("SELECT MemoryDevices FROM Win32_PhysicalMemoryArray");
            ManagementObjectSearcher oSearcher2 = new ManagementObjectSearcher(oMs, oQuery2);
            ManagementObjectCollection oCollection2 = oSearcher2.Get();
            foreach (ManagementObject obj in oCollection2)
            {
                MemSlots = Convert.ToInt32(obj["MemoryDevices"]);

            }
            return MemSlots.ToString();
        }
    }
}
