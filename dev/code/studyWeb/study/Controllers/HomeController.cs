using study.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace study.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult FromBase()
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelApp.Workbooks.Open("D:/some.xlsx");
            int row = 1;
            List<List<string>> maping = new List<List<string>>();
            Excel.Worksheet currentSheet = (Excel.Worksheet)excelApp.Workbooks[1].Worksheets[1];
            while (currentSheet.get_Range("A" + row).Value2 != null)
            {
                List<string> tempList = new List<string>();
                for (char column = 'A'; column < 'J'; column++)
                {
                     Excel.Range cell = currentSheet.get_Range(column.ToString() + row);
                     tempList.Add(cell.Value2 != null ? cell.Value2.ToString() : "");
                    
                }
                maping.Add(tempList);
                row++;
            }
            excelApp.Quit();
           
            var dc = new DataContext("Data Source=TRITII;Initial Catalog=123;Integrated Security=True");
            var list = dc.ExecuteQuery<Information>("select Id,Title,Description,PublicationDate from Informations").ToList();
            //new SqlConnection("Data Source=TRITII;Initial Catalog=123;Integrated Security=True")
            return View(list);
        }

        public ActionResult Index(string Property = "Id", string Direction = "Asc", int NumberOfPage=1)
        {   
            InformationWithProperty ObjForView = new InformationWithProperty();
                ObjForView.Property = Property;
                ObjForView.Direction = Direction;
                ObjForView.NumberOfPage = NumberOfPage;
                ObjForView.AllNumbersOfObject = (int)Math.Ceiling((double)Information.AllInformation.Count() / 10);
               // ObjForView.AllNumbersOfObject =Information.AllInformation.Count();

             
                if (NumberOfPage == 1)
                    ObjForView.List = Information.AllInformation.GetRange(0, NumberOfPage * 10);
                else
                    try { ObjForView.List = Information.AllInformation.GetRange(NumberOfPage * 10, 10); }
                    catch { ObjForView.List = Information.AllInformation.GetRange(NumberOfPage * 10, Information.AllInformation.Count()-NumberOfPage*10); }
                if ((ObjForView.Property == "Id") & (ObjForView.Direction == "Asc"))
                {

                    ObjForView.List = ObjForView.List.OrderBy(x => x.Id).ToList();


                }
                else if ((ObjForView.Property == "Id") & (ObjForView.Direction == "Dsc"))
                {
                    ObjForView.List = ObjForView.List.OrderByDescending(x => x.Id).ToList();


                }
                else if ((ObjForView.Property == "Title") & (ObjForView.Direction == "Asc"))
                {
                    ObjForView.List = ObjForView.List.OrderBy(x => x.Title).ToList();


                }
                else if ((ObjForView.Property == "Title") & (ObjForView.Direction == "Dsc"))
                {
                    ObjForView.List = ObjForView.List.OrderByDescending(x => x.Title).ToList();


                }
                else if ((ObjForView.Property == "Description") & (ObjForView.Direction == "Asc"))
                {
                    ObjForView.List = ObjForView.List.OrderBy(x => x.Description).ToList();



                }
                else if ((ObjForView.Property == "Description") & (ObjForView.Direction == "Dsc"))
                {
                    ObjForView.List = ObjForView.List.OrderByDescending(x => x.Description).ToList();


                }
                if ((ObjForView.Property == "PublicationDate") & (ObjForView.Direction == "Asc"))
                {
                    ObjForView.List = ObjForView.List.OrderBy(x => x.PublicationDate).ToList();


                }
                else if ((ObjForView.Property == "PublicationDate") & (ObjForView.Direction == "Dsc"))
                {
                    ObjForView.List = ObjForView.List.OrderByDescending(x => x.Description).ToList();


                }
            
            return View(ObjForView);

        }
        // public study.Models.Information Card(int IdVar)
        [HttpGet]
        public ActionResult Card(int IdVar = -1)
        {
            Information someObj = new Information();
            someObj.Id = -1;

            foreach (var Obj in study.Models.Information.AllInformation.ToList())
                if (Obj.Id == IdVar)
                    return View(Obj);
            return View(someObj);
        }

        [HttpPost]
        public ActionResult Card(int IdVar, Information info)
        {
            Information someObj = study.Models.Information.AllInformation.FirstOrDefault(x => x.Id == IdVar);
            if (IdVar == -1)
            {
                someObj = new Information { Id = -1 };
                someObj.Id = Information.AllInformation.Max(x => x.Id) + 1;
                Information.AllInformation.Add(someObj);

            }
            else if (someObj == null)
            {
                return Redirect("/");
            }
            someObj.Title = info.Title;
            someObj.Description = info.Description;
            Information.SetFile(Information.AllInformation, Server.MapPath("/data.json"));
            return Redirect("/");
        }
        [HttpGet]
        public ActionResult RemoveStr(int IdVar)
        {
            Information.RemoveStringGetFile(IdVar, Server.MapPath("/data.json"));
            return Redirect("/");
        }


    }
}