using SchoolJournal.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Models.WorkClases
{

    public class TableFunctions
    {

        private string[] saveStudentResults = new string[] {
            "Всё ок",
            "Ошибка добавления ученика",
            "Ошибка: ученик с таким ФИО уже есть в БД",
            "Ошибка: ФИО слишком короткое"
        };

        private string[] saveColumnResults = new string[] {
            "Всё ок",
            "Ошибка добавления столбца",
            "Ошибка: столбец с такой датой уже есть в БД"
        };

        private string[] saveValueResults = new string[] {
            "Всё ок",
            "Ошибка добавления значения",
            "Ошибка: данная ячейка уже заполнена"
        };





        public TableFunctions()
        {

        }


        public byte saveStudent(string fio, out string resultText)
        {
            byte ex = 1;

            resultText = saveStudentResults[1];

            try
            {
                using(DbFunctions df = new DbFunctions())
                {

                    ex = df.saveStudent(fio);

                    resultText = saveStudentResults[ex];
                }
            }
            catch
            {
                ex = 1;
                resultText = saveStudentResults[1];
            }

            return ex;
        }

        public byte saveColumn(DateTime date, byte type, out string resultText)
        {
            byte ex = 1;
            
            resultText = saveColumnResults[1];

            try
            {
           
                using (DbFunctions df = new DbFunctions())
                {
             
                    ex = df.saveColumn(date, type);
                    
                    resultText = saveColumnResults[ex];
                }
            }
            catch
            {
                ex = 1;
               
                resultText = saveColumnResults[1];
            }

            return ex;
        }

       
        public byte saveValue(long studentId, long columnId, byte first, byte second, out string resultText)
        {
            byte ex = 1;
            
            resultText = saveValueResults[1];

            try
            {

                using (DbFunctions df = new DbFunctions())
                {

                    ex = df.saveValue(studentId, columnId, first, second);

                    resultText = saveValueResults[ex];
                }
            }
            catch
            {
                ex = 1;
                resultText = saveValueResults[1];
            }

            return ex;
        }

    }
}