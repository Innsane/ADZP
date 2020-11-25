﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorytmDobieraniaZasobowProdukcyjnych.Models
{
    public class JsTreeModel
    {
        private TreeOfCuttingTool item;

        public JsTreeModel(TreeOfCuttingTool item)
        {
            id = item.NodeId.ToString();
            if (item.ParentId == "0") parent = "#";
            else parent = item.ParentId.ToString();
            text = item.Name;
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
    }
}
