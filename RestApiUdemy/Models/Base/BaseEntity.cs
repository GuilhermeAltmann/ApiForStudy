﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RestApiUdemy.Models.Base
{ 
    [DataContract]
    public class BaseEntity
    {

        public long Id { get; set; }
    }
}
