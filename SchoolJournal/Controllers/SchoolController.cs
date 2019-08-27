using SchoolJournal.Models.Models;
using SchoolJournal.Models.WorkClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournal.Controllers
{

    public class SchoolController : Controller
    {

        [HttpGet]
        public ActionResult JournalPage()
        {
            return View(new JournalModel());
        }

         
        [HttpPost]
        public ActionResult AddStudent()
        {
            return PartialView();
        }


        [HttpPost]
        public ActionResult AddColumn()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ShowStudentGradeDialog()
        {

            return PartialView();
        }


        [HttpPost]
        public JsonResult saveStudent(string fio)
        {
            byte resultCode = 1;
            string resultText = "Ошибка добавления ученика";

        
            resultCode = new TableFunctions().saveStudent(fio, out resultText);

            return Json(new {
                        resultCode = resultCode,
                        resultText = resultText
                   });
        }


        [HttpPost]
        public JsonResult saveColumn(DateTime date, byte type)
        {
            byte resultCode = 1;
            string resultText = "Ошибка добавления столбца";

            resultCode = new TableFunctions().saveColumn(date, type, out resultText);


            return Json(new
            {
                resultCode = resultCode,
                resultText = resultText
            });
        }

      
        [HttpPost]
        public JsonResult SetStudentGrade(long studentId, long columnId, byte first, byte second)
        {
            byte resultCode = 1;
            string resultText = "Ошибка добавления оценки";

            resultCode = new TableFunctions().saveValue(studentId, columnId, first, second, out resultText);

            return Json(new
            {
                resultCode = resultCode,
                resultText = resultText
            });
        }
    }
}