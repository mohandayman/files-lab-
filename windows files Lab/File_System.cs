using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;

namespace WindowsFormsApp1
{
    public partial class File_System : Form
    {
        DriveInfo[] All_Drives;

        /*      var current_Dirctory = Directory.SetCurrentDirectory("");*/



        public File_System()
        {
            InitializeComponent();
            All_Drives = DriveInfo.GetDrives();
            listBox1.Items.AddRange(All_Drives);
            listBox2.Items.AddRange(All_Drives);








        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }





        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem.ToString() != textBox1.Text)      // check of click The Same Path

                textBox1.Text = listBox1.SelectedItem.ToString();   // change Text box To path 

            var selected_item = listBox1.SelectedItem;

            DirectoryInfo parent_selected = Directory.GetParent(textBox1.Text);  //  parent 

            string root_selected_path = Directory.GetDirectoryRoot(textBox1.Text);  // root path 

            var root_selected = new DirectoryInfo(root_selected_path); //  root obj 


            listBox1.Items.Clear();

            listBox1.Items.Add(selected_item);

            if (parent_selected != null)  // check of The root Directory
            {
                listBox1.Items.Add(parent_selected);

                listBox1.Items.Add(root_selected);
            }


            if (selected_item is DirectoryInfo || selected_item is Directory || selected_item is DriveInfo)
            {
                string[] sub_directories_Paths = Directory.GetDirectories(textBox1.Text);

                foreach (string subdir in sub_directories_Paths)
                {

                    DirectoryInfo sub_Directory = new DirectoryInfo(subdir);

                    listBox1.Items.Add(sub_Directory);


                }

                string[] sub_Files_Paths = Directory.GetFiles(textBox1.Text);
                foreach (string subFile in sub_Files_Paths)
                {
                    listBox1.Items.Add(new FileInfo(subFile));
                }


            }
            else
                Process.Start("notepad.exe", textBox1.Text);










        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox2.SelectedItem.ToString() != textBox2.Text)      // check of click The Same Path

                textBox2.Text = listBox2.SelectedItem.ToString();   // change Text box To path 

            var selected_item = listBox2.SelectedItem;

            DirectoryInfo parent_selected = Directory.GetParent(textBox2.Text);  //  parent 

            string root_selected_path = Directory.GetDirectoryRoot(textBox2.Text);  // root path 

            var root_selected = new DirectoryInfo(root_selected_path); //  root obj 


            listBox2.Items.Clear();

            listBox2.Items.Add(selected_item);

            if (parent_selected != null)  // check of The root Directory
            {
                listBox2.Items.Add(parent_selected);

                listBox2.Items.Add(root_selected);
            }

            if (selected_item is DirectoryInfo || selected_item is Directory || selected_item is DriveInfo)
            {

                string[] sub_directories_Paths = Directory.GetDirectories(textBox2.Text);

                foreach (string subdir in sub_directories_Paths)
                {

                    DirectoryInfo sub_Directory = new DirectoryInfo(subdir);

                    listBox2.Items.Add(sub_Directory);


                }

                string[] sub_Files_Paths = Directory.GetFiles(textBox2.Text);
                foreach (string subFile in sub_Files_Paths)
                {
                    listBox2.Items.Add(new FileInfo(subFile));
                }


            }
            else
                Process.Start("notepad.exe", textBox2.Text);




        }

        private void button1_Click(object sender, EventArgs e)
        {
            string source_path = $"{textBox1.Text}";
            string Destnation_path = $"{textBox2.Text}";

            if (Directory.Exists(Destnation_path))
            {
                DirectoryInfo d1 = new DirectoryInfo(source_path);
                string Dest_folder_name = d1.Name;
                Directory.Move(source_path, $@"{Destnation_path}\{Dest_folder_name}");

            }
            else
            {
                Directory.Move(source_path, Destnation_path);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string source_path = $"{textBox2.Text}";
            string Destnation_path = $"{textBox1.Text}";

            if (Directory.Exists(Destnation_path))
            {
                DirectoryInfo d1 = new DirectoryInfo(source_path);
                string Dest_folder_name = d1.Name;
                Directory.Move(source_path, $@"{Destnation_path}\{Dest_folder_name}");
                //Directory.Delete(source_path);
            }
            else
            {
                Directory.Move(source_path, Destnation_path);

            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime List1_LastAccess;
            DateTime List2_LastAccess;

            if (Directory.Exists(textBox1.Text))
            {
                List1_LastAccess = Directory.GetLastAccessTime(textBox1.Text);
            }
            else
            {
                List1_LastAccess = File.GetLastAccessTime(textBox1.Text);
            }


            if (Directory.Exists(textBox2.Text))
            {

                List2_LastAccess = Directory.GetLastAccessTime(textBox2.Text);
            }
            else
            {
                List2_LastAccess = File.GetLastAccessTime(textBox2.Text);
            }


            var result = DateTime.Compare(List1_LastAccess, List2_LastAccess);

            if (result > 0)
            {
                if (Directory.Exists(textBox1.Text))
                    Directory.Delete(textBox1.Text, true);
                else
                    File.Delete(textBox1.Text);
            }
            else
            {
                if (Directory.Exists(textBox2.Text))
                {
                    Directory.Delete(textBox2.Text, true);
                }
                else
                {
                    File.Delete(textBox2.Text);
                }

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DirectoryInfo parent_selected1;
            DirectoryInfo parent_selected2;

            DateTime List1_LastAccess;
            DateTime List2_LastAccess;
            if (Directory.Exists(textBox1.Text))
            {
                List1_LastAccess = Directory.GetLastAccessTime(textBox1.Text);
            }
            else
            {
                List1_LastAccess = File.GetLastAccessTime(textBox1.Text);
            }


            if (Directory.Exists(textBox2.Text))
            {

                List2_LastAccess = Directory.GetLastAccessTime(textBox2.Text);
            }
            else
            {
                List2_LastAccess = File.GetLastAccessTime(textBox2.Text);
            }


            var result = DateTime.Compare(List1_LastAccess, List2_LastAccess);

            if (result > 0)
            {

                parent_selected1 = Directory.GetParent(textBox1.Text);  //  parent 
                change_directory(parent_selected1,listBox1);

            }
            else
            {
                parent_selected2 = Directory.GetParent(textBox2.Text);  //  parent 
                change_directory(parent_selected2, listBox2);





            }
        }




        public void change_directory(DirectoryInfo parent , ListBox listbox)
        {
            if (parent != null) { 
            textBox1.Text = parent.Name;
            

            DirectoryInfo parent_selected = Directory.GetParent(parent.Name);  //  parent 

            string root_selected_path = Directory.GetDirectoryRoot(parent.Name);  // root path 

            var root_selected = new DirectoryInfo(root_selected_path); //  root obj 


            listbox.Items.Clear();

            listbox.Items.Add(parent);

            if (parent_selected != null)  // check of The root Directory
            {
                listbox.Items.Add(parent_selected);

                listbox.Items.Add(root_selected);
            }


                if (Directory.Exists(parent.Name))
                {
                    string[] sub_directories_Paths = Directory.GetDirectories(parent.Name);

                    foreach (string subdir in sub_directories_Paths)
                    {

                        DirectoryInfo sub_Directory = new DirectoryInfo(subdir);

                        listbox.Items.Add(sub_Directory);


                    }

                    string[] sub_Files_Paths = Directory.GetFiles(textBox1.Text);
                    foreach (string subFile in sub_Files_Paths)
                    {
                        listbox.Items.Add(new FileInfo(subFile));
                    }

                }
            }
           



        }
    }
}
