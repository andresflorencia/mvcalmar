using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaMVC.Models.TableViewModel
{
    public class UserModel
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public int? edad { get; set; }
    }
}