using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp3.Client
{
    public class SingletonService
    {
        public int value { get; set; }
    }

    public class TransientService
    {
        public int value { get; set; }
    }
}
