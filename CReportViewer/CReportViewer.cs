using System;
using System.Collections.Generic;
using System.Text;

using AspNetCore.Reporting;

namespace CReportViewer
{
    public  class CReportViewer
    {
     
        public  CReportViewer(Options options){


            var test = new ReportData();
       
           

            var local = new LocalReport("test");
            local.AddDataSource("testet",null);


      
        }





    }
}
