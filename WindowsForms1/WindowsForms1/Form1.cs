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
            string dics = FileRW.FileRead(FileRW.FilePath("dicPath"));
            string[] dicsOrder = FileRW.OrderDic(dics);
            File.WriteAllLines(FileRW.FilePath("dicOrderPath"), dicsOrder, Encoding.UTF8);
            stateLable.Text = "已完成--rank";
        }

        private void Token_Click(object sender, EventArgs e)
        {
            Thread threadToken = new Thread(new ParameterizedThreadStart(tf.TxtAnnotation));
            threadToken.IsBackground = true;
            threadToken.Start();
            threadToken.Join();
            stateLable.Text = "已完成--token";
        }

        private void Train_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ParameterizedThreadStart(tf.GetCRFs));
            thread1.IsBackground = true;
            thread1.Start();
            thread1.Join();
            stateLable.Text = "已完成--Train";
        }

        private void OutSourceTest_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Thread thread1 = new Thread(new ParameterizedThreadStart(tf.OutTestAnnotation));
            thread1.IsBackground = true;
            thread1.Start();
            thread1.Join();
            stateLable.Text = "已完成--OutSourceTest_Click";
        }

        private void Caculation_Click(object sender, EventArgs e)
        {
            string TestSorce = Regex.Replace(FileRW.FileRead(FileRW.FilePath("result_file")), @"[\t]", "");
            (new FileRW()).Caculate(TestSorce);
            stateLable.Text = "已完成--Caculation_Click";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



    }
}
