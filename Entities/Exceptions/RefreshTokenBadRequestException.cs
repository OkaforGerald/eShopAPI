﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class RefreshTokenBadRequestException : BadRequestException
    {
        public RefreshTokenBadRequestException(string message) : base(message)
        {
            
        }
    }
}
