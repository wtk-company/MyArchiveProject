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
        [Display(Name = "التخزين في قاعدة البيانات")]
        [Required(ErrorMessage ="الحقل ضروري")]
        public bool SaveDataBase { set; get; }
        [Display(Name = " تشفير البيانات المهمة ")]
        [Required(ErrorMessage = "الحقل ضروري")]

        public bool Cigher { set; get; }

        [StringLength(maximumLength: 300,MinimumLength =12,ErrorMessage = "يجب أن تكون كلمةالسر طويلة بالقدر الكافي")]
        [Display(Name = "كلمة سر التشفير")]
        [Required(ErrorMessage = "الحقل ضروري")]

        public string CipherPassword { set; get; }
        [Display(Name = "رقم اللوحة الام للجهاز")]
        [Required(ErrorMessage = "الحقل ضروري")]

        public string MotherBoardId { set; get; }
        [Display(Name = "رقم المعالج للجهاز")]
        [Required(ErrorMessage = "الحقل ضروري")]

        public string CpudId { set; get; }


        [Required(ErrorMessageResourceType = typeof(main_lang), ErrorMessageResourceName = "UserNameRequired")]
        [Display(Name = "UserName", ResourceType = typeof(main_lang))]
        public string UserName { get; set; }




        [Required(ErrorMessageResourceType = typeof(main_lang), ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(main_lang))]
        public string Password { get; set; }


    }
}