# InteractiveViewSystem
A UI framework coupled with the WPF framework created like experimental project to facilitate CRUD operations.

# Description
The project was created as homemade project inspired by a book "Applying UML and Patterns: An Introduction to Object-Oriented Analysis and Design and Iterative Development (3rd Edition), Craig Larman". So, project was created and passed 3 iterations  in strict accordance to this book. The main idea to reduce borden of creating interfaces for CRUD operations  that can help concentrate on your business logic. Although, in strict accordance with  MVVM principles, you can vary your view representations very freely.

Even if it homemade, the project was used in several "real" products, more or less successfully (I'd like to think more;) ). Although being developed to work with WPF framework, what looks like old by now,  all parts decoupled so maybe it will be possible to use with such a modern thing like Blazor etc. ( Of cause it has to be changed, and maybe considerably).
The project was started nearly 3 years ago, but it's not possible to move all history in here (by now). It was developing very quickly in the first year but then was almost abandoned for several years (partly because my interests were shifted to web development), but now I think it’s worth to publish it anyway.

Again, the project was created with the understanding that there are many  others mature projects in this fields like MVVM Light etc., but the main goal was to try to write something considerable by myself and at the same time simple and that could be useful in my day to day work.
Also, have to notice that many project artifacts written by russian language, but I'm definitely gonna change it.
I hope you'll enjoy this;)

# Install
You can install from nuget package InteractiveViewSystem (https://www.nuget.org/packages/InteractiveViewSystem/ )

# UsageExamples
To start up with framework I'd definitely recommend to look at Usage Examples. Here is steps to set up.
You have to use MS Visual Studio (the project was developed with VS 17)
Clone repository on your local machine
Open up MS Visual Studio.
Restore packages for all solution

## InteractiveViewSystemUseGenericExample
go to /UsageExamples/ShopsProducts/InteractiveViewSystemUseGenericExample project in your solution tree
You can already run it! 
This is an example that keep all data in memory. It's not very easy because it redefine View and ViewModel layer respectively (if fact you don't need to do it! Look at BusRoutes and DeliveryExample examples)

## BusRoutes
This is the project that show up how to use a framework with connection to database.
go to /UsageExamples/BusRoutes/BusRoutes
To start you have to make sure that you've already installed SQL Server Express LocalDB. If not you can simply do it in Visual Studio Installer: "In the Visual Studio Installer, you can install SQL Server Express LocalDB as part of the .NET desktop development workload or as an individual component."
After that uncomment this string //StotageUtils.GenerateTestDataAndSave(); in a MainWindow.xaml.cs file and run the project.
This initiates database here C:\Users\{Username}\ with name BusRoutes.mdf (if you have problems with creating or getting access to it, try to change db name in config file connection string here /UsageExamples/BusRoutes/BusRoutes/App.config) and starts we project.
Don't forget to commit this string //StotageUtils.GenerateTestDataAndSave(); back before the second run.

## DeliveryExample
This is the project that show up how to communicate with remote service.
go to /UsageExamples/Delivery/DeliveryExample
Unfortunately it doesn't work now (I have to restore server part). I'm going to fix it.



