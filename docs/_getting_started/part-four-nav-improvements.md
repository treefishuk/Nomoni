---
layout: doc
title:  "Part 4: Navigation Improvements"
date:   2018-12-07 22:00:00
categories: beginner
published: true
order: 4

---

## Prerequisites

To start this tutorial you will need to have completed parts 1 & 2: 

- [Part 1 : Basic Web App with single module](/docs/getting-started/part-one-basic-web-app-with-single-module)
- [Part 2 : Adding a Second Module](/docs/getting-started/part-two-adding-a-second-module)
- [Part 3 : Asset Improvements](/docs/getting-started/part-three-asset-improvements)

## Outcome

The aim of this tutorial is to make the navigation bar dynamic based upon loaded modules. The only way to get to "/admin/management" at the moment is to type in the URL directly at the moment. So these next few steps will fix that.

## Step 1 : Add a new Menu Item Class to the Shared Project

Add MenuItem.cs to the shared project :

```
    public class MenuItem
    {
        public string Name { get; }
        public string Url { get; }
        public int Position { get; }
       
        public MenuItem(string name, int position, string url)
        {
            this.Name = name;
            this.Position = position;
            this.Url = url;
        }
    }

```

## Step 2 : Add a new IMenu Interface to the Shared Project

Add IMenu.cs to the shared project :

```
    public interface IMenu
    {
        IEnumerable<MenuItem> MenuItems { get; }
    }

```

## Step 3 : Add Nomoni.Core.Helpers Nuget Package to the Shared Project


```
Install-Package Nomoni.Core.Helpers
```

## Step 4 : Add Menu Items to BasePageViewModel.cs


```
    public class BasePageViewModel
    {
        public BasePageViewModel()
        {
            PageScripts = new List<string>();
            PageStyles = new List<string>();
            this.PopulateMenu();
        }

        public string PageTitle { get; set; }

        public List<string> PageScripts { get; set; }

        public List<string> PageStyles { get; set; }

        public IEnumerable<MenuItem> MenuItems { get; set; }

    }
```

The PopulateMenu Extension will be created in the next step.


## Step 5 : Add new Extension Method to BasePageModelExtensions.cs


```
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
```


## Step 6 : Update _Layout.cshtml again

Update the "Nav" section of _Layout.cshtml to : 

```

    <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">

                    @foreach (var menuitem in Model.MenuItems.OrderBy(x => x.Position))
                    {
                        <li><a href="@menuitem.Url">@menuitem.Name</a></li>
                    }
                </ul>
            </div>
        </div>
    </nav>
```


## Step 7 : Add Menu Items for Base Module

Add RegisterMenuItems.cs to the Registrations folder of the base module with: 

```

    public class RegisterMenuItems : IMenu
    {
        public IEnumerable<MenuItem> MenuItems
        {
            get
            {
                return new MenuItem[]
                {
                            new MenuItem("Home", 100, "/"),
                            new MenuItem("About", 120, "/home/about"),
                            new MenuItem("Contact", 130, "/home/contact")
                };
            }
        }
    }
```

## Step 8 : Add Menu Items for Admin Module

Add RegisterMenuItems.cs to the Registrations folder of the admin module with: 

```

    public class RegisterMenuItems : IMenu
    {
        public IEnumerable<MenuItem> MenuItems
        {
            get
            {
                return new MenuItem[]
                {
                            new MenuItem("Management", 200, "/admin/management")
                };
            }
        }
    }
```


## The Source Code for this Tutorial can be found

[https://github.com/treefishuk/nomoni/tree/master/examples/Nomoni.Examples.AssetAndNavImprovements](https://github.com/treefishuk/nomoni/tree/master/examples/Nomoni.Examples.AssetAndNavImprovements)

## Next Steps

In the Next Tutorial we will look at adding security to the solution.

[Part 5 : Security](/nomoni/docs/getting-started/part-five-security)

