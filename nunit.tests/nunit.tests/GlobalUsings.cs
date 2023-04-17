// Global using directives

global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Reflection;
global using FluentAssertions;
global using NUnit.Framework;
global using OpenQA.Selenium;
global using OpenQA.Selenium.Chrome;
global using WebDriverManager;
global using WebDriverManager.DriverConfigs.Impl;

[assembly: LevelOfParallelism(2)]
[assembly: Parallelizable(ParallelScope.All)]