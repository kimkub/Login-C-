using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp14.studentDataSetTableAdapters;


namespace WindowsFormsApp14
{
    class student
    {
        public bool checkLogin(string txtName, string txtPass, studentDataSet dts)
        {
            DataTable dt = new DataTable();

            if (dts.student.Count() > 0)
            {
                dt = dts.Tables["Student"];
                var q = from qds in dt.AsEnumerable()
                        where qds.Field<string>("S_ID").ToString().Trim() == txtName.ToString().Trim() &&
                        qds.Field<string>("S_cardID").ToString().Trim() == txtPass.ToString().Trim()
                        select new
                        {
                            userID = qds.Field<string>("S_ID").ToString(),
                            userpass = qds.Field<string>("S_cardID").ToString()
                        };
                if (q.Count() <= 0)
                {
                    return false;
                }
                else { return true; }
            }
            else { return false; }

        }
    }
}
