﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using programaçaoDoZero.models;

namespace programaçaoDoZero.models
{
    public class LoginRequest
    {
        public string Email{ get; set; }
        public string Senha { get; set; }
    }
}
