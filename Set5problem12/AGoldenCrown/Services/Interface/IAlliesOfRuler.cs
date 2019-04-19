using System;
using System.Collections.Generic;
using System.Text;

namespace AGoldenCrown.Services
{
    public interface IAlliesOfRuler
    {
        string WhoAreTheAlliesOfRuler(string question, List<string> inputMessages);

        string GetAllies(List<string> inputMessages);
    }
}
