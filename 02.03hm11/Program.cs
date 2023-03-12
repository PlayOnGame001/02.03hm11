using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._03hm11
{
    interface interFile
    {
        void InputData();
        void InputText();
        void CreateFile();
        void DeleteFile();
    }
    interface interPath
    {
        void CreatePath();
    }
    class File : interFile, interPath
    {
        private string Name;
        private string Descrip;
        private string Text;
        private const string txt_file = ".txt";
        private string Patch;

        public File() { }
        public File(string Name, string Description)
        {
            this.Name = Name;
            this.Descrip = Description;
        }
        public void InputData()
        {
            if (Name == null && Descrip == null)
            {
                Console.Write("Enter name: ");
                Name = Console.ReadLine();
                Console.Write("Enter descrip: ");
                Descrip = Console.ReadLine();
            }
            else Console.WriteLine("Database");
        }
        public void InputText()
        {
            Console.Write("Enter text in file: ");
            Text = Console.ReadLine();
        }
        public void CreatePath()
        {
            Patch = Name + txt_file;
            Console.WriteLine("Path was created");
        }
        public void CreateFile()
        {
            FileStream File = new FileStream(Patch, FileMode.Create);
            StreamWriter SW = new StreamWriter(File);
            Console.WriteLine("Created file");
            SW.WriteLine($"Name:{Name}");
            SW.WriteLine($"Descrip:{Descrip}");
            SW.WriteLine();
            SW.WriteLine(Text);
            Console.WriteLine("Add data");
            SW.Close();
        }
        public void DeleteFile()
        {
            Console.Write("path: ");
            string LocalPath = Console.ReadLine();
            FileInfo File = new FileInfo(LocalPath);
            if (File.Exists)
            {
                File.Delete();
                Console.WriteLine("Deleted file");
            }
            else Console.WriteLine("Error");
        }
    }
    class Program
    {
        static void Main()
        {
            File Obj = new File();
            Obj.InputData();
            Obj.InputText();
            Obj.CreatePath();
            Obj.CreateFile();
            Obj.DeleteFile();
        }
    }
}