using Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLLInjector_RustClient
{
    class Program
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string Cmd, StringBuilder StrReturn, int ReturnLength, IntPtr HwndCallback);
        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = "DLLInjector-RustClient"; //Console Title
            //mp3 Play Music and This Music Repeated Tay-K - Return To Dreamland 4 :D
            mciSendString("play ReturnToDreamland4.mp3 repeat", null, 0, IntPtr.Zero);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Injecting DLL...");
            Mem rust = new Mem(); //Memory.dll.x64 Library :D
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "DLL File | *.dll";
            dialog.Title = "Select DLL File and This Program Automatic Inject DLL to RustClient.exe"; //Title
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                if (rust.OpenProcess("RustClient.exe"))
                {
                    rust.InjectDll(dialog.FileName); //Inject DLL with OpenFileDialog... Easy Code!!! :D
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Process Rust not Founded... Pls Try Open DLLInjector with Admin Privileges or Run RustClient.exe without EAC...");
                    Thread.Sleep(4500);
                    Environment.Exit(31781);
                }
            }
            else
            {
                // Set ForeGround Color to DarkRed as Canceled Injection DLL to This Process :D
                Console.ForegroundColor = ConsoleColor.DarkRed;
                // If u Canceled Injection, this injector is exiting with code 45(0x2d)
                Console.WriteLine("U Canceled Injection... Exiting With Code 45(0x2d)");
                Thread.Sleep(3000);
                Environment.Exit(45);
            }
            //Saying what Injection is Complete Successfully... print file name and that's all :D
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Injecting Complete... \nFileName: {dialog.FileName}\nWelcome to World of Cheats :D");
            Thread.Sleep(15000);
            Environment.Exit(43);
        }
    }
}
