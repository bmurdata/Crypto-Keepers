using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cryptokeepers2.Models;
using System.IO;
using System.Text;
namespace cryptokeepers2.Controllers
{
    public class apiController : Controller
    {
        private cryptokeepersdb1Entities1 db = new cryptokeepersdb1Entities1();
        // GET: api/addalert
        public ActionResult Upload()
        {
            return RedirectToAction("Index", "alerts");
            return View();
        }
        [HttpPost]
        public ActionResult Create(int type, int flag,string concern )
        {

            return RedirectToAction("Index", "alerts");
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase postedFile)
        {
            return RedirectToAction("Index", "alerts");
            List<alert> customers = new List<alert>();
                string filePath = string.Empty;
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    filePath = path + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    //Read the contents of CSV file.
                    string csvData = System.IO.File.ReadAllText(filePath);

                    //Execute a loop over the rows.
                    foreach (string row in csvData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                        // If the system architecture is little-endian (that is, little end first),
                        // reverse the byte array.
                        // Make the bytes for flag, type, priority, entity, and coin
                        byte[] bytes = Encoding.ASCII.GetBytes(row.Split(',')[1]);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytes);

                        int flager = BitConverter.ToInt32(bytes, 0);

                        bytes = Encoding.ASCII.GetBytes(row.Split(',')[2]);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytes);

                        int typer = BitConverter.ToInt32(bytes, 0);

                        bytes = Encoding.ASCII.GetBytes(row.Split(',')[3]);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytes);

                        int  prior= BitConverter.ToInt32(bytes, 0);

                        bytes = Encoding.ASCII.GetBytes(row.Split(',')[4]);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytes);

                        int ent = BitConverter.ToInt32(bytes, 0);
                        bytes = Encoding.ASCII.GetBytes(row.Split(',')[5]);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytes);

                        int cn = BitConverter.ToInt32(bytes, 0);
                        db.alerts.Add(new alert
                        {
                            //id = Convert.ToInt32(row.Split(',')[0]),
                            flag=(byte)flager,
                            type=(byte) typer,
                            priority=(byte) prior,
                            entity=(byte) ent,
                            coin=(byte) cn,
                            concern = row.Split(',')[0],
                            reported = Convert.ToDateTime(row.Split(',')[6]),
                            notes = row.Split(',')[7]
                        }); ;
                        }
                    }
                }
               // System.IO.File.Delete(filePath);
                return RedirectToAction("Index", "alerts");
            }
        
    
}
}