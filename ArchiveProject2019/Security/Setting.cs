using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ArchiveProject2019.Security
{
    public class Setting
    {

        //Const Information :
        public static string Password = "wtk2019companypassword";
        public static string MasterUserName = "masteruser";
        public static string MasterPassword = "master123s";


        public static bool SaveInDb()
        {
            string fileName = System.Web.Hosting.HostingEnvironment.MapPath("~/Resources/MySecretFile.xml");

            DataSet ds = new DataSet();
            ds.ReadXml(fileName);
            bool Save = true;
            try
            {

                Save = (ds.Tables[0].Rows[0]["sd"].ToString().Equals("true")?true:false);
            }
            catch (Exception ex)
            {
                Save = false;
            }

            return Save;

        }


        public static bool CipherData()
        {
            string fileName = System.Web.Hosting.HostingEnvironment.MapPath("~/Resources/MySecretFile.xml");

            DataSet ds = new DataSet();
            ds.ReadXml(fileName);
            bool Save = true;
            try
            {

                Save = (ds.Tables[0].Rows[0]["ci"].ToString().Equals("true") ? true : false);
            }
            catch (Exception ex)
            {
                Save = false;
            }

            return Save;

        }


        public static bool CipherFiles()
        {
            string fileName = System.Web.Hosting.HostingEnvironment.MapPath("~/Resources/MySecretFile.xml");

            DataSet ds = new DataSet();
            ds.ReadXml(fileName);
            bool Save = true;
            try
            {

                Save = (ds.Tables[0].Rows[0]["cf"].ToString().Equals("true") ? true : false);
            }
            catch (Exception ex)
            {
                Save = false;
            }

            return Save;

        }
    }
}