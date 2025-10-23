namespace Labor4
{
    public partial class Form1 : Form
    {
        string curDir;
        string[] predkatalog = new string[200];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string dirName = "C://";
            predkatalog[0] = dirName;
            listBox1.Items.Add("��������");
            if (Directory.Exists(dirName))
            {
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    // ���������� ����� � ���������� Hidden � System
                    var attributes = File.GetAttributes(s);
                    if ((attributes & FileAttributes.Hidden) != 0 || (attributes & FileAttributes.System) != 0)
                    {
                        continue;
                    }
                    listBox1.Items.Add(s);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string chosenDirectory = listBox1.SelectedItem.ToString();
            listBox1.Items.Clear();
            listBox1.Items.Add("��������");
            if (Directory.Exists(chosenDirectory))
            {
                //listBox1.Items.Add(chosenDirectory);
                string[] dirs = Directory.GetDirectories(chosenDirectory);
                foreach (string s in dirs)
                {
                    var attributes = File.GetAttributes(s);
                    if ((attributes & FileAttributes.Hidden) != 0 || (attributes & FileAttributes.System) != 0)
                    {
                        continue;
                    }
                    listBox1.Items.Add(s);
                }
                listBox1.Items.Add(" ");
                listBox1.Items.Add("�����");
                string[] files = Directory.GetFiles(chosenDirectory);
                foreach (string s in files)
                {
                    listBox1.Items.Add(s);
                }


            }
            curDir = chosenDirectory;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string parDir = Convert.ToString(Directory.GetParent(curDir));

            if (parDir != null)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("��������");
                if (Directory.Exists(parDir))
                {
                    string[] dirs = Directory.GetDirectories(parDir);
                    foreach (string s in dirs)
                    {
                        // ���������� ����� � ���������� Hidden � System
                        var attributes = File.GetAttributes(s);
                        if ((attributes & FileAttributes.Hidden) != 0 || (attributes & FileAttributes.System) != 0)
                        {
                            continue;
                        }
                        listBox1.Items.Add(s);
                    }
                    listBox1.Items.Add(" ");
                    listBox1.Items.Add("�����");
                    string[] files = Directory.GetFiles(parDir);
                    foreach (string s in files)
                    {
                        listBox1.Items.Add(s);
                    }
                }
            }
            else { MessageBox.Show("�� ���������� � �������� ��������!"); }
            curDir = parDir;

        }

    }
}