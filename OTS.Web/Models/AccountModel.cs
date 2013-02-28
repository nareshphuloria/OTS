﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTS.Web.Models
{
    public class AccountModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int BrokAmount { get; set; }

        public int TransAmount { get; set; }

        public int Interest { get; set; }

        public int GainLost { get; set; }

        public int Balance { get; set; }
        
    }
}