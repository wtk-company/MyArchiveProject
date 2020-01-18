using ArchiveProject2019.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArchiveProject2019.ViewModel
{
    public class GroupsUserInformation
    {

        [Display(Name = "GroupName", ResourceType = typeof(main_lang))]

     
        public string Name { set; get; }
      [Display(Name = "MemberCounts", ResourceType = typeof(main_lang))]


        public int UsersCount { set; get; }

       
    }
}