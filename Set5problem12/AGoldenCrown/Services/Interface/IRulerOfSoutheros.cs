using System;
using System.Collections.Generic;
using System.Text;

namespace AGoldenCrown.Services
{
    public interface IRulerOfSoutheros
    {
        string WhoIsTheRuler(List<string> inputMessages);
        StringBuilder AlliesOfRuler(List<string> inputMessages);
    }
}
