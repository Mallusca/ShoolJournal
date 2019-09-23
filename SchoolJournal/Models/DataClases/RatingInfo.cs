using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Models.DataClases
{
 
    public class RatingInfo
    {

        private byte first;
  
        private byte second;
   
        private bool none;


        public string getValue
        {
            get
            {
                
                string ex = "";

                try
                {
                    if (none)
                        ex = "Н";
                    else
                    {

                        if ((first == 255) && (second == 255))

                            ex = "";
                        else
                        {
                            //Если нет второго значения
                            if (second == 255)
                                //Ставим только первое
                                ex = first.ToString();
                            //Если второе значение есть
                            else
                                //Ставим оба
                                ex = $"{first}/{second}";
                        }
                    }

                }
                catch { ex = ""; }

                return ex;
            }
        }

        public RatingInfo(byte[] value)
        {

            first = second = 255;
            none = false;
          
            if (value != null)
            {
               
                if (value.Length == 1)
                   
                    first = value[0];

                else if (value.Length == 2)
                {

                    first = value[0];
                    second = value[1];
                }
            }

            else
                none = true;
        }
    }
}