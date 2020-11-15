using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using _0520Work.Models;

namespace _0520Work.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult NFU()
        {
            ViewData["change"] = false;
            ViewData["noResult"] = false;
            bookData bookData = new bookData();
            return View(bookData);
        }

        [HttpPost]
        public ActionResult NFU(bookData postData)
        {
            ViewData["change"] = false;
            ViewData["noResult"] = false;

            if (ModelState.IsValid == false) //false代表驗證不通過
            {
                return View();
            }

            string isbn = postData.isbn;

            string cmd = @"cd C:\Users\hankh\Desktop\ASP_NET_MVC\0520Work\0520Work\Python";
            string cmd_py = $@"python 0520Work.py --isbn {isbn}";

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.RedirectStandardInput = true;
            p.Start();

            StreamWriter myStreamWriter = p.StandardInput;
            myStreamWriter.WriteLine(cmd);
            myStreamWriter.WriteLine(cmd_py);
            myStreamWriter.Close();


            //-----------------------------------取得書本資料，並存入串列----------------------------------------
            string bigstr = p.StandardOutput.ReadToEnd(); //取得cmd文字
            string[] NSelect = Regex.Split(bigstr, "--分割--", RegexOptions.IgnoreCase); //正規表示式做分割
            string[] right = new string[NSelect.Count() / 2];

            int item = 0;
            for (int x = 0; x < NSelect.Count(); x++)
            {
                if (NSelect[x].IndexOf("\r\n") != -1)
                    continue;

                right[item] = NSelect[x];
                item++;
            }

            bookData bookData = new bookData();
            if (right.Count() == 1) //代表搜尋沒有結果
                ViewData["noResult"] = true;
            else
            {
                bookData.isbn = isbn;
                bookData.name = right[0];
                bookData.price = right[1];
                bookData.shop = right[2];
                bookData.link = right[3];
                bookData.link_img = right[4];
            }
            //----------------------------------------------------------------------------------------------------
            p.WaitForExit(); //等待程式執行完畢，並Exit
            p.Close(); //釋放Process記憶體

            ViewData["change"] = true;
            return View(bookData);
        }
    }
}