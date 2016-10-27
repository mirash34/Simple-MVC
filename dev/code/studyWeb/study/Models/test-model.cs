using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;


namespace study.Models
{
    public class Information
    {
        public Information() { }
        public Information(string Title, string Description, DateTime PublicationDate, int Id)
        {
            this.title = Title;
            this.description = Description;
            this.publicationDate = PublicationDate;
            this.id = Id;
        }
        private string description;
        public string Description
        {
            get { return this.description; }
            set { description = value; }

        }
        private DateTime publicationDate;

        public DateTime PublicationDate
        {
            get { return publicationDate; }
            set { publicationDate = value; }

        }
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }

        }
        public static Information[] GetFile(string path)
        {
            var Serializer = new JavaScriptSerializer();
            string Info = File.ReadAllText(path);
            return Serializer.Deserialize<Information[]>(Info);
        }
        public static void SetFile(List<Information> FormInformation, string path)
        {
            string json = new JavaScriptSerializer().Serialize(FormInformation);
            File.WriteAllText(path, json);

        }
        public static void RemoveStringGetFile(int IdVar, string path)
        {
            AllInformation.RemoveAll(x => x.Id == IdVar);
            string json = new JavaScriptSerializer().Serialize(AllInformation);
            File.WriteAllText(path, json);

        }
      /*  public static System.Linq.IOrderedEnumerable<study.Models.Information> SortId()
        {    
            return AllInformation.OrderBy(x=>x.Id); 
        }


        public static System.Linq.IOrderedEnumerable<study.Models.Information> SortTitle() 
        { return AllInformation.OrderBy(x => x.Title); 
        }
        public static System.Linq.IOrderedEnumerable<study.Models.Information> SortDescription() 
        { return AllInformation.OrderBy(x => x.Description); 
        }
        */
        
        public static List<Information> AllInformation = new List<Information>();
    }

    public class InformationWithProperty{
        public List<Information> List{get;set;}
        public string Property { get; set; }
        public string Direction { get; set; }
        public int NumberOfPage { get; set; }
        public int AllNumbersOfObject { get; set; }
        
    }
}

