using ArchiveProject2019.Models;
using ArchiveProject2019.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArchiveProject2019.ViewModel
{
    public class Informations
    {

        public bool IsMasterRole { set; get; }
        [Display(Name = "MyDocumentCount", ResourceType = typeof(main_lang))]

        public int MyTotalDocument { set; get; }

        [Display(Name = "MyGroupsCount", ResourceType = typeof(main_lang))]


        public int MyGroupsCount { set; get; }
        [Display(Name = "LastCreateDocumentDate", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string LastMyDocumentCreate { set; get; }
        [Display(Name = "TotalDepartmentsCount", ResourceType = typeof(main_lang))]


        public int DepartmentsCount { set; get; }



        [Display(Name = "DocumentsKindCount", ResourceType = typeof(main_lang))]


        public int TotalDocumentKindCount { set; get; }



        [Display(Name = "LasteCreateDate", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        public string LastDocumentKindCreate { set; get; }

        [Display(Name = "LastUpdateDate", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        public string LastDocumentKindUpdate { set; get; }


        [Display(Name = "HightDocumentKindUsing", ResourceType = typeof(main_lang))]

        public string HightDocumentKindUsing { set; get; }










        [Display(Name = "MainDepartmentsCount", ResourceType = typeof(main_lang))]

        public int MainDepartmentCount { set; get; }
        [Display(Name = "AllDepartmentsCount", ResourceType = typeof(main_lang))]

        public int AllDepartmentsCount { set; get; }
        [Display(Name = "LasteCreateDate", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        public string LastDateDepartmentCreate { set; get; }


        [Display(Name = "LastUpdateDate", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        public string LastDateDepartmentUpdate { set; get; }



        [Display(Name = "AllGroupsCount", ResourceType = typeof(main_lang))]


        public int AllGroupsCount { set; get; }
        [Display(Name = "LasteCreateDate", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        public string LastGroupCreate { set; get; }



        [Display(Name = "LastUpdateDate", ResourceType = typeof(main_lang))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        public string LastGroupUpdate { set; get; }
        [Display(Name = "UsersCountInGroups", ResourceType = typeof(main_lang))]

        public int TotalUserInGroup { set; get; }

        [Display(Name = "HightGroupUsers", ResourceType = typeof(main_lang))]

        public string HightGroupUsers { set; get; }






        [Display(Name = "عدد  المستخدمين الكلي ")]

        public int TotalUserCount { set; get; }
        [Display(Name = "LasteCreateDate", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        public string LastUserCreate { set; get; }

        [Display(Name = "LastUpdateDate", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        public string LastUserUpdate { set; get; }





        [Display(Name = "AllFormsCount", ResourceType = typeof(main_lang))]


        public int TotalFormsCount { set; get; }
        [Display(Name = "LasteCreateDate", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        public string LastFormCreate { set; get; }

        [Display(Name = "LastUpdateDate", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        public string LastFormUpdate { set; get; }

        [Display(Name = "HightFormUsing", ResourceType = typeof(main_lang))]

        public string HightFormUsing { set; get; }





        [Display(Name = "TotalDocumentCount", ResourceType = typeof(main_lang))]

        public int TotalDocumentCount { set; get; }
        [Display(Name = "LasteCreateDate", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        public string LastDocumentCreate { set; get; }



        [Display(Name = "TotalMailsCount", ResourceType = typeof(main_lang))]


        public int TotalMailsCount { set; get; }
        [Display(Name = "LasteCreateDate", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        public string LastMailsCreate { set; get; }


        [Display(Name = "LastUpdateDate", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]
        public string LastMailsUpdate { set; get; }

        [Display(Name = "HightMailUsing", ResourceType = typeof(main_lang))]


        public string HightMailUsing { set; get; }



        [Display(Name = "UserFullName", ResourceType = typeof(main_lang))]

        public string FullName { set; get; }

        [Display(Name = "UserUserName", ResourceType = typeof(main_lang))]

        public string UserName { set; get; }

        [Display(Name = "UserEmail", ResourceType = typeof(main_lang))]

        public string Email { set; get; }


        [Display(Name = "UserGender", ResourceType = typeof(main_lang))]

        public string Gender { set; get; }

        [Display(Name = "UpdatedAt", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]

        public string UserUpdate { set; get; }


        [Display(Name = "UserRole", ResourceType = typeof(main_lang))]

        public string RoleName { set; get; }


        [Display(Name = "CreatedAt", ResourceType = typeof(main_lang))]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy-HH:mm:ss}")]

        public string UserCreateAt { set; get; }


        [Display(Name = "UserDepartment", ResourceType = typeof(main_lang))]

        public string DepartmentName { set; get; }

        [Display(Name = "UserJopTitle", ResourceType = typeof(main_lang))]

        public string JobTitle { set; get; }





        //Groups:
         public List<GroupsUserInformation> UserGroups { set; get; }
        public Company Company { set; get; }

        //Permissions:

        public List<Form> FavoriteForm { set; get; }












    }
}