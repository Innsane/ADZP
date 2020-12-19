using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class TreeViewViewModel
    {
        private readonly MfgResourcesContext db;

        public TreeViewViewModel(MfgResourcesContext db)
        {
            this.db = db;
            GetAllTreeOfCuttingTools();
            GetAllTreeOfEquipment();
            GetAllTreeOfMachineTools();
        }

        public IEnumerable<TreeOfCuttingTool> TreeOfCuttingTools { get; set; }
        public IEnumerable<TreeOfEquipment> TreeOfEquipments { get; set; }
        public IEnumerable<TreeOfMachineTool> TreeOfMachineTools { get; set; }

        private void GetAllTreeOfCuttingTools()
        {
            TreeOfCuttingTools = from r in db.TreeOfCuttingTools
                                 select r;
        }

        private void GetAllTreeOfEquipment()
        {
            TreeOfEquipments = from r in db.TreeOfEquipments
                               select r;
        }

        private void GetAllTreeOfMachineTools()
        {
            TreeOfMachineTools = from r in db.TreeOfMachineTools
                                 select r;
        }
    }
}
