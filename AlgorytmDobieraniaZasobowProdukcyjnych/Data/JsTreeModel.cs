using AlgorytmDobieraniaZasobowProdukcyjnych.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Data
{
    public class JsTreeModel
    {

        public JsTreeModel()
        {

        }

        public JsTreeModel(TreeOf item)
        {
            id = item.NodeId.ToString();
            if (item.ParentId == "0") parent = "#";
            else parent = item.ParentId.ToString();
            text = item.Name;
            keyId = item.KeyId;
            opened = true;
            data = new List<object>
            {
                item.TableId
            };
        }

        public string id { get; set; }
        public string parent { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public string state { get; set; }
        public bool opened { get; set; }
        public bool disabled { get; set; }
        public bool selected { get; set; }
        public string li_attr { get; set; }
        public string a_attr { get; set; }

        public string keyId { get; set; }
        public List<object> data { get; set; }



    }
}
