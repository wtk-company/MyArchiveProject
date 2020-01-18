using ArchiveProject2019.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArchiveProject2019.ViewModel
{
    public class GroupUserViewModel
    {
        public string UserId { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(main_lang))]

        public string UserName { get; set; }

        [Display(Name = "FullName", ResourceType = typeof(main_lang))]

        public string FullName { get; set; }
        public int GroupId { get; set; }

        [Display(Name = "MemerInGroup", ResourceType = typeof(main_lang))]

        public bool IsGroupMember { get; set; }
    }
}