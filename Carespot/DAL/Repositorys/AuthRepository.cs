﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carespot.DAL.Context;
using Carespot.Models;

namespace Carespot.DAL.Repositorys
{
     public static  class AuthRepository
    {
         public static bool CheckAuth(string email, string password )
        {

            GebruikerRepository gr = new GebruikerRepository();
            List<Gebruiker> gebruikers = gr.RetrieveAll();

            foreach (Gebruiker g in gebruikers)
            {           
                if (g.Email == email && g.Wachtwoord == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}