using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FileManager
{
    public static partial class Utilites
    {
        public struct FilesAndFolders
        {
            public DirectoryInfo[] folders;
            public FileInfo[] files;

            public bool Ok { get; set; }

            public FilesAndFolders(DirectoryInfo dir):this()
            {                
                try
                {
                    files = dir.GetFiles();
                    folders = dir.GetDirectories();
                    Ok = true;
                }
                catch
                {
                    Ok = false;
                }
            }

            public bool IsEmpty()
            {
                return(Ok == true) ? !( folders.Length != 0 || files.Length != 0 ) : false;
            }
        }

        public static FilesAndFolders GetFilesAndFolders(DirectoryInfo folderInfo)
        {
            FilesAndFolders fnf = new FilesAndFolders();
            try
            {
                fnf.files = folderInfo.GetFiles();
                fnf.folders = folderInfo.GetDirectories();
                fnf.Ok = true;
            }
            catch
            {
                fnf.Ok = false;
            }
            return fnf;
        }

        public static void AddInTreeNode(DirectoryInfo dir, TreeView tree, TreeNode node)
        {
            FilesAndFolders fnf = new FilesAndFolders(dir);
        }

        public static void ExpandFolderInTreeView(DirectoryInfo dir, TreeNode node)
        {
            Utilites.FilesAndFolders fnf = Utilites.GetFilesAndFolders(dir);

            if (fnf.IsEmpty() == false && fnf.Ok == true && node.Nodes.Count == 0)
            {
                AddSubNodes(dir, node);

                DirectoryInfo[] childs = dir.GetDirectories();
                TreeNode subNode;
                for (var i = 0; i < childs.Length; i++)
                {
                    subNode = new TreeNode(childs[i].Name);
                    AddSubNodes(childs[i], subNode);

                    subNode.Nodes[i].Nodes.Add(subNode);
                }
           }
        }

        public static void AddSubNodes(DirectoryInfo dir, TreeNode node)
        {
            DirectoryInfo[] dirs = dir.GetDirectories();
            AddSubDirs(dirs, node);
            DirectoryInfo subDir;

            for (int i = 0; i < dirs.Length; i++)
            {
                try
                {
                    subDir = dirs[i];
                    AddSubDirs(subDir.GetDirectories(), node.Nodes[i]);
                    AddSubFiles(subDir.GetFiles(), node.Nodes[i]);
                }
                catch { }
            }

            AddSubFiles(dir.GetFiles(), node);
        }

        static void AddSubDirs(DirectoryInfo[] dirs, TreeNode node)
        {
            try
            {
                TreeNode subNode;

                foreach (DirectoryInfo dir in dirs)
                {
                    subNode = new TreeNode(dir.Name);

                    node.Nodes.Add(subNode);
                }
            }
            catch (Exception e)
            {
                Log(e.Message);
            }
        }

        static void Log(string s)
        {
            //log
        }

        static void AddSubFiles(FileInfo[] files, TreeNode node)
        {
            try
            {
                TreeNode subNode;

                foreach (FileInfo file in files)
                {
                    subNode = new TreeNode(file.Name);

                    node.Nodes.Add(subNode);
                }
            }
            catch (Exception e)
            {
                Log(e.Message);
            }
        }
    }
}
