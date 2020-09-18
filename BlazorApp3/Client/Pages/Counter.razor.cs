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
        [Inject]
        SingletonService singleton { get; set; }
        [Inject] 
        TransientService transient { get; set; }
        [Inject]
        IJSRuntime js { get; set; }

        [CascadingParameter]
        public AppState state { get; set; }
        

        private int currentCount = 0;
        private static int currentCountStatic = 0;

        private List<Movie> movies;
        protected override void OnInitialized()
        {
            movies = new List<Movie>()
            {
                new Movie() { Title = "Joker", ReleaseDate = new DateTime(2019, 7, 2) },
                new Movie() { Title = "Avengers", ReleaseDate = new DateTime(2016, 11, 23) },
            };
        }

        [JSInvokable]
        public async Task IncrementCount()
        {
            currentCount++;
            currentCountStatic++;
            transient.value = currentCount;
            singleton.value = currentCount;
            await js.InvokeVoidAsync("dotnetStaticInvocation");
        }

        [JSInvokable]
        public static Task<int> GetCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }

        private async Task IncrementCountJavaScript()
        {
            await js.InvokeVoidAsync("dotnetInstanceInvocation", DotNetObjectReference.Create(this));
        }
    }
}
