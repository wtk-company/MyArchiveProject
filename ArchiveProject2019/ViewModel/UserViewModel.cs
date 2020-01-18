using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ArchiveProject2019.Resources;
namespace ArchiveProject2019.ViewModel
{
    public class UserViewModel
    {

        [Display(Name = "FullName", ResourceType = typeof(main_lang))]



        public string FullName { set; get; }
        [Display(Name = "Gender", ResourceType = typeof(main_lang))]

        public string Gender { set; get; }


        [Display(Name = "DepartmentId", ResourceType = typeof(main_lang))]

        public string DepartmentName { set; get; }




        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        [Display(Name = "CreatedAt", ResourceType = typeof(main_lang))]
        public string CreatedAt { get; set; }

        //Users Control:
        [Display(Name = "CreatedById", ResourceType = typeof(main_lang))]
        public string CreatedBy { set; get; }




        [Display(Name = "Role", ResourceType = typeof(main_lang))]

        public string RoleName { set; get; }





        [Display(Name = "JobTitleId", ResourceType = typeof(main_lang))]
        public string JobTitle{ set; get; }





        [Display(Name = "UpdatedAt", ResourceType = typeof(main_lang))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        public string UpdatedAt { get; set; }


        [Display(Name = "UpdatedById", ResourceType = typeof(main_lang))]

        public string UpdatedBy { set; get; }



        [Display(Name = "UserName", ResourceType = typeof(main_lang))]

        public string UserName { set; get; }


        [Display(Name = "Email", ResourceType = typeof(main_lang))]

        public string Email { set; get; }


    }
}