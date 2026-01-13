using System;
using System.Collections.Generic;
using System.Text;
using TwIndex.Core.Services;

namespace TwIndex.Navigation
{
    public class MauiNavigationService : INavigationService
    {
        public Task GoToAsync(string route, IDictionary<string, object>? parameters = null)
        {
            if (parameters == null)
                return Shell.Current.GoToAsync(route);
            
            return Shell.Current.GoToAsync(route, parameters);
        }

        public Task GoBackAsync()
        {
            return Shell.Current.GoToAsync("..");
        }
    }
}
