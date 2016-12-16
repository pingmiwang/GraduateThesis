using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms1
{
    class ThreadFunc
    {
        public void GetCRFs(object argCRFsO)
        {
            string rootPath = Path.GetFullPath(FileRW.FilePath("crfsPath"));
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = new System.Diagnostics.ProcessStartInfo(rootPath + "crf_learn.exe");
            p.StartInfo.Arguments = " " + rootPath + "TMPT " + rootPath + "train.txt " + rootPath + "model";           //FileRW.FilePath("crfsArg") + 
            string argStr = p.StartInfo.Arguments;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.ErrorDialog = true;
            p.Start();
            Console.WriteLine(p.StandardOutput.ReadToEnd());
            string states = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();



            System.Diagnostics.Process p2 = new System.Diagnostics.Process();
            p2.StartInfo = new System.Diagnostics.ProcessStartInfo(rootPath + "crf_test.exe");//需要启动的程序名  
            p2.StartInfo.Arguments = " -m " + rootPath + "model " + rootPath + "test.txt";
            p2.StartInfo.RedirectStandardOutput = true;
            p2.StartInfo.UseShellExecute = false;
            p2.Start();
            FileRW.FileWrite(rootPath + "result_file.txt", p2.StandardOutput.ReadToEnd());
            p2.Close();
        }



        public void TxtAnnotation(object argCRFsO)
        {
            AnnotationTxt anno = new AnnotationTxt();
            anno.Token();
        }

        public void OutTestAnnotation(object argCRFsO)
        {
            AnnotationTxt anno = new AnnotationTxt();
            anno.OutTestToken();
            string[] compound = anno.WordRelation(FileRW.FileRead(FileRW.FilePath("out_result_file")));
        }

        public void WordRelations(object argCRFsO)
        {
            AnnotationTxt anno = new AnnotationTxt();
            anno.WordRelation(FileRW.FileRead(FileRW.FilePath("result_file")));
        }

    }
}