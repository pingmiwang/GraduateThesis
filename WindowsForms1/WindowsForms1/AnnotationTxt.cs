using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsForms1
{

    class AnnotationTxt
    {
        public bool Token(bool isTrain)
        {
            try
            {
                /*词典词*/
                string[] dicsArray = FileRW.FileRead(FileRW.FilePath("dicOrderPath")).Replace("\r\n", " ").Trim().Split(new char[] { '；', ' ' });
                if (isTrain == true)
                {
                    /*训练语料*/
                    string[] trainArray = FileRW.FileRead(FileRW.FilePath("trainPath")).Replace("\r\n", " ").Trim().Split(new char[] { '；', ' ' });
                    string tokenTrain = TokenNoPQ(dicsArray, trainArray);
                    FileRW.FileWrite(FileRW.FilePath("trainTokenPath"), tokenTrain);
                    return true;
                }
                else
                {
                    /*测试语料*/
                    string[] testArray = FileRW.FileRead(FileRW.FilePath("testPath")).Replace("\r\n", " ").Trim().Split(new char[] { '；', ' ' });
                    string tokenTest = TokenNoPQ(dicsArray, testArray);
                    FileRW.FileWrite(FileRW.FilePath("testTokenPath"), tokenTest);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        //无PQ，连续字符以T标记
        public string TokenNoPQ(string[] dicsArray, string[] tokenArray)
        {
            #region   读出所有的特征词
            string FeartureSorce = FileRW.FileRead(FileRW.FilePath("featuresPath"));

            int First = FeartureSorce.IndexOf("：") + 1;
            int Seconde = FeartureSorce.IndexOf("：", First);
            string FirstName = FeartureSorce.Substring(First, Seconde - First);

            int Third = FeartureSorce.IndexOf("：", Seconde + 5);
            string Translated = FeartureSorce.Substring(Seconde + 5, Third - Seconde - 5);

            int Fourth = FeartureSorce.IndexOf("：", Third + 4);
            string Areal = FeartureSorce.Substring(Third + 4, Fourth - Third - 4);

            int Fifth = FeartureSorce.IndexOf("：", Fourth + 7);
            string Commen1 = FeartureSorce.Substring(Fourth + 7, Fifth - Fourth - 7);

            int Sixth = FeartureSorce.IndexOf("：", Fifth + 7);
            string Commen2 = FeartureSorce.Substring(Fifth + 7, Sixth - Fifth - 7);

            int Seventh = FeartureSorce.IndexOf("：", Sixth + 5);
            string Indicative = FeartureSorce.Substring(Sixth + 5, Seventh - Sixth - 5);

            int Eighth = FeartureSorce.IndexOf("：", Seventh + 5);
            string Associative = FeartureSorce.Substring(Seventh + 5, Eighth - Seventh - 5);

            int Ninth = FeartureSorce.IndexOf("：", Eighth + 5);
            string Sound = FeartureSorce.Substring(Eighth + 5, Ninth - Eighth - 5);

            int Tenth = FeartureSorce.IndexOf("：", Ninth + 1);
            string Pictograph = FeartureSorce.Substring(Tenth + 1);

            #endregion
            #region 角色和特征标注，将连续的英文字母或数字连在一块作为一个整体
            string t = "";//存储读出的标题
            string t1 = "";//替换掉标题中的连续字母数字等
            string tokenResult = "";//用于保存最后的结果到txt

            int titleCount = tokenArray.Length;
            for (int titleI = 0; titleI < titleCount; titleI++)
            {
                t = tokenArray[titleI];
                t1 = "";
                //        /*先把字序列和位置序列全部放进去，遍历这个3元数组，把找到的相应角色填充进去
                //    第一列为字序列，第二列为位置序列，第三列为角色序列 */
                string[,] L3 = new string[3, t.Length];
                char[] charList = t.ToCharArray();
                string CharAdd = "";
                int CharCount = 100;
                int CharIndex = 0;
                for (int L3FillI = 0; L3FillI < t.Length; L3FillI++)
                {
                    string item = charList[L3FillI].ToString();
                    if (Regex.Matches(item, "[a-zA-Z0-9]").Count > 0)
                    {
                        if (CharCount == L3FillI - 1)
                        {
                            CharAdd += item;
                        }
                        else if (CharCount == 100 || CharCount < L3FillI)
                        {
                            CharAdd = item;//将连续的英文字母或数字连在一块作为一个整体
                        }
                        if (L3FillI == t1.Length - 1)
                        {
                            CharIndex++;
                            L3[0, CharIndex] = CharAdd;
                        }
                        CharCount = L3FillI;
                    }
                    else if (CharCount == L3FillI - 1)
                    {
                        L3[0, CharIndex] = CharAdd;
                        t1 += "#";
                        CharAdd = "";
                        CharIndex++;
                        string ss = charList[L3FillI].ToString();
                        L3[0, CharIndex] = ss;
                        CharIndex++;
                        t1 += ss;
                    }
                    else
                    {
                        L3[0, CharIndex] = charList[L3FillI].ToString();
                        string ss = charList[L3FillI].ToString();
                        CharIndex++;
                        t1 += ss;
                    }
                    L3[1, L3FillI] = CharIndex.ToString();//其实没用到
                }


                //遍历词典
                //  int OrderFind = 0;//用于统计是第几次找到词典词，最终未使用，出现其他情况再用
                int dicCount = dicsArray.Length;
                for (int dicI = 0; dicI < dicCount; dicI++)
                {
                    string dicstr = dicsArray[dicI];

                    int t1Dic = t1.IndexOf(dicstr);
                    if (t1Dic > -1)
                    {
                        int dicLenth = dicstr.Length;
                        if (dicstr.Length == 2)
                        {
                            L3[2, t1Dic] = "B";
                            L3[2, t1Dic + 1] = "E";
                        }
                        else if (dicstr.Length == 1)
                        {
                            L3[2, t1Dic] = "S";
                        }
                        else
                        {
                            for (int dicLstart = 0; dicLstart < dicLenth; dicLstart++)
                            {
                                if (dicLstart == 0)
                                {
                                    L3[2, t1Dic + dicLstart] = "B";
                                }
                                else if (dicLstart == dicLenth - 1)
                                {
                                    L3[2, t1Dic + dicLstart] = "E";
                                }
                                else
                                {
                                    L3[2, t1Dic + dicLstart] = "M";
                                }
                            }

                        }
                        //将已经查找过的词用#替代
                        string replaceDic = "";
                        for (int repalceI = 0; repalceI < dicLenth; repalceI++)
                        {
                            replaceDic += "#";
                        }
                        // OrderFind += 1;
                        t1 = t1.Substring(0, t1Dic) + replaceDic + t1.Substring(t1Dic + dicLenth);
                    }
                }
                //将字序列和角色以及特征保存到字符串
                for (int endI = 0; endI < CharIndex; endI++)
                {
                    for (int endC = 0; endC < 3; endC++)
                    {

                        if (endC == 0)
                        {
                            tokenResult += L3[endC, endI];
                            //是否是姓氏
                            if (FirstName.Contains(L3[endC, endI]))
                            {
                                tokenResult += "\t" + "Y";
                            }
                            else
                            {
                                tokenResult += "\t" + "N";
                            }
                            //是否是英译词
                            if (Translated.Contains(L3[endC, endI]))
                            {
                                tokenResult += "\t" + "Y";
                            }
                            else
                            {
                                tokenResult += "\t" + "N";
                            }
                            //是否是领域特征
                            if (Areal.Contains(L3[endC, endI]))
                            {
                                tokenResult += "\t" + "Y";
                            }
                            else
                            {
                                tokenResult += "\t" + "N";
                            }
                            //是否是级别特征词
                            if (Commen1.Contains(L3[endC, endI]))//一级常用字
                            {
                                tokenResult += "\t" + "X";
                            }
                            else if (Commen2.Contains(L3[endC, endI]))//二级常用字
                            {
                                tokenResult += "\t" + "Y";
                            }
                            else
                            {
                                tokenResult += "\t" + "Z";
                            }
                            //是否是英译词分类特征
                            if (Indicative.Contains(L3[endC, endI])) //指事字
                            {
                                tokenResult += "\t" + "X";
                            }
                            else if (Associative.Contains(L3[endC, endI])) //象形字
                            {
                                tokenResult += "\t" + "Y";
                            }
                            else if (Sound.Contains(L3[endC, endI]))//形声字
                            {
                                tokenResult += "\t" + "Z";
                            }
                            else if (Pictograph.Contains(L3[endC, endI]))//会意字
                            {
                                tokenResult += "\t" + "U";
                            }
                            else//其他类型字
                            {
                                tokenResult += "\t" + "V";
                            }
                            //  tokenResult += L3[endC, endI] + "\t";

                        }
                        if (endC == 2)
                        {
                            //将一个字母视为一个术语角色
                            //if (L3[2, endI] == null && Regex.Matches(L3[0, endI], "[a-zA-Z0-9]").Count > 0)
                            //{
                            //    L3[2, endI] = "T";
                            //}
                            //将连续的字母视为一个术语角色
                            if (L3[2, endI] == null && Regex.Matches(L3[0, endI], "[a-zA-Z0-9]").Count > 0)
                            {
                                L3[2, endI] += L3[2, endI] + "T";
                            }
                            else if (L3[2, endI] == null)
                            {
                                L3[2, endI] = "A";
                            }
                            tokenResult += "\t" + L3[endC, endI];
                        }
                    }
                    tokenResult += "\r\n";
                }
                tokenResult += "\r\n";
            }
            #endregion
            return tokenResult;
        }


        internal void OutTestToken()
        {
            /*词典词*/
            string[] dicsArray = FileRW.FileRead(FileRW.FilePath("dicOrderPath")).Replace("\r\n", " ").Trim().Split(new char[] { '；', ' ' });

            /*测试语料*/
            //string[] testArray = FileRW.FileRead(FileRW.FilePath("OutTestTxt")).Replace("\r\n", " ").Trim().Split(new char[] { '；', ' ' });   文件的形式内部大批量测试语料
            string[] testArray = FileRW.outTestSource.Trim().Split(new string[] { "\r\n", "，","。" }, new StringSplitOptions());
            string tokenTest = TokenNoPQ(dicsArray, testArray);
            FileRW.FileWrite(FileRW.FilePath("OutTest"), tokenTest);


            string rootPath = Path.GetFullPath(FileRW.FilePath("crfsPath"));
            System.Diagnostics.Process p2 = new System.Diagnostics.Process();
            p2.StartInfo = new System.Diagnostics.ProcessStartInfo(rootPath + "crf_test.exe");//需要启动的程序名  
            p2.StartInfo.Arguments = " -m " + rootPath + "model " + rootPath + "OutTest.txt";
            p2.StartInfo.RedirectStandardOutput = true;
            p2.StartInfo.UseShellExecute = false;
            p2.Start();
            FileRW.FileWrite(FileRW.FilePath("out_result_file"), p2.StandardOutput.ReadToEnd());
            p2.Close();

            //throw new NotImplementedException();
        }


        public List<string>[] WordRelation(string outputTest)
        {
            List<string>[] TwoKinds = new List<string>[2];
            List<string> termBasic = new List<string>();
            List<string> termCompound = new List<string>();
            /*
            List<string> termWord = new List<string>();
            List<string> termRole = new List<string>();
            List<string> termOrder = new List<string>();      
             *备用 */

            string term_word = "";
            string term_role = "";
            StringBuilder sb = new StringBuilder();
            StringBuilder sbBE = new StringBuilder();

            //用于判断是否相邻，是否是合成术语
            int i = 0;
            int orderB = 100;
            int orderM = 100;
            int orderE = 100;
            int orderS = 100;
            int orderS0 = 100;

            while (outputTest.Contains("\r\n"))
            {
                int char_index_i = outputTest.IndexOf("\r\n");
                #region
                if (char_index_i > 1)
                {
                    i++;//字所在序号
                    term_word = outputTest.Substring(0, 1);//字
                    term_role = outputTest.Substring(char_index_i - 1, 1); //角色
                    if (term_role != "A" && term_role != "T")
                    {
                        /** 备用*3个list的下标一致来映射
                        termOrder.Add(i.ToString());
                        termWord.Add(term_word);
                        termRole.Add(term_role);
                         */

                        //双或多字术语:以B开头的情况 ,排除SB,EB的情况
                        if (term_role == "B" && orderS0 != i - 1 &&  orderE != i - 1)
                        {
                            sbBE.Append(term_word);
                            sb.Append(term_word);
                            orderB = i;
                        }
                        else if (term_role == "M" && (orderB == i - 1 || orderM == i - 1))
                        {
                            sb.Append(term_word);
                            sbBE.Append(term_word);
                            orderM = i;
                        }
                        else if (term_role == "E" && (orderM == i - 1 || orderB == i - 1))
                        {
                            sb.Append(term_word);
                            sbBE.Append(term_word);
                            termBasic.Add(sbBE.ToString());
                            sbBE.Clear();
                            orderE = i;

                        }//单字术语 ES的情况
                        else if (term_role == "S" && orderE == i - 1)
                        {
                            orderS = i;
                            termBasic.Add(term_word);
                            sb.Append(term_word);
                        }//EB相连的情况
                        else if (term_role == "B" && orderE == i - 1)
                        {
                            orderB = i;
                            sbBE.Append(term_word);
                            sb.Append(term_word);
                        }
                        //首先遇到单个术语的情况 
                        else if (term_role == "S" && orderS0 != i - 1)
                        {
                            orderS0 = i;
                            termBasic.Add(term_word);
                            sb.Append(term_word);
                        }//SBME相连的情况
                        else if (orderS0 == i - 1 && term_role == "B")
                        {
                            orderB = i;
                            sbBE.Append(term_word);
                            sb.Append(term_word);
                        }//SS相连的情况
                        else if (orderS0 == i - 1 && term_role == "S")
                        {
                            orderS0 = i;
                            termBasic.Add(term_word);
                            sb.Append(term_word);
                        }
                        else
                        {

                        }
                    }
                #endregion
                    //只有当A紧邻任何一个术语的时候，才对合成术语做处理
                    else if (i == orderB + 1 || i == orderM + 1 || i == orderE + 1 || i == orderS + 1 || i == orderS0 + 1)
                    { //如果单子术语中最后一个元素与合成术语不同，那么将加入到合成术语
                        //string  s1=termBasic.ElementAt(termBasic.Count-1).ToString();
                        //  string s2=sb.ToString();
                        if (!termBasic.Contains(sb.ToString()) && sb.ToString() != "")
                        {
                            termCompound.Add(sb.ToString());
                        }
                        sb.Clear();
                    }
                }
                else
                {
                    if (!termBasic.Contains(sb.ToString()) && sb.ToString() != "")
                    {
                        termCompound.Add(sb.ToString());
                    }
                    sb.Clear();
                    i = 0;          //表示一句话的结束，开始处理，然后清空       
                    orderB = 100;
                    orderM = 100;
                    orderE = 100;
                    orderS = 100;
                    orderS0 = 100;
                }
                outputTest = outputTest.Substring(char_index_i + 2);
            }
            TwoKinds[0] = termBasic.Distinct().ToList();

            TwoKinds[1] = termCompound.Distinct().ToList();
            return TwoKinds;
        }
    }
}
