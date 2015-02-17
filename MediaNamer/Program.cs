using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;

namespace MediaNamer
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                return;
            }

            DirectoryInfo targetDir;
            var showTitle = args[1];
            var season = args[2];


            try
            {
                targetDir = new DirectoryInfo(args[0]);
                FileInfo[] files = targetDir.GetFiles();
                int count = 1;
                string newName;
                ArrayList includes = new ArrayList {".avi", ".mp4", ".mkv", ".wmv", ".mpeg", ".mpg", ".qt", ".mov"};

                if(args.Length > 3)
                {
                    var additionals = args[3].Split(',');
                    foreach(string ext in additionals)
                    {
                        if (ext.StartsWith(".") != true)
                            includes.Add("." + ext.Trim());
                        else
                            includes.Add(ext.Trim());
                    }
                }

                foreach (FileInfo f in files)
                {
                    if(f.IsReadOnly || f.Exists != true || includes.Contains(f.Extension) != true)
                        continue;

                    newName   = f.FullName;
                    newName   = newName.Substring(0, newName.LastIndexOf("\\") + 1);
                    newName   += showTitle + " - s";

                    if ( Int32.Parse(season) < 10)
                        newName += "0";

                    newName += season + "e";

                    if (count < 10)
                        newName += "0";

                    newName += count + f.Extension;
                    
                    Console.Write("Renaming: \"{0}\" to: \"{1}\"...", f.Name, newName.Substring(newName.LastIndexOf("\\") + 1) );
                    File.Move(f.FullName, newName);
                    Console.WriteLine("Done");
                    ++count;
                }
            }
            catch(DirectoryNotFoundException e2)
            {
                Console.WriteLine(e2.Message);
                Console.WriteLine("Does the path contain spaces? If so, try surrounding it with quotes (\"\")");
            }
            catch(Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }
    }
}
