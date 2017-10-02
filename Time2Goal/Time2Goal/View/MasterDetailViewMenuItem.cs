﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time2Goal.View
{

    public class MasterDetailViewMenuItem
    {
        public MasterDetailViewMenuItem()
        {
            TargetType = typeof(MasterDetailViewDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}