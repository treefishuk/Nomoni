![alt text](https://treefish.visualstudio.com/Nomoni/_apis/build/status/Nomoni%20CI%20Build "build status")

## Introduction

Nomoni is a few tiny nuget packages that help you:  

- Split up a .net core web app into separate manageable modules
- Auto register implementations of interfaces
- Make EFCore more modular and auto register entities
- Adhere to SOLID principles
- Keep things organized and tidy

## Requirements

- The .net core MVC projects need to be targeting 2.1

## Packages

The available packages are:

- Nomoni.Core.Abstractions
- Nomoni.Core.Helpers
- Nomoni.Mvc
- Nomoni.Data.Abstractions
- Nomoni.Data.EntityFramework

### Nomoni.Core.Abstractions

This provides interfaces for automatic service and module registration.

### Nomoni.Core.Helpers

This provides helpers to automatically scan the projects .dll's and RegisterAllTypes in those .ddl's that inherit from a given interface.

### Nomoni.Mvc

This is the minimum required packages to use Nomoni. It provides a simple services extension method that sets everything up to go.

### Nomoni.Data.Abstractions

This provides the interfaces for any object relational mapper to inherit from.

### Nomoni.Data.EntityFramework

This provides EFCore implementation of the interfaces in Nomoni.Data.Abstractions. In the future there may be other implementations but it is just EFcore for now.

## What does Nomoni mean?

So the idea with this is that it is friendly sounding abbreviated(ish) version of "No Monoliths". Or if you pronounce it differently then it can sound like "no money" as in free and open source which the project is. It's basically a made up word.

## Getting Started

### Tutorials:

- [Part 1 : ASP Web App With Single Module](https://treefish.uk/Nomoni/docs/2.1/getting-started/part-one-basic-web-app-with-single-module) 
- [Part 2 : Adding a Second Module](https://treefish.uk/Nomoni/docs/2.1/getting-started/part-two-adding-a-second-module) 
- [Part 3 : Asset and Navigation Improvements](https://treefish.uk/Nomoni/docs/2.1/getting-started/part-three-asset-and-nav-improvements)
- [Part 4 : Adding Security](https://treefish.uk/Nomoni/docs/2.1/getting-started/part-four-security)

### Tutorials Coming Soon..

- Part 5 : Modular Entity Framework
- Part 6 : Integrating SaasKit
- Part 7 : Integrating Identity Server

### Sample projects on GitHub:

- [Part 1 : ASP Web App With Single Module](https://github.com/treefishuk/nomoni/tree/master/examples/Nomoni.Examples.Basic/) 
- [Part 2 : ASP Web App With Second Module](https://github.com/treefishuk/nomoni/tree/master/examples/Nomoni.Examples.SecondModule/) 
- [Part 3 : Asset and Navigation Improvements](https://github.com/treefishuk/nomoni/tree/master/examples/Nomoni.Examples.AssetAndNavImprovements/) 
- [Part 4 : Adding Security](https://github.com/treefishuk/nomoni/tree/master/examples/Nomoni.Examples.Security/) 

### Support

Please feel free to raise issues on the [github page](https://github.com/treefishuk/nomoni/issues).

### Inspiration

This work was largely based on the work of Dmitry Sikorsky and his [Ext Core Framework](https://github.com/ExtCore/ExtCore/)

As great as the framework is it was too large for me and it didn't support a few things which I required.

#### Differences to Ext Core

- Javascript and CSS files paths are maintained 
- Consuming projects with the exception of the MVC projects are .net standard
- Far less going on, 5 simple projects instead 18

