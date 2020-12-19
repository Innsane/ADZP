using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class DataTableViewModel
    {
        private readonly MfgResourcesContext db;

        public DataTableViewModel(MfgResourcesContext db)
        {
            this.db = db;
            GetAllLathes();
            GetAllNozeJednolite();
            GetAllNozeLutowane();
            GetAllOpsklo();
            GetAllOpskl();
            GetAllTurningTool();
            GetAllWiertlaDat();
            GetAllWiertlaTab();
        }

        

        public IEnumerable<Lathe> lathes { get; set; }
        public IEnumerable<NozeJednolite> nozejednolites { get; set; }
        public IEnumerable<NozeLutowane> nozelutowanes { get; set; }
        public IEnumerable<Opskl> opsklss { get; set; }
        public IEnumerable<Opsklo> opsklos { get; set; }
        public IEnumerable<QTurningTool> qturningtools { get; set; }
        public IEnumerable<TurctCarbid> turctcarbids { get; set; }
        public IEnumerable<TurctHolder> turctgolders { get; set; }
        public IEnumerable<TurctInsert> turctinserts { get; set; }
        public IEnumerable<TurctParVcVal> turctparvcvals { get; set; }
        public IEnumerable<TurnToolTab> turntooltabs { get; set; }
        public IEnumerable<WiertlaDat> wiertladats { get; set; }
        public IEnumerable<WiertlaTab> wiertlatabs { get; set; }

        public void GetAllLathes()
        {
            lathes = from l in db.Lathes
                     select l;
        }

        public void GetAllOpskl()
        {
            opsklss = from l in db.Opskls
                      select l;
        }

        public void GetAllOpsklo()
        {
            opsklos = from l in db.Opsklos
                      select l;
        }

        public void GetAllWiertlaDat()
        {
            wiertladats = from l in db.WiertlaDats
                          select l;
        }

        public void GetAllWiertlaTab()
        {
            wiertlatabs = from l in db.WiertlaTabs
                          select l;
        }

        private void GetAllNozeLutowane()
        {
            nozelutowanes = from l in db.NozeLutowanes
                          select l;
        }

        private void GetAllNozeJednolite()
        {
            nozejednolites = from l in db.NozeJednolites
                            select l;
        }

        private void GetAllTurningTool()
        {
            qturningtools = from l in db.QTurningTools
                             select l;
        }

        private void GetAllTurnToolTab()
        {
            throw new NotImplementedException();
        }

        private void GetAllTurctParVcVal()
        {
            throw new NotImplementedException();
        }

        private void GetAllTurctInsert()
        {
            throw new NotImplementedException();
        }

        private void GetAllTurctHolder()
        {
            throw new NotImplementedException();
        }

        private void GetAllTurctCarbid()
        {
            throw new NotImplementedException();
        }

        

        

        public void GetAll()
        {

        }

        //getting IEnumerable<TableData> by name
        public static IEnumerable<TableData> GetPropValue(DataTableViewModel src, string propName)
        {
            return (IEnumerable<TableData>)src.GetType().GetProperty(propName.ToLower()).GetValue(src, null);
        }

        //internal List<TableData> GetDataByName(string name)
        //{
        //    switch (name)
        //    {
        //        case "wiertlatab":
        //            return wiertlatabs.ToList();
        //            break;
        //        case "lathes":
        //            jsonResult = new JsonResult(dataTable.lathes.ToList());
        //            break;
        //        case "wiertladat":
        //            jsonResult = new JsonResult(dataTable.wiertladats.ToList());
        //            break;
        //        case "opskl":
        //            jsonResult = new JsonResult(dataTable.opsklos.ToList());
        //            break;
        //        case "opsklo":
        //            jsonResult = new JsonResult(dataTable.opsklss.ToList());
        //            break;
        //    }
        //}
    }
}
