---
layout: post
title:  "Getting Started - Part 5 : Entity Framework"
date:   2018-12-07 22:00:00
categories: beginner
---

## Prerequisites

To start this tutorial you will need to have completed the first 3 parts in the series:

- [Part 1 : Basic Web App with single module](https://treefish.uk/nomoni/docs/tutorials/part-one-basic-web-app-with-single-module)
- [Part 2 : Adding a Second Module](https://treefish.uk/nomoni/docs/tutorials/part-two-adding-a-second-module)
- [Part 3 : Asset](https://treefish.uk/nomoni/docs/tutorials/part-three-asset-and-nav-improvements)

The result of which is a basic MVC .net core app with a two modules and modular inclusion of javascript and css.

## Outcome

The aim of this tutorial is to add access to add storage to the project:


## Step 1 : Add a new .net core MVC web app

Add a new .net core project to the solution for identity server.

![Empty Project](../images/MVC-App.PNG "MVC App")

**Make sure to change Authentication to "Individual user accounts"**


## Step 2 : Identity Server nuget package

Install the IdentityServer4.AspNetIdentity in the new project

```
Install-Package IdentityServer4.AspNetIdentity
```


## Step 3 : Add a Config.cs file

Add a class to the new project that looks like this:

```
    public class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RequireConsent = false,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris = { "https://localhost:" + Environment.GetEnvironmentVariable("Nomoni_Port") + "/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:" + Environment.GetEnvironmentVariable("Nomoni_Port") + "/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },

                    AllowOfflineAccess = true
                }
            };
        }
    }
```

Make sure to add an environment variable named Nomoni_Port to the project, with the value of the Identity Server Port.

## Step 4 : Update Startup.cs in Identity Server project

Update the Startup.cs in the Identity Server project to look like this:

```
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryPersistedGrants()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryClients(Config.GetClients())
                .AddAspNetIdentity<IdentityUser>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentityServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
```


## Step 5 : Update Startup.cs in Main project

Update the Startup.cs in the Main project to look like this:

```
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.UseNomoni();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie()
            .AddOpenIdConnect("oidc", options =>
            {
                options.SignInScheme = "Cookies";

                options.Authority = "https://localhost:" + Environment.GetEnvironmentVariable("IdentityServer_Port");
                options.RequireHttpsMetadata = false;
                    
                options.ClientId = "mvc";
                options.SaveTokens = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseNomoni();

            app.UseStaticFiles();
  
        }
    }
```

Note :  The **order is really important**.  "UseAuthentication" **MUST** appear before "UseNomoni"

Also make sure to add the IdentityServer_Port environment variable.


## Step 6 : Add Authorize attribute to controller

On the management controller add the Authorize attribute.  : 

```

    [Authorize]
    public class ManagementController : Controller

```

## Step 7 : Build and test

Try and go to the management section. You should get redirected to the Identity Server web app. Enter a valid user and login and you should get redirected back to the Nomoni web app and now be logged in.

Note : You may want to create a user first from the Identity Server app directly. You will also need to seed the database which you should be prompted with a big button to do. 



## Step 8 : Add a Logout button

The HomeController.cs file will need amending to pass a BasePageViewModel to the view as follows :

```
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new BasePageViewModel();

            return View(model);
        }

        public IActionResult About()
        {

            var model = new BasePageViewModel();

            ViewData["Message"] = "Your application description page.";

            return View(model);
        }

        public IActionResult Contact()
        {

            var model = new BasePageViewModel();

            ViewData["Message"] = "Your contact page.";

            return View(model);
        }

        public IActionResult Privacy()
        {
            var model = new BasePageViewModel();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

```

## Step 9 : Launch App

Upon inspecting the source code for the page for "/admin/management" the web app should now show the stylesheet in the head of the web page and the script at the bottom of the page. This now means that the mosdule scripts could depend on JQuery or any other library framework loaded before the module scripts in _layout.cshtml. 


## Step 10 : Making the Navigation Dynamic

So thats the scripts and styles sorted but the only way to get to "/admin/management" is to type in the URL directly. So these next few steps will fix that.

## Step 11 : Add a new Menu Item Class to the Shared Project

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

## Step 12 : Add a new IMenu Interface to the Shared Project

Add IMenu.cs to the shared project :

```
    public interface IMenu
    {
        IEnumerable<MenuItem> MenuItems { get; }
    }

```

## Step 13 : Add Nomoni.Core.Helpers Nuget Package to the Shared Project


```
Install-Package Nomoni.Core.Helpers
```

## Step 14 : Add Menu Items to BasePageViewModel.cs


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


## Step 15 : Add new Extension Method to BasePageModelExtensions.cs


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


## Step 16 : Update _Layout.cshtml again

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


## Step 17 : Add Menu Items for Base Module

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

## Step 18 : Add Menu Items for Admin Module

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

In the Next Tutorial we will fix the issues with the css and javascript placement, and also amend the navigation bar to include the new admin module.