using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web;

namespace DataLibrary.Model
{
    public  class ElementModels
    {
        public string Id { get; set; }
        public string ElementType { get; set; }
        public string ElementName { get; set; }
        public int InSan { get; set; }
        public int DeSan { get; set; }
        public string IsForce { get; set; }
        public string IsInter { get; set; }

        public string ElementDes { get; set; }
        public byte[] ImagePath { get; set; }

        

    }

}
