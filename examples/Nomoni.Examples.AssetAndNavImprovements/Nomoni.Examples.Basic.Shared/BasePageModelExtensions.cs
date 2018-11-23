using Nomoni.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nomoni.Examples.Basic.Shared
{
    public static class BasePageViewModelExtensions
    {

        public static T AddPageScript<T>(this T viewModel, string url) where T : BasePageViewModel
        {
            viewModel.PageScripts.Add(url);

            return viewModel;
        }

        public static T AddPageStyles<T>(this T viewModel, string url) where T : BasePageViewModel
        {
            viewModel.PageScripts.Add(url);

            return viewModel;
        }

        public static T PopulateMenu<T>(this T viewModel) where T : BasePageViewModel
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            foreach (IMenu menu in AssemblyResolution.GetInstances<IMenu>())
                menuItems.AddRange(menu.MenuItems);

            viewModel.MenuItems = menuItems;

            return viewModel;
        }

    }
}
