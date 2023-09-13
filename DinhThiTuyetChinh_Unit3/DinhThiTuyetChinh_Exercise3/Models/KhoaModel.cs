using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DinhThiTuyetChinh_Exercise3.Models
{
    public class KhoaModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public KhoaModel()
        {

        }
        public KhoaModel(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}