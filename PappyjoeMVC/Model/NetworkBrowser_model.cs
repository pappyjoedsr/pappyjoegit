﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security;

namespace PappyjoeMVC.Model
{
   public sealed class NetworkBrowser_model
    {
        [DllImport("Netapi32", CharSet = CharSet.Auto, SetLastError = true),
          SuppressUnmanagedCodeSecurityAttribute]
        public static extern int NetServerEnum(
              string ServerNane, // must be null
              int dwLevel,
              ref IntPtr pBuf,
              int dwPrefMaxLen,
              out int dwEntriesRead,
              out int dwTotalEntries,
              int dwServerType,
              string domain, // null for login domain
              out int dwResumeHandle
              );
        [DllImport("Netapi32", SetLastError = true),
          SuppressUnmanagedCodeSecurityAttribute]
        public static extern int NetApiBufferFree(
             IntPtr pBuf);
        //create a _SERVER_INFO_100 STRUCTURE
        [StructLayout(LayoutKind.Sequential)]
        public struct _SERVER_INFO_100
        {
            internal int sv100_platform_id;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string sv100_name;
        }
        public ArrayList getNetworkComputers()
        {
            //local fields
            ArrayList networkComputers = new ArrayList();
            const int MAX_PREFERRED_LENGTH = -1;
            int SV_TYPE_WORKSTATION = 1;
            int SV_TYPE_SERVER = 2;
            IntPtr buffer = IntPtr.Zero;
            IntPtr tmpBuffer = IntPtr.Zero;
            int entriesRead = 0;
            int totalEntries = 0;
            int resHandle = 0;
            int sizeofINFO = Marshal.SizeOf(typeof(_SERVER_INFO_100));
            try
            {
                //call the DllImport : NetServerEnum with all its required parameters
                //see http://msdn.microsoft.com/library/default.asp?url=/library/en-us/netmgmt/netmgmt/netserverenum.asp
                //for full details of method signature
                int ret = NetServerEnum(null, 100, ref buffer, MAX_PREFERRED_LENGTH,
                    out entriesRead,
                    out totalEntries, SV_TYPE_WORKSTATION | SV_TYPE_SERVER, null, out
                    resHandle);
                //if the returned with a NERR_Success (C++ term), =0 for C#
                if (ret == 0)
                {
                    //loop through all SV_TYPE_WORKSTATION and SV_TYPE_SERVER PC's
                    for (int i = 0; i < totalEntries; i++)
                    {
                        //get pointer to, Pointer to the buffer that received the data from
                        //the call to NetServerEnum. Must ensure to use correct size of 
                        //STRUCTURE to ensure correct location in memory is pointed to
                        tmpBuffer = new IntPtr((int)buffer + (i * sizeofINFO));
                        //Have now got a pointer to the list of SV_TYPE_WORKSTATION and 
                        //SV_TYPE_SERVER PC's, which is unmanaged memory
                        //Needs to Marshal data from an unmanaged block of memory to a 
                        //managed object, again using STRUCTURE to ensure the correct data
                        //is marshalled 
                        _SERVER_INFO_100 svrInfo = (_SERVER_INFO_100)
                            Marshal.PtrToStructure(tmpBuffer, typeof(_SERVER_INFO_100));

                        //add the PC names to the ArrayList
                        networkComputers.Add(svrInfo.sv100_name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem with acessing network computers in NetworkBrowser " +
                    "\r\n\r\n\r\n" + ex.Message,
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                //The NetApiBufferFree function frees 
                //the memory that the NetApiBufferAllocate function allocates
                NetApiBufferFree(buffer);
            }
            //return entries found
            return networkComputers;
        }
    }
}
