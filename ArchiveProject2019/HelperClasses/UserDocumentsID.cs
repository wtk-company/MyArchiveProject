using ArchiveProject2019.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArchiveProject2019.HelperClasses
{
    public class UserDocumentsID
    {


        //User document{create || Responible}
        public static IEnumerable<int>UserCreatedDocument(string UserID)
        {


            ApplicationDbContext db = new ApplicationDbContext();

            IEnumerable<int> MyDoc = db.Documents
                .Where(a =>a.IsGeneralize==false&&( a.CreatedById.Equals(UserID)||a.ResponsibleUserId.Equals(UserID)))
                .Select(a=>a.Id);
            return MyDoc;

        }



        //User document notification in current day
        public static IEnumerable<int> UserNotificationTodayDocument(string UserID)
        {


           
            ApplicationDbContext db = new ApplicationDbContext();
            DateTime TodayDate = DateTime.ParseExact(DateTime.Now.ToString("yyyy/MM/dd").Replace("-", "/"), "yyyy/MM/dd", null);

            IEnumerable<Document> MyDoc = db.Documents.Where(a => a.NotificationUserId.Equals(UserID) && a.NotificationDate != null).ToList();
            MyDoc = MyDoc.Where(a => EqualDate(a.NotificationDate, TodayDate)).OrderByDescending(a => a.NotificationDate);
            List<int> DocIds = MyDoc.Select(a => a.Id).ToList();

            return DocIds;

        }






        public static IEnumerable<int> UserMyDepartmentDocument(string UserID)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            int _DepId = db.Users.Find(UserID).DepartmentId.HasValue ? db.Users.Find(UserID).DepartmentId.Value : -1;
            IEnumerable<int> myDoc = db.Documents.Where(a => a.DepartmentId == _DepId && a.IsGeneralize==false).Select(a => a.Id);
            return myDoc;

        }

        public static IEnumerable<int>UserDepartmentDocument(string UserID)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            int _DepId = db.Users.Find(UserID).DepartmentId.HasValue?db.Users.Find(UserID).DepartmentId.Value:-1;
            IEnumerable<int> myDoc = db.DocumentDepartments
                .Include(a=>a.document).Where(a => a.DepartmentId == _DepId && a.document.IsGeneralize==false)
                .Select(a => a.DocumentId);
            return myDoc;

        }



        public static IEnumerable<int> UserDocumentTrend(string UserID)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            IEnumerable<int> myDoc = db.DocumentUsers
                .Include(a=>a.document)
                .Where(a =>a.UserId.Equals(UserID) && a.document.IsGeneralize==false)
                .Select(a => a.DocumentId);
            return myDoc;

        }

        public static IEnumerable<int> UserDocumentGroups(string UserID)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            IEnumerable<int> GroupId = db.UsersGroups
                .Where(a => a.UserId.Equals(UserID))
                .Select(a => a.GroupId);
            IEnumerable<int> myDoc = db.DocumentGroups
                .Include(a=>a.document)
                .Where(a => GroupId.Contains(a.GroupId) && a.document.IsGeneralize==false)
                .Select(a => a.DocumentId).Distinct();
            return myDoc;

        }


        public static IEnumerable<int> UserDeocumentNotification (string UserID)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            IEnumerable<int> myDoc = db.Documents.
                Where(a => a.NotificationUserId.Equals(UserID) && a.NotificationDate != null && a.IsGeneralize==false)
                .Select(a=>a.Id);
            return myDoc;

        }



        public static IEnumerable<int> UserAllDocuments(string UserId)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            IEnumerable<int> Doc1 = UserCreatedDocument(UserId);
            IEnumerable<int> Doc2 = UserDepartmentDocument(UserId);
            IEnumerable<int> Doc3 = UserDocumentGroups(UserId);
            IEnumerable<int> Doc4 = UserDeocumentNotification(UserId);
            IEnumerable<int> Doc5 = UserMyDepartmentDocument(UserId);
            IEnumerable<int> Doc6 =UserDocumentTrend(UserId);

            IEnumerable<int> AllDoc = Doc1.Union(Doc2).Union(Doc3).Union(Doc4).Union(Doc5).Distinct();
            return AllDoc;



        }



        //Related Document:::
        public static IEnumerable<int> UserRelateDocument(string UserID,int DocId)
        {


            ApplicationDbContext db = new ApplicationDbContext();
            List<int> RelateDocumentId = db.RelatedDocuments.Where(a => a.Document_id == DocId).Select(a=>a.RelatedDocId).ToList();
            IEnumerable<int> MyDoc1 = db.Documents
                .Where(a =>RelateDocumentId.Contains(a.Id)&& a.CreatedById.Equals(UserID) && a.IsGeneralize==false)
                .Select(a => a.Id);


            //Department:
            int _DepId = db.Users.Find(UserID).DepartmentId.HasValue ? db.Users.Find(UserID).DepartmentId.Value : -1;
            IEnumerable<Document>docs2= db.DocumentDepartments.Include(a=>a.document).Where(a => RelateDocumentId.Contains(a.Id)&& a.DepartmentId == _DepId).Select(a => a.document);
            IEnumerable<int> myDoc2 = docs2.Where(a => a.IsGeneralize == false).Select(a=>a.Id);
                


            //Groups :

            IEnumerable<int> GroupId = db.UsersGroups.Where(a => a.UserId.Equals(UserID)).Select(a => a.GroupId);
              IEnumerable<Document>docs3  = db.DocumentGroups
                .Include(a=>a.document)
                .Where(a =>RelateDocumentId.Contains(a.Id)&& GroupId.Contains(a.GroupId
                )).Select(a => a.document);
            IEnumerable<int> myDoc3 = docs3.Where(a => a.IsGeneralize == false).Select(a => a.Id);


            //Users:
                IEnumerable<Document>docs4= db.DocumentUsers.Include(a=>a.document)
                .Where(a => RelateDocumentId.Contains(a.Id) && a.UserId.Equals(UserID))
                .Select(a => a.document);
            IEnumerable<int> myDoc4 = docs4.Where(a=>a.IsGeneralize==false).Select(a=>a.Id);



            List<int> MyDoc = MyDoc1.Union(myDoc2).Union(myDoc3).Union(myDoc4).Distinct().ToList();
            return MyDoc;

        }



        //Related Document:::
        public static IEnumerable<int> UserReplayDocument(string UserID, int DocId)
        {


            ApplicationDbContext db = new ApplicationDbContext();
            List<int> ReplayDocumentId = db.ReplayDocuments.Where(a => a.Document_id == DocId).Select(a => a.ReplayDocId).ToList();
            IEnumerable<int> MyDoc1 = db.Documents.
                Where(a => ReplayDocumentId.Contains(a.Id) && a.CreatedById.Equals(UserID)&& a.IsGeneralize==false)
                .Select(a => a.Id);


            //Department:
            int _DepId = db.Users.Find(UserID).DepartmentId.HasValue ? db.Users.Find(UserID).DepartmentId.Value : -1;
            IEnumerable<Document> docs2 = db.DocumentDepartments.Include(a => a.document).Where(a => ReplayDocumentId.Contains(a.Id) && a.DepartmentId == _DepId).Select(a => a.document);
            IEnumerable<int> myDoc2 = docs2.Where(a => a.IsGeneralize == false).Select(a => a.Id);

            //Groups :

            IEnumerable<int> GroupId = db.UsersGroups.Where(a => a.UserId.Equals(UserID)).Select(a => a.GroupId);
            IEnumerable<Document> docs3 = db.DocumentGroups
              .Include(a => a.document)
              .Where(a => ReplayDocumentId.Contains(a.Id) && GroupId.Contains(a.GroupId
              )).Select(a => a.document);
            IEnumerable<int> myDoc3 = docs3.Where(a => a.IsGeneralize == false).Select(a => a.Id);


            //Users:
            IEnumerable<Document> docs4 = db.DocumentUsers.Include(a => a.document)
            .Where(a => ReplayDocumentId.Contains(a.Id) && a.UserId.Equals(UserID))
            .Select(a => a.document);
            IEnumerable<int> myDoc4 = docs4.Where(a => a.IsGeneralize == false).Select(a => a.Id);



            List<int> MyDoc = MyDoc1.Union(myDoc2).Union(myDoc3).Union(myDoc4).Distinct().ToList();
            return MyDoc;

        }



        public static bool EqualDate(string s1, DateTime s2)
        {
            try
            {


                s1 = s1.Replace("-", "/");
                return DateTime.ParseExact(s1, "yyyy/MM/dd", null) == s2;
            }
            catch (Exception e)
            {
                return false;

            }

        }




        //Generailzed Document:


        public static IEnumerable<int> UserCreatedGeneralizedDocument(string UserID)
        {


            ApplicationDbContext db = new ApplicationDbContext();

            IEnumerable<int> MyDoc = db.Documents
                .Where(a => a.IsGeneralize == true && (a.CreatedById.Equals(UserID) || a.ResponsibleUserId.Equals(UserID)))
                .Select(a => a.Id);
            return MyDoc;

        }


        public static IEnumerable<int> UserMyDepartmentGenralizedDocument(string UserID)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            int _DepId = db.Users.Find(UserID).DepartmentId.HasValue ? db.Users.Find(UserID).DepartmentId.Value : -1;
            IEnumerable<int> myDoc = db.Documents.Where(a => a.DepartmentId == _DepId && a.IsGeneralize == true).Select(a => a.Id);
            return myDoc;

        }


        public static IEnumerable<int> UserDepartmentGeneralizedDocument(string UserID)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            int _DepId = db.Users.Find(UserID).DepartmentId.HasValue ? db.Users.Find(UserID).DepartmentId.Value : -1;
            IEnumerable<int> myDoc = db.DocumentDepartments
                .Include(a => a.document).Where(a => a.DepartmentId == _DepId && a.document.IsGeneralize == true)
                .Select(a => a.DocumentId);
            return myDoc;

        }



        public static IEnumerable<int> UserGeneralizedDocumentTrend(string UserID)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            IEnumerable<int> myDoc = db.DocumentUsers
                .Include(a => a.document)
                .Where(a => a.UserId.Equals(UserID) && a.document.IsGeneralize == true)
                .Select(a => a.DocumentId);
            return myDoc;

        }

        public static IEnumerable<int> UserGeneralizedDocumentGroups(string UserID)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            IEnumerable<int> GroupId = db.UsersGroups
                .Where(a => a.UserId.Equals(UserID))
                .Select(a => a.GroupId);
            IEnumerable<int> myDoc = db.DocumentGroups
                .Include(a => a.document)
                .Where(a => GroupId.Contains(a.GroupId) && a.document.IsGeneralize == true)
                .Select(a => a.DocumentId).Distinct();
            return myDoc;

        }


        public static IEnumerable<int> UserGeneralizedDeocumentNotification(string UserID)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            IEnumerable<int> myDoc = db.Documents.
                Where(a => a.NotificationUserId.Equals(UserID) && a.NotificationDate != null && a.IsGeneralize == true)
                .Select(a => a.Id);
            return myDoc;

        }


    }
}