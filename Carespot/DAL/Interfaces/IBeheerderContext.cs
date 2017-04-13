﻿using System.Collections.Generic;
using Carespot.Models;

namespace Carespot.DAL.Interfaces
{
    public interface IBeheerderContext
    {
        List<Beheerder> RetrieveAll();

        void CreateBeheerder(int id);

        Beheerder RetrieveBeheerder(int id);

        void UpdateBeheerder(Beheerder b);

        void DeleteBeheerder(int id);

    }
}