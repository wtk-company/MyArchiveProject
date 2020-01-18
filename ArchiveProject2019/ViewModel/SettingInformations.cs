using ArchiveProject2019.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArchiveProject2019.ViewModel
{
    public class SettingInformations
    {
        [Display(Name = "SaveInDb", ResourceType = typeof(main_lang))]
     
        public bool SaveDataBase { set; get; }
        [Display(Name = "CipherData", ResourceType = typeof(main_lang))]


        public bool Cigher { set; get; }



        [Display(Name = "CipherFiles", ResourceType = typeof(main_lang))]

        public bool CigherFiles { set; get; }


        [Display(Name = "MD")]
        
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(main_lang), ErrorMessageResourceName = "FieldRequired")]


        public string MotherBoardId { set; get; }
        [Display(Name = "CD")]
        [Required(ErrorMessageResourceType = typeof(main_lang), ErrorMessageResourceName = "FieldRequired")]

        [DataType(DataType.Password)]


        public string CpudId { set; get; }


        [Required(ErrorMessageResourceType = typeof(main_lang), ErrorMessageResourceName = "UserNameRequired")]
        [Display(Name = "UserName", ResourceType = typeof(main_lang))]
        [DataType(DataType.Password)]

        public string UserName { get; set; }




        [Required(ErrorMessageResourceType = typeof(main_lang), ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(main_lang))]
        public string Password { get; set; }


    }
}