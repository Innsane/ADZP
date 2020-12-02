using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public class ToolsData : IMfgResources
    {
        private readonly MfgResourcesContext db;

        public ToolsData(MfgResourcesContext db)
        {
            this.db = db;
        }

        public ToolsData()
        {
        }

        public IEnumerable<Lathe> GetAllLathes()
        {
            var query = from l in db.Lathes
                        select l;
            return query;
        }

        public IEnumerable<WiertlaDat> GetAllWiertla()
        {
            var query = from l in db.WiertlaDats
                        orderby l.Oznaczenie
                        select l;
            return query;
        }

        public IEnumerable<TreeOfCuttingTool> GetAllCuttingTools()
        {
            var query = from t in db.TreeOfCuttingTools
                        select t;
            return query;
        }

        public IEnumerable<Resource> GetAllResources()
        {
            var query = from r in db.Resources
                        select r;
            return query;
        }

        public IEnumerable<TreeOfEquipment> GetAllEquipment()
        {
            var query = from r in db.TreeOfEquipments
                        select r;
            return query;
        }

        public IEnumerable<TreeOfMachineTool> GetAllMachineTools()
        {
            var query = from r in db.TreeOfMachineTools
                        select r;
            return query;
        }
    }
}
