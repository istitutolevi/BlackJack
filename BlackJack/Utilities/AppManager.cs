using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BlackJack.Utilities
{
    internal class AppManager
    {
        internal static readonly string DeveloperName = "Efe Omoregie Elijah";
        internal static readonly string DeveloperUrl = "http://elijahefe.com";
        internal static readonly string DeveloperEmail = "donddoug@gmail.com";
        internal static readonly string DeveloperInfo = "C/C++, C#, PHP, SQL and Javascript Developer";
        internal static readonly string RegistryInitialOpenDirectory = "InitialOpenDirectory";
        internal static readonly string RegistryInitialSaveDirectory = "InitialSaveDirectory";
        internal static readonly string RegistryAudioVolume = "AudioVolume";
        internal static readonly string RegistryApplicationArgs = "ApplicationArgs";
        internal static string RegistryKey
        {
            get { return @"HKEY_LOCAL_MACHINE\SOFTWARE\" + AppName; }
        }
        internal static int MaximumIstancesAllowed = 1;
        internal static bool PassArgsToLastInstance = true;
        internal static string AppName = "MDMediaPlayer";
        internal static string AppVersion = "v1.0";
        internal static DateTime LastUpdate = new DateTime(2015, 8, 17);

        internal static void Run(string[] Args)
        {
            if (!MaximumInstanceReached(Args))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Main(Args));
            }
        }
        static bool MaximumInstanceReached(string[] Args)
        {
            if (MaximumIstancesAllowed <= 0)
                MaximumIstancesAllowed = 1;

            // Get the current process 
            Process currentProcess = Process.GetCurrentProcess();
            int count = 0;

            Process lastProcess = null;
            foreach (Process p in Process.GetProcesses())
            {
                // Check running process 
                if (p.Id != currentProcess.Id & p.ProcessName.Equals(currentProcess.ProcessName) == true)
                {
                    lastProcess = p;
                    count++;
                }
            }

            if (count >= MaximumIstancesAllowed & PassArgsToLastInstance & lastProcess != null)
            {
                IntPtr handleFound = lastProcess.MainWindowHandle;
                //Check application is not iconic mode then bring to front
                if (!NativeMethods.IsIconic(handleFound))
                {
                    NativeMethods.ShowWindow(handleFound, NativeMethods.SW_SHOW);
                    NativeMethods.SetForegroundWindow(handleFound);
                }
                if (Args.Length != 0)
                {
                    Registry.SetValue(RegistryKey, RegistryApplicationArgs, Args);
                    NativeMethods.PostMessage(handleFound, NativeMethods.WM_STRINGDATA, 0, 0);
                }
            }
            return !(count < MaximumIstancesAllowed);
        }
    }
}
