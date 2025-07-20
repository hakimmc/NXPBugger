using NXPBuggerCompiler;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[DllImport("kernel32.dll")]
static extern IntPtr GetConsoleWindow();

[DllImport("user32.dll")]
static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

string ascii = " _____                                                                   _____ \r\n( ___ )                                                                 ( ___ )\r\n |   |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|   | \r\n |   |     _   __ _  __  ____   ____   __  __ ______ ______ ______ ____  |   | \r\n |   |    / | / /| |/ / / __ \\ / __ ) / / / // ____// ____// ____// __ \\ |   | \r\n |   |   /  |/ / |   / / /_/ // __  |/ / / // / __ / / __ / __/  / /_/ / |   | \r\n |   |  / /|  / /   | / ____// /_/ // /_/ // /_/ // /_/ // /___ / _, _/  |   | \r\n |   | /_/ |_/ /_/|_|/_/    /_____/ \\____/ \\____/ \\____//_____//_/ |_|   |   | \r\n |___|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|___| \r\n(_____)                                                                 (_____)";
//main {

IntPtr hwnd = GetConsoleWindow();
ShowWindow(hwnd, 0);

if ((args.Length < 3)) return;

string configfileadrr = args[0];
string binfileaddr = args[1];
string cwafilename = args[2];
if(File.Exists(cwafilename))
{
    File.Delete(cwafilename);
}

NXPBugger.CreateCWA(configfileadrr, binfileaddr, cwafilename);
Console.WriteLine($"hakimmc;");
Console.WriteLine($"{ascii}");
Console.WriteLine($"{Path.GetFileName(binfileaddr)} converted to {Path.GetFileName(cwafilename)} [cwa]");
//}

