﻿using OurJourney.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurJourney.Application.Common.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(MensajeUsuarioDTO message)
            : base(message)
        {
        }
    }
}
