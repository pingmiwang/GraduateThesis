using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ThreadFunc tf = new ThreadFunc();
        private void RankDic_Click(object sender, EventArgs e)
        {
            logText.Text = "";
            string dics = FileRW.FileRead(FileRW.FilePath("dicPath"));
            string[] dicsOrder = FileRW.OrderDic(dics);
            File.WriteAllLines(FileRW.FilePath("dicOrderPath"), dicsOrder, Encoding.UTF8);
            foreach (string s in dicsOrder)
                logText.Text += s + "\r\n";
        }

        private void Token_Click(object sender, EventArgs e)
        {
            Thread threadToken = new Thread(new ParameterizedThreadStart(tf.TrainAnnotation));
            threadToken.IsBackground = true;
            threadToken.Start();
            threadToken.Join();
            logText.Text = FileRW.FileRead(FileRW.FilePath("trainTokenPath"));
        }



        private void TestToken_Click(object sender, EventArgs e)
        {
            Thread threadToken = new Thread(new ParameterizedThreadStart(tf.TestAnnotation));
            threadToken.IsBackground = true;
            threadToken.Start();
            threadToken.Join();
            logText.Text = FileRW.FileRead(FileRW.FilePath("testTokenPath"));
        }



        private void Train_Click(object sender, EventArgs e)
        {

            Thread thread1 = new Thread(new ParameterizedThreadStart(tf.TrainCRFs));
            thread1.IsBackground = true;
            thread1.Start();
            thread1.Join();
            resultState.Text = "已完成--Train";
        }

        private void OutSourceTest_Click(object sender, EventArgs e)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            FileRW.outTestSource = outTest0.Text;
            Thread thread1 = new Thread(new ParameterizedThreadStart(tf.OutTestAnnotation));
            thread1.IsBackground = true;
            thread1.Start();
            thread1.Join();
            StringBuilder single = new StringBuilder();
            single.Append("基本术语是：\r\n");
            foreach (string s in (FileRW.outTest[0]))
            {
                single.Append( s + "；");                
            }
            single.Append("\r\n\r\n合成术语是：\r\n");
            foreach (string s1 in (FileRW.outTest[1]))
            {
                single.Append(s1 + "；");
            }
            testResults.Text = single.ToString();
        }

        private void Caculation_Click(object sender, EventArgs e)
        {
            string TestSorce = Regex.Replace(FileRW.FileRead(FileRW.FilePath("result_file")), @"[\t]", "");
            (new FileRW()).Caculate(TestSorce);
            stateLable.Text = FileRW.FileRead(FileRW.FilePath("ResultCalcu"));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addCoreTerm_Click(object sender, EventArgs e)
        {
            FileStream aFile = new FileStream(FileRW.FilePath("dicPath"), FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(aFile, Encoding.UTF8);
            sw.WriteLine(logText.Text);
            sw.Close();
            aFile.Close();
            logText.Text = "添加成功";
        }

        private void pathInput_Click(object sender, EventArgs e)
        {
            FileRW.pathHeader2 = pathHeader.Text;
            pathState.Text = "配置成功，文件路夹径为：" + pathHeader.Text;
        }

        private void rePath_Click(object sender, EventArgs e)
        {
            FileRW.pathHeader2 = "";
            pathHeader.Text = "";
            pathState.Text = "请输入文件路径：";
        }


        private void Test_Click_1(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ParameterizedThreadStart(tf.TestCRFs));
            thread1.IsBackground = true;
            thread1.Start();
            thread1.Join();
            resultState.Text = "已完成--Test";
        }

        private void newTerms_Click(object sender, EventArgs e)
        {
            string TestSorce = Regex.Replace(FileRW.FileRead(FileRW.FilePath("result_file")), @"[\t]", "");
            List<String> l = (new FileRW()).CacuWithWords(TestSorce);
            StringBuilder sbResult = new StringBuilder();
            foreach (string s in l)
            {
                sbResult.Append(s + "\r\n");
            }
            //保存到txt文档
            File.AppendAllText(FileRW.FilePath("ResultCalcu"), "\r\n以下是正确抽取出的术语:", Encoding.Default);
            File.AppendAllText(FileRW.FilePath("ResultCalcu"), sbResult.ToString(), Encoding.Default);
            stateLable.Text = sbResult.ToString();
        }

        private void addFeatures_Click(object sender, EventArgs e)
        {

        }





    }
}
