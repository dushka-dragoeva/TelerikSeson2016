using Composite.Models;

namespace Composite
{
    public class Program
    {
        public static void Main()
        {
            var programFilesFolder = new Folder("Program Files");

            var whoCrashedFolder = new Folder("WhoCrashed");
            whoCrashedFolder.Add(new File("readme.txt"));
            whoCrashedFolder.Add(new File("rspCrash32.inf"));
            whoCrashedFolder.Add(new File("rspCrash32.sys"));
            whoCrashedFolder.Add(new File("rspCrash64.inf"));
            whoCrashedFolder.Add(new File("rspCrash64.sys"));
            whoCrashedFolder.Add(new File("rspSymSrv32.dll"));
            whoCrashedFolder.Add(new File("symsrv.dll"));
            whoCrashedFolder.Add(new File("unins000.dat"));
            whoCrashedFolder.Add(new File("unins000.exe"));
            whoCrashedFolder.Add(new File("WhoCrashed.exe"));
            whoCrashedFolder.Add(new File("WhoCrashed32.dll"));
            whoCrashedFolder.Add(new File("WhoCrashedEx.exe"));
            whoCrashedFolder.Add(new File("LICENSE.TXT"));

            programFilesFolder.Add(whoCrashedFolder);

            var versionFolder = new Folder("3.0");
            var binFolder = new Folder("bin");
            binFolder.Add(new File("mongod.exe"));
            binFolder.Add(new File("..."));
            versionFolder.Add(binFolder);
            versionFolder.Add(new File("GNU-AGPL-3.0"));
            versionFolder.Add(new File("README"));
            versionFolder.Add(new File("THIRD-PARTY-NOTICES"));
            var serverFolder = new Folder("Server");
            serverFolder.Add(versionFolder);
            var mongoDbFolder = new Folder("MongoDB");
            mongoDbFolder.Add(serverFolder);
            programFilesFolder.Add(mongoDbFolder);

            programFilesFolder.Print(0);
        }
    }
}
