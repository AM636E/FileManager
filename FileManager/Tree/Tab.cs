using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager
{
    public abstract class Tab
    {
        protected string folder;
        protected DirectoryInfo folderInfo;

        public bool IsActive { set; get; }
        public DirectoryInfo Root { get { return folderInfo.Root; } }
        public DirectoryInfo Folder { get { return folderInfo; } }
       // public string FullPath { get { return Root.Name + Folder.Name; } }

        public Tab(string folder)
        {
            this.folder = folder;
            folderInfo = new DirectoryInfo(folder);
        }

        public Utilites.FilesAndFolders GetFilesAndFolders()
        {
         /*   FilesAndFolders fnf = new FilesAndFolders();

            fnf.files = folderInfo.GetFiles();
            fnf.folders = folderInfo.GetDirectories();*/

           /* return fnf;*/
            return Utilites.GetFilesAndFolders(folderInfo);
        }
    }
}
