using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS_VersionM.ATT;
using MIS_VersionM.DLL;

namespace MIS_VersionM.BLL
{
    public class BLLEmployee
    {
        public string SaveEmployee(ATTEmployee objEmployee)
        {
            string msg = "";
            try
            {
                DLLEmployee dlEmployee = new DLLEmployee();
                msg = dlEmployee.SaveEmployee(objEmployee);
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public string DeleteEmployee(int? empID)
        {
            string msg = "";
            try
            {
                DLLEmployee dlEmployee = new DLLEmployee();
                msg = dlEmployee.DeleteEmployee(empID);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public List<ATTEmployee> GetEmployee(int? empID)
        {
            List<ATTEmployee> lst = new List<ATTEmployee>();
            DLLEmployee dlEmployee = new DLLEmployee();
            try
            {
                lst = dlEmployee.GetEmployee(empID);
            }
            catch (Exception ex)
            {
                //throw(ex);
            }
            return lst; 

        }
    }
}