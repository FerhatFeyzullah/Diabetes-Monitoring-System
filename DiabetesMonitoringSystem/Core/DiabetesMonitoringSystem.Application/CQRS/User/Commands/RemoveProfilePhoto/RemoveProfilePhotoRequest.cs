﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DiabetesMonitoringSystem.Application.CQRS.User.Commands.RemoveProfilePhoto
{
    public class RemoveProfilePhotoRequest:IRequest<RemoveProfilePhotoResponse>
    {
        public int AppUserId { get; set; }

    }
}
