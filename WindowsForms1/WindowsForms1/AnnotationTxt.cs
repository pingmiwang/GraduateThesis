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
        public bool Token()
        {
            try
            {
                /*词典词*/
                string[] dicsArray = FileRW.FileRead(FileRW.FilePath("dicOrderPath")).Replace("\r\n", " ").Trim().Split(new char[] { '；', ' ' });

                /*测试语料*/
                string[] testArray = FileRW.FileRead(FileRW.FilePath("testPath")).Replace("\r\n", " ").Trim().Split(new char[] { '；', ' ' });
                string tokenTest = TokenNoPQ(dicsArray, testArray);
                FileRW.FileWrite(FileRW.FilePath("testTokenPath"), tokenTest);

                /*训练语料*/
                string[] trainArray = FileRW.FileRead(FileRW.FilePath("trainPath")).Replace("\r\n", " ").Trim().Split(new char[] { '；', ' ' });
                string tokenTrain = TokenNoPQ(dicsArray, trainArray);
                FileRW.FileWrite(FileRW.FilePath("trainTokenPath"), tokenTrain);
                return true;
            }
            catch (Exception )
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
            string[] testArray = FileRW.FileRead(FileRW.FilePath("OutTestTxt")).Replace("\r\n", " ").Trim().Split(new char[] { '；', ' ' });
            string tokenTest = TokenNoPQ(dicsArray, testArray);
            FileRW.FileWrite(FileRW.FilePath("testTokenPath"), tokenTest);


            string rootPath = Path.GetFullPath(FileRW.FilePath("crfsPath"));
            System.Diagnostics.Process p2 = new System.Diagnostics.Process();
            p2.StartInfo = new System.Diagnostics.ProcessStartInfo(rootPath + "crf_test.exe");//需要启动的程序名  
            p2.StartInfo.Arguments = " -m " + rootPath + "model " + rootPath + "test.txt";
            p2.StartInfo.RedirectStandardOutput = true;
            p2.StartInfo.UseShellExecute = false;
            p2.Start();
            FileRW.FileWrite(FileRW.FilePath("out_result_file"), p2.StandardOutput.ReadToEnd());
            p2.Close();

            throw new NotImplementedException();
        }


        public string[] WordRelation(string outputTest)
        {
            string term_bi = "";
            string term_uni = "";
            string term_str = "";

            int i = 0;
            int IndexBJoin = 0;
            int IndexB = 0;
            int IndexM = 0;
            int IndexMJoin = 0;
            int IndexE = 0;
            int IndexEJoin = 0;
            int CountE = 0;
            int IndexS = 0;
            int CountS = 0;
            int IndexA = 0;
            int titleID = 0;
            while (outputTest.Contains("\r\n"))
            {
                int char_index_i = outputTest.IndexOf("\r\n");
                if (char_index_i > 1)
                {
                    i++;
                    term_str = outputTest.Substring(0, char_index_i);
                    if (term_str.LastIndexOf("B") > 0)
                    {
                        //---SB相连----------BEBE连续的情况-----B首次出现
                        if (i - IndexS == 1 || IndexE + 1 == i || term_bi.Length == 0)
                        {
                            term_bi += term_str.Substring(0, 1);
                            IndexBJoin = i;
                        }
                        else
                        {
                            term_bi += "；" + term_str.Substring(0, 1);
                            IndexBJoin = i;
                        }
                        term_uni += term_str.Substring(0, 1);
                        IndexB = i;
                    }
                    else if (term_str.LastIndexOf("M") > 0)
                    {
                        //--BM-------------MM
                        if (IndexBJoin == i - 1 || IndexM == i - 1)
                        {
                            term_bi += term_str.Substring(0, 1);
                            IndexMJoin = i;
                        }
                        term_uni += term_str.Substring(0, 1);
                        IndexM = i;
                    }
                    else if (term_str.LastIndexOf("E") > 0)
                    {
                        //----EB---------------EMMB----
                        if (IndexBJoin == i - 1 || IndexMJoin == i - 1)
                        {
                            term_bi += term_str.Substring(0, 1);
                            CountE += 1;
                            IndexEJoin = i;
                        }
                        term_uni += term_str.Substring(0, 1) + "；";
                        IndexE = i;
                    }
                    else if (term_str.LastIndexOf("S") > 0)
                    {
                        //------ES相连-------------SS相连-----------首次出现
                        if (i == IndexE + 1 || IndexS == i - 1 || term_bi.Length == 0)
                        {
                            term_bi += term_str.Substring(0, 1);
                            CountS += 1;
                        }
                        else
                        {
                            term_bi += "；" + term_str.Substring(0, 1);
                        }
                        term_uni += term_str.Substring(0, 1) + "；";
                        IndexS = i;
                    }
                    else
                    {
                        //-----前面是--------------------------ABEA---------------------------------或开始为BEA-并且不是AA相连- ABE结束-----排除BES的情况
                        if ((IndexE == i - 1 && IndexBJoin == IndexA + 1) && term_bi.Length > 0 || (IndexB == 1 && IndexA != i - 1) && IndexS != i - 1) //
                        {
                            if (term_bi.Contains("；"))  //高碳铬轴承钢管坯热轧后控制冷却工艺及水冷器
                            {
                                term_bi = term_bi.Substring(0, term_bi.Length - IndexE + IndexBJoin - 2);
                            }
                            else
                            {
                                term_bi = term_bi.Substring(0, term_bi.Length - IndexE + IndexBJoin - 1);
                            }
                        }
                        else if (IndexS == i - 1 && IndexA == IndexS - 1)// 前面是ASA
                        {
                            if (term_bi.Contains("；")) //用含镍铬烟尘或氧化皮冶炼镍铬生铁的方法及产品
                            {
                                term_bi = term_bi.Substring(0, term_bi.Length - 2);
                            }
                            else if (term_bi.Length - 1 > 0)
                            {
                                term_bi = term_bi.Substring(0, term_bi.Length - 1);
                            }

                        }
                        IndexA = i;
                    }
                }
                else
                {
                    //int titleId = SentenceIndex[titleID]; //"update testText set keyWords='" + term_uni + "' where title_id=" + titleId
                    //(new GetTrainTesttxt()).un_select_query("insert into backup_text (title_id,keyWords,[is_term]) values (" + titleId + ",'" + term_bi + "',1)");
                    //(new GetTrainTesttxt()).un_select_query("insert into backup_text (title_id,keyWords,[is_term]) values (" + titleId + ",'" + term_uni + "',0)");
                    titleID++;
                    term_bi = "";
                    term_uni = "";
                    term_str = "";
                }
                outputTest = outputTest.Substring(char_index_i + 2);
            }
            string[] wordRalation = new string[2];
            wordRalation[0] = term_uni;
            wordRalation[1] = term_bi;
            return wordRalation;
            //  TbTest_outputT.Text = "基本术语：" + term_uni + "\r\n\r\n合成术语：" + term_bi;

        }
    }
}
