using Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLLInjector_RustClient
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = "DLLInjector-RustClient"; //Console Title
            Console.WriteLine("Injecting DLL...");
            Mem rust = new Mem(); //Memory.dll.x64 Library :D
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "DLL Injector | *.dll";
            dialog.Title = "Select DLL File and This Program Automatic Inject DLL to RustClient.exe"; //Title
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                rust.OpenProcess("RustClient.exe");
                rust.InjectDll(dialog.FileName); //Inject DLL with OpenFileDialog... Easy Code!!! :D
            }
            else
            {
                // If u Canceled Injection... 
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
