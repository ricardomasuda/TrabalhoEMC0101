using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoEMC0101.Pacote
{
    class Request
    {
        public interface IRequest
        {
            string Action { get; set; }
        }
        public class SimppleRequest : IRequest
        {
            public string Action { get; set; }
            public SimppleRequest(string action)
            {
                Action = action;
            }
        }
    }
}
