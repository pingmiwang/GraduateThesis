using System;
using System.Collections;
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

        public static string pathHeader2;
        public static string outTestSource;
        public static List<string>[] outTest;

        public static string FilePath(string fileName)
        {
            return pathHeader2 + ConfigurationManager.AppSettings[fileName];
        }
        public static string FileRead(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string dicSorce = sr.ReadToEnd();
            sr.Close();
            return dicSorce;
        }

        public static void FileWrite(string path, string files)
        {
            byte[] buffer = Encoding.Default.GetBytes(files);
            File.WriteAllBytes(path, buffer);
        }




        public static string[] OrderDic(string str)
        {
            string[] dics = str.Replace("\r\n", " ").Trim().Split(new char[] { '；', ' ' });
            List<OrderInfo> infoList = new List<OrderInfo>();
            string[] dicOrdered = new string[dics.Length];
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
            string oriTerm = "";
            string recognizeTerm = "";

            int oriTermCount = 0;
            int recognizeTermCount = 0;
            int recognizeCharCount = 0;
            int rightRecogTermCount = 0;
            int sentenceCount = 0;

            int continueTerm = 0;
            while (TestSorce.Contains("\r\n"))
            {
                int Column_index = TestSorce.IndexOf("\r\n");
                if (Column_index > 2)
                {
                    sentenceCount++;
                    oriTerm = TestSorce.Substring(Column_index - 2, 1);
                    recognizeTerm = TestSorce.Substring(Column_index - 1, 1);
                    //对应的字  outputReco0 = TestSorce.Substring(0, 1);

                    if (oriTerm == "B" || oriTerm == "S" || oriTerm == "T")
                    {
                        oriTermCount += 1;//所有标注的术语数
                    }
                    if (recognizeTerm == "B" || recognizeTerm == "S" || recognizeTerm == "T")
                    {
                        recognizeTermCount += 1;//识别的术语数
                    }


                    if (oriTerm == recognizeTerm && oriTerm != "")
                    {
                        recognizeCharCount += 1;//正确识别的字个数                       
                        //双字和多字术语
                        if (recognizeTerm == "B")
                        {
                            continueTerm = sentenceCount;
                        }
                        else if (sentenceCount == continueTerm + 1 && recognizeTerm == "M")
                        {
                            continueTerm = continueTerm + 1;
                        }
                        if (sentenceCount == continueTerm + 1 && recognizeTerm == "E")
                        {
                            rightRecogTermCount += 1;//正确识别的术语数
                        }
                        //单词术语
                        if (recognizeTerm == "S" || recognizeTerm == "T")// || recognizeTerm == "T"
                        {
                            rightRecogTermCount += 1;//正确识别的术语数                      
                        }
                    }
                }
                TestSorce = TestSorce.Substring(Column_index + "\r\n".Length);
            }
            double p = rightRecogTermCount * 1.0 / recognizeTermCount;
            double r = rightRecogTermCount * 1.0 / oriTermCount;
            double CharP = recognizeCharCount * 1.0 / sentenceCount;
            double F1 = 2 * p * r / (p + r);

            //保存到txt文档
            string txtResult = "正确率是：" + p.ToString("#0.0000") + ";\r\n" + "召回率是：" + r.ToString("#0.0000") + ";\r\n"
                + "F1值是：" + F1.ToString("#0.0000") + ";\r\n"
                + "单字识别率是：" + CharP.ToString("#0.0000")
                + ";\r\n正确识别的术语个数：" + rightRecogTermCount + ";\r\n识别的术语个数："
                + recognizeTermCount + ";\r\n测试的术语总个数：" + oriTermCount;
            byte[] buffer = Encoding.Default.GetBytes(txtResult);
            File.WriteAllBytes(FileRW.FilePath("ResultCalcu"), buffer);
        }


        public List<string> CacuWithWords(string TestSorce)
        {
            /*词典词*/
            string[] dicsArray = FileRW.FileRead(FileRW.FilePath("dicOrderPath")).Replace("\r\n", " ").Trim().Split(new char[] { '；', ' ' });

            List<string> alTerms = new List<string>();//将词典中的词过滤掉
            string recognizeTerm = "";
            string outputReco0 = "";
            string outputReco = "";
            int sentenceCount = 0;
            int continueTerm = 0;
            while (TestSorce.Contains("\r\n"))
            {
                int Column_index = TestSorce.IndexOf("\r\n");
                if (Column_index > 2)
                {
                    recognizeTerm = TestSorce.Substring(Column_index - 1, 1);
                    outputReco0 = TestSorce.Substring(0, 1);//对应的字                
                    //双字和多字术语
                    if (recognizeTerm == "B")
                    {
                        continueTerm = sentenceCount;
                        outputReco += outputReco0;//字连接 
                    }
                    else if (sentenceCount == continueTerm + 1 && recognizeTerm == "M")
                    {
                        continueTerm = continueTerm + 1;
                        outputReco += outputReco0;//字连接 
                    }
                    if (sentenceCount == continueTerm + 1 && recognizeTerm == "E")
                    {
                        outputReco += outputReco0;//字连接    
                        if (Array.IndexOf(dicsArray, outputReco) > -1) //判断是否包含在词典中
                        {
                            alTerms.Add(outputReco);
                        }
                        outputReco = "";
                    }
                    //单词术语
                    if (recognizeTerm == "S")// 排除为连续符号的情况 || recognizeTerm == "T"
                    {
                        int indexOut = Array.IndexOf(dicsArray, outputReco0);
                        if (indexOut == -1)
                        {
                            alTerms.Add(outputReco0);
                        }
                    }
                }
                TestSorce = TestSorce.Substring(Column_index + "\r\n".Length);
            }
            return alTerms;
        }

    }
}
