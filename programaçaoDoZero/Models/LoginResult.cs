using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using programaçaoDoZero.models;
using programaçaoDoZero.Models;

namespace programaçaoDoZero.models
{
    public class LoginResult : BaseResult
    {
        public Guid usuarioGuid { get; set; }
    }
}
