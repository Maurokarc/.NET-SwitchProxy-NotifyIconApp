using Microsoft.Win32;
using System;

namespace SwitchProxy
{
    internal static class ProxyHelper
    {
        /// <summary>
        /// Check current proxy is open or not
        /// </summary>
        /// <returns></returns>
        public static bool IsProxyOpened()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings"))
                {
                    int.TryParse(Convert.ToString(key?.GetValue("ProxyEnable")), out int index);
                    return index == 1;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Set Proxy open or close
        /// </summary>
        /// <param name="open"></param>
        /// <returns></returns>
        public static bool SetProxy(bool open)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true))
                {
                    if (key != null)
                    {
                        key.SetValue("ProxyEnable", open ? 1 : 0, RegistryValueKind.Unknown);
                        InternetHelper.ReloadSettings();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
