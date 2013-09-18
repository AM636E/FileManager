using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace FileManager
{
    public partial class FileManagerForm1 : Form
    {
        TreeTab _folderTree;
        public FileManagerForm1()
        {
            InitializeComponent();


            _folderTree = new TreeTab(@"E:\OpenGL");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void FileManagerForm1_Load(object sender, EventArgs e)
        {
            TreeNode main = new TreeNode(_folderTree.Folder.Name);
            this._treeTest.Nodes.Add(main);
            Utilites.AddSubNodes(_folderTree.Folder, this._treeTest.Nodes[0]);
        }

        private void _treeTest_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void _treeTest_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            DirectoryInfo dir = new DirectoryInfo( this._folderTree.Root.Name + node.FullPath);

            Utilites.AddSubNodes(dir.GetDirectories()[0], node);
        }
    }

    public partial class TreeTab
    {
        public void AddInTreeNode(TreeView target)
        {
            ArrayList documents = new ArrayList();

            TreeNode folder = new TreeNode(this.folderInfo.Name);

            Utilites.FilesAndFolders fnf = GetFilesAndFolders();
            TreeNode fld;

            foreach (DirectoryInfo dir in fnf.folders)
            {
                fld = new TreeNode(dir.Name);
                folder.Nodes.Add(fld);
            }

            target.Nodes.Add(folder);
        }
    }
}
