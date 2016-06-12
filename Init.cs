using System;
using System.IO;

/*
TODO: resolve resource conflict between opening file and 
writing to it.
*/

public class Init
{

    static private string OSType = "";
    static private string infopath = "/Users/chris/.csharpBootstrap";

    public static bool Bootstrap( bool debug )
    {
        if ( debug )
        {
            Console.WriteLine( "Debug mode activated." );
        }

        if (IsFirsttimeBoot())
        {
            GetOsName();
        }

        return false;
    }

    public static void GetOsName()
    {
        int osvalue = (int) Environment.OSVersion.Platform;
        if ((osvalue == 4) || (osvalue == 6) || (osvalue == 128))
        {
            Console.WriteLine("Currently using UNIX system.");
            if ( IsOsx() )
            {
                Console.WriteLine("Found ./DS_Store, assuming system is OS X");
                OSType = "OS X";
            }
            else
            {
                Console.WriteLine("Did not find DS_Store at root. System is like Linux or BSD.");
                OSType = "Unspecified UNIX or UNIX-like system.";
            }
        }
        else
        {
            Console.WriteLine("Not using UNIX or UNIX-like OS.");
            Console.WriteLine("Possibly Windows NT system.");
            Console.WriteLine("Further investigation...");
            if ( IsWindows() )
            {
                Console.WriteLine("Found evidence of NT based system.");
                OSType = "Windows NT";
            }
        }
        System.IO.File.WriteAllText(infopath, OSType);
    }

    public static bool IsOsx()
    {
        if (File.Exists( "/.DS_Store"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public static bool IsWindows()
    {
        OperatingSystem os = Environment.OSVersion;
        return false;
    }

    public static bool IsFirsttimeBoot()
    {
        if (File.Exists(infopath))
        {
            return false;
        }
        else
        {
            Console.WriteLine("Performing first-time boot.");
            File.Create(infopath);
            return true;
        }
    }
}