using System;
using System.Collections.Generic;
using System.Text;

namespace AGoldenCrown.Services
{
    public interface IAlliesOfRuler
    {
        StringBuilder WhoAreTheAlliesOfRuler(string question, List<string> inputMessages);

        StringBuilder GetAllies(List<string> inputMessages);
    }
}
