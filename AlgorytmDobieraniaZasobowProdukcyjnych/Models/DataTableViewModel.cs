using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public class DataTableViewModel
    {
        private readonly MfgResourcesContext db;

        public DataTableViewModel(MfgResourcesContext db)
        {
            this.db = db;
            GetAllLathes();
            GetAllOpsklo();
            GetAllOpskl();
            GetAllWiertlaDat();
            GetAllWiertlaTab();
        }

        public IEnumerable<Lathe> Lathes { get; set; }
        public IEnumerable<Opskl> Opskls { get; set; }
        public IEnumerable<Opsklo> Opsklos { get; set; }
        public IEnumerable<WiertlaDat> WiertlaDats { get; set; }
        public IEnumerable<WiertlaTab> WiertlaTabs { get; set; }

        public void GetAllLathes()
        {
            Lathes = from l in db.Lathes
                     select l;
        }

        public void GetAllOpskl()
        {
            Opskls = from l in db.Opskls
                     select l;
        }

        public void GetAllOpsklo()
        {
            Opsklos = from l in db.Opsklos
                      select l;
        }

        public void GetAllWiertlaDat()
        {
            WiertlaDats = from l in db.WiertlaDats
                          select l;
        }

        public void GetAllWiertlaTab()
        {
            WiertlaTabs = from l in db.WiertlaTabs
                          select l;
        }

        public void GetAll()
        {

        }
    }
}
