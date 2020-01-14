using ArchiveProject2019.Models;
using ArchiveProject2019.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace ArchiveProject2019.Controllers
{
    public class SettingController : Controller
    {
        


        public ActionResult ChangeSetting()
        {

            string fileName = Server.MapPath("~/Resources/MySecretFile.xml");

            DataSet ds = new DataSet();
            ds.ReadXml(fileName);
            SettingInformations model = new SettingInformations()
            {
                MotherBoardId = ds.Tables[0].Rows[0]["motherid"].ToString(),
                CpudId = ds.Tables[0].Rows[0]["cpuid"].ToString(),
                CipherPassword = ds.Tables[0].Rows[0]["cipherpassword"].ToString(),
                Cigher = ds.Tables[0].Rows[0]["cipher"].ToString().Equals("true")?true:false,
                SaveDataBase = ds.Tables[0].Rows[0]["savedatabase"].ToString().Equals("tru")?true:false




            };
            return View(model);
        }


   

        [HttpPost]
        public ActionResult ChangeSetting(SettingInformations model)
        {

            string fileName = Server.MapPath("~/Resources/MySecretFile.xml");

            DataSet ds = new DataSet();
            ds.ReadXml(fileName);


            if (ModelState.IsValid)
            {
                if (ConfirmLogin(model.UserName, model.Password))
                {
                    ds.Tables[0].Rows[0]["savedatabase"] = (model.SaveDataBase==true)?"true":"false";
                    ds.Tables[0].Rows[0]["cipher"] = (model.Cigher == true) ? "true" : "false";
                    ds.Tables[0].Rows[0]["cipherpassword"] = model.CipherPassword;
                    ds.Tables[0].Rows[0]["motherid"] = model.MotherBoardId;
                    ds.Tables[0].Rows[0]["cpuid"] = model.CpudId;

                    ds.WriteXml(fileName);


                    return RedirectToAction("Index", "Home");

               }
                else
                {
                    ModelState.AddModelError("UserName", "خطأ في التأكيد ");
                    ModelState.AddModelError("Password", "خطأ في التأكيد");

                    return View(model);
                }


            }

            return View();
        }



        public static bool ConfirmLogin(string UserName,string Password)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(UserName+Password);
            string s1=System.Text.Encoding.Default.GetString(SHA256.Create().ComputeHash(passwordBytes));

            string UName = Properties.Settings.Default.MasterUserName;
            string UPsd = Properties.Settings.Default.MasterPassword;

            var passwordBytes2 = Encoding.UTF8.GetBytes(UName + UPsd);

            string s2 = System.Text.Encoding.Default.GetString(SHA256.Create().ComputeHash(passwordBytes2));

            return s1.Equals(s2);

        }
    }

}