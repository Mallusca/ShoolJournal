using SchoolJournal.Models.DataClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Models.DbModel
{

    public class DbFunctions : IDisposable
    {

        private SchoolJournalEntities sc;




        public DbFunctions()
        {
           
            sc = new SchoolJournalEntities();
        }



        public List<StudentInfo> loadStudents()
        {

            List<StudentInfo> ex = new List<StudentInfo>();

            try
            {
          
                var stList = sc.Students.ToList();
             
                foreach (var student in stList) 
                 
                    ex.Add(new StudentInfo() {
                        studentId = student.id,
                        studentName = student.FIO
                    });
            }
            catch { ex = new List<StudentInfo>(); }


            return ex;
        }


        public List<TableColumn> loadTableColumns()
        {

            List<TableColumn> ex = new List<TableColumn>();

            Dictionary<long, RatingInfo> values;

            List<Ratings> ratList;

            try
            {
              
                var colList = sc.TableColumns.ToList();
            
                foreach (var col in colList)
                {
                    
                    values = new Dictionary<long, RatingInfo>();
                   
                    ratList = sc.Ratings.Where(rt => (rt.columnId == col.id)).ToList();
                 
                    foreach (var rating in ratList)
                        
                        values.Add(rating.studentId, new RatingInfo(rating.value));

                    
                    ex.Add(new TableColumn()
                    {
                        id = col.id,
                        date = col.date,
                        type = col.type,
                        values = values
                    });
                }
            }
            catch { ex = new List<TableColumn>(); }

            
            return ex;
        }
        
      
        public TableColumn loadAverage(List<StudentInfo> students)
        {
            TableColumn ex = new TableColumn();
          
            List<Ratings> ratList;

            try
            {
                
                foreach(var student in students)
                {
                  
                    ratList = sc.Ratings.Where(rt => (rt.studentId == student.studentId)).ToList();
                    
                    ex.values.Add(student.studentId, new RatingInfo(getAverageRating(ratList)));
                }
            }
            catch { ex = new TableColumn(); }

           
            return ex;
        }

      
        private byte[] getAverageRating(List<Ratings> ratList)
        {
           
            byte[] ex = new byte[0];
            
            int count, summ;


            try
            {
                
                count = summ = 0;
               
                foreach(var rat in ratList)
                {
                   
                    if ((rat.value != null) && (rat.value.Length > 0))
                    {
                        
                        summ += rat.value[0];
                       
                        count++;
                        
                        if(rat.value.Length == 2)
                        {
                            
                            summ += rat.value[1];
                            
                            count++;
                        }
                    }
                }


                if(count != 0)

                    ex = new byte[] { (byte)(summ / count) };
            }
            catch { ex = new byte[0]; }

            return ex;
        }


        public byte saveStudent(string fio)
        {
            byte ex = 1;

            try
            {

                if (fio.Length > 5)
                {

                    if (sc.Students.Count(st => (st.FIO == fio)) == 0)
                    {

                        sc.Students.Add(new Students()
                        {
                            FIO = fio
                        });

                        sc.SaveChanges();

                        ex = 0;
                    }
                    else
                        ex = 2;
                }
                else
                    ex = 3;
            }
            catch { ex = 1; }

            return ex;
        }


        public byte saveColumn(DateTime date, byte type)
        {
            byte ex = 1;

            try
            {
                if (sc.TableColumns.Count(col => (col.date == date)) == 0)
                {
                    sc.TableColumns.Add(new TableColumns()
                    {
                        date = date,
                        type = type
                    });
                    sc.SaveChanges();
                    ex = 0;
                }
                else
                    ex = 2;

            }
            catch { ex = 1; }

            return ex;
        }


        public byte saveValue(long studentId, long columnId, byte first, byte second)
        {
            byte ex = 1;
            byte[] value;

            try
            {

                var val = sc.Ratings.FirstOrDefault(rat => (rat.studentId == studentId) && (rat.columnId == columnId));

                if (val == null)
                {
                    if (first == 255)

                        value = null;

                    else
                    {

                        if (second == 255)
                            value = new byte[] { first };

                        else

                            value = new byte[] { first, second };
                    }
                    

                    sc.Ratings.Add(new Ratings()
                    {
                        columnId = columnId,
                        studentId = studentId,
                        value = value
                    });


                    sc.SaveChanges();

                    ex = 0;
                }

                else

                    ex = 2;
            }
            catch { ex = 1; }

            return ex;
        }


        public void Dispose()
        {
            sc.Dispose();
        }
    }
}