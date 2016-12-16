using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms1
{
    class FileRW
    {
        //public file(string filename)
        //{

        //}
        public static string FilePath(string fileName)
        {
            return ConfigurationManager.AppSettings[fileName];
        }
        public static string FileRead(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string dicSorce = sr.ReadToEnd();
            return dicSorce;
        }

        public static void FileWrite(string path,string files)
        {
            byte[] buffer = Encoding.Default.GetBytes(files);
            File.WriteAllBytes(path, buffer);
        }


       

        public static string[] OrderDic(string str)
        {
            string[] dics = str.Replace("\r\n", " ").Trim().Split(new char[] { '；', ' ' });
            List<OrderInfo> infoList = new List<OrderInfo>();
            string[] dicOrdered = new string [dics.Length];
            foreach (var dic in dics)
            {
                infoList.Add(new OrderInfo(dic));
            }
            //Console.WriteLine("ReadT*********************");
            IEnumerable<OrderInfo> query = from items in infoList orderby items.len descending select items;
            int i = 0;
            foreach (var item in query)
            {
                dicOrdered[i] = item.dicWord;
                i++;
                //Console.WriteLine(item.len + ":" + item.dicWord);
            }
            return dicOrdered;
        }


        public void Caculate(string TestSorce)
        {
            string OriTerm = "";
            string RecognizeTerm = "";
            string outputReco0 = "";
            string outputReco = "";

            int OriTermCount = 0;
            int RecognizeTermCount = 0;
            int RecognizeCharCount = 0;
            int RightRecogTermCount = 0;
            int SentenceCount = 0;

            int continueTerm = 0;
            while (TestSorce.Contains("\r\n"))
            {
                int Column_index = TestSorce.IndexOf("\r\n");
                if (Column_index > 2)
                {
                    SentenceCount++;
                    OriTerm = TestSorce.Substring(Column_index - 2, 1);
                    RecognizeTerm = TestSorce.Substring(Column_index - 1, 1);
                    outputReco0 = TestSorce.Substring(0, 1);//对应的字

                    if (OriTerm == "B" || OriTerm == "S" || OriTerm == "T")
                    {
                        OriTermCount += 1;//所有标注的术语数
                    }
                    if (RecognizeTerm == "B" || RecognizeTerm == "S" || RecognizeTerm == "T")
                    {
                        RecognizeTermCount += 1;//识别的术语数
                    }
                    if (RecognizeTerm == "B")
                    {
                        continueTerm = SentenceCount;
                        outputReco += outputReco0;//字连接 
                    }
                    else if (SentenceCount == continueTerm + 1 && RecognizeTerm == "M")
                    {
                        continueTerm = continueTerm + 1;
                        outputReco += outputReco0;//字连接 
                    }
                    if (SentenceCount == continueTerm + 1 && RecognizeTerm == "E")
                    {
                        // RightRecogTermCount += 1;//正确识别的术语数
                        outputReco += outputReco0 + ";";//字连接 
                        // outputReco0 ="";//字连接 
                    }
                    //单词术语
                    if (RecognizeTerm == "S" || OriTerm == "T")
                    {
                        RightRecogTermCount += 1;//正确识别的术语数
                        outputReco += outputReco0 + ";";//字连接 
                    }




                    if (OriTerm == RecognizeTerm && OriTerm != "")
                    {
                        RecognizeCharCount += 1;//正确识别的字个数                       
                        //双字和多字术语
                        if (RecognizeTerm == "B")
                        {
                            continueTerm = SentenceCount;
                        }
                        else if (SentenceCount == continueTerm + 1 && RecognizeTerm == "M")
                        {
                            continueTerm = continueTerm + 1;
                        }
                        if (SentenceCount == continueTerm + 1 && RecognizeTerm == "E")
                        {
                            RightRecogTermCount += 1;//正确识别的术语数

                        }
                        //单词术语
                        if (RecognizeTerm == "S" || OriTerm == "T")
                        {
                            RightRecogTermCount += 1;//正确识别的术语数
                        }
                    }
                }
                TestSorce = TestSorce.Substring(Column_index + "\r\n".Length);
            }
            double p = RightRecogTermCount * 1.0 / RecognizeTermCount;
            double r = RightRecogTermCount * 1.0 / OriTermCount;
            double CharP = RecognizeCharCount * 1.0 / SentenceCount;
            double F1 = 2 * p * r / (p + r);

            //保存到txt文档
            string txtResult = "正确率是：" + p.ToString("#0.0000") + ";\r\n" + "召回率是：" + r.ToString("#0.0000") + ";\r\n"
                + "F1值是：" + F1.ToString("#0.0000") + ";\r\n"
                + "单字识别率是：" + CharP.ToString("#0.0000")
                + ";\r\n正确识别的术语个数：" + RightRecogTermCount + ";\r\n识别的术语个数：" + RecognizeTermCount + ";\r\n测试的术语总个数：" + OriTermCount;
            byte[] buffer = Encoding.Default.GetBytes(txtResult);
            File.WriteAllBytes(FileRW.FilePath("ResultCalcu"), buffer);
        }


        public void CacuWithWords(string TestSorce)
        {
            string OriTerm = "";
            string RecognizeTerm = "";
            string outputReco0 = "";
            string outputReco = "";

            int OriTermCount = 0;
            int RecognizeTermCount = 0;
            int RecognizeCharCount = 0;
            int RightRecogTermCount = 0;
            int SentenceCount = 0;

            int continueTerm = 0;
            while (TestSorce.Contains("\r\n"))
            {
                int Column_index = TestSorce.IndexOf("\r\n");
                if (Column_index > 2)
                {
                    SentenceCount++;
                    OriTerm = TestSorce.Substring(Column_index - 2, 1);
                    RecognizeTerm = TestSorce.Substring(Column_index - 1, 1);
                    outputReco0 = TestSorce.Substring(0, 1);//对应的字

                    if (OriTerm == "B" || OriTerm == "S" || OriTerm == "T")
                    {
                        OriTermCount += 1;//所有标注的术语数
                    }
                    if (RecognizeTerm == "B" || RecognizeTerm == "S" || RecognizeTerm == "T")
                    {
                        RecognizeTermCount += 1;//识别的术语数
                    }
                    if (RecognizeTerm == "B")
                    {
                        continueTerm = SentenceCount;
                        outputReco += outputReco0;//字连接 
                    }
                    else if (SentenceCount == continueTerm + 1 && RecognizeTerm == "M")
                    {
                        continueTerm = continueTerm + 1;
                        outputReco += outputReco0;//字连接 
                    }
                    if (SentenceCount == continueTerm + 1 && RecognizeTerm == "E")
                    {
                        // RightRecogTermCount += 1;//正确识别的术语数
                        outputReco += outputReco0 + ";";//字连接 
                        // outputReco0 ="";//字连接 
                    }
                    //单词术语
                    if (RecognizeTerm == "S" || OriTerm == "T")
                    {
                        RightRecogTermCount += 1;//正确识别的术语数
                        outputReco += outputReco0 + ";";//字连接 
                    }




                    if (OriTerm == RecognizeTerm && OriTerm != "")
                    {
                        RecognizeCharCount += 1;//正确识别的字个数                       
                        //双字和多字术语
                        if (RecognizeTerm == "B")
                        {
                            continueTerm = SentenceCount;
                        }
                        else if (SentenceCount == continueTerm + 1 && RecognizeTerm == "M")
                        {
                            continueTerm = continueTerm + 1;
                        }
                        if (SentenceCount == continueTerm + 1 && RecognizeTerm == "E")
                        {
                            RightRecogTermCount += 1;//正确识别的术语数

                        }
                        //单词术语
                        if (RecognizeTerm == "S" || OriTerm == "T")
                        {
                            RightRecogTermCount += 1;//正确识别的术语数
                        }
                    }
                }
                TestSorce = TestSorce.Substring(Column_index + "\r\n".Length);
            }
            double p = RightRecogTermCount * 1.0 / RecognizeTermCount;
            double r = RightRecogTermCount * 1.0 / OriTermCount;
            double CharP = RecognizeCharCount * 1.0 / SentenceCount;
            double F1 = 2 * p * r / (p + r);

            //保存到txt文档
            string txtResult = "正确率是：" + p.ToString("#0.0000") + ";\r\n" + "召回率是：" + r.ToString("#0.0000") + ";\r\n"
                + "F1值是：" + F1.ToString("#0.0000") + ";\r\n"
                + "单字识别率是：" + CharP.ToString("#0.0000")
                + ";\r\n正确识别的术语个数：" + RightRecogTermCount + ";\r\n识别的术语个数：" + RecognizeTermCount + ";\r\n测试的术语总个数：" + OriTermCount;
            byte[] buffer = Encoding.Default.GetBytes(txtResult);
            File.WriteAllBytes(FileRW.FilePath("ResultCalcu"), buffer);
        }        

    }
}
