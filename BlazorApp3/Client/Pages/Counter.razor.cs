using BlazorApp3.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlazorApp3.Client.Shared.MainLayout;

namespace BlazorApp3.Client.Pages
{
    public partial class Counter
    {
              

        private int currentCount = 0;
       
        public void IncrementCount()
        {
            currentCount++;
       
        }

    }
}
