using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public interface IMfgResources
    {
        IEnumerable<Lathe> GetAllLathes();
        IEnumerable<WiertlaDat> GetAllWiertla();
        IEnumerable<TreeOfCuttingTool> GetAllCuttingTools();
        IEnumerable<TreeOfEquipment> GetAllEquipment();
        IEnumerable<TreeOfMachineTool> GetAllMachineTools();
        IEnumerable<Resource> GetAllResources();
    }
}
