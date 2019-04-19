using System;
using System.Collections.Generic;
using System.Text;

namespace AGoldenCrown.Services
{
    public interface IRulerOfSoutheros
    {
        string SearchRuler(string question, List<string> inputMessages);
        string WhoIsTheRuler(List<string> inputMessages);
    }
}
