﻿using StarWars.Domain.Entities;
using System.Collections.Generic;

namespace StarWars.Domain.Interfaces
{
    public interface INotificator
    {
        bool HasErrors();

        List<Notification> GetErrors();

        void AddError(string error);
    }
}