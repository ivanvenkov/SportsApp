using Domain.Adaptors;
using FootballDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Facotry
{
    public interface IFactory
    {
        IFootballDBManager GetFootballDBManager();
        Adaptor GetAdaptor();
    }
}
