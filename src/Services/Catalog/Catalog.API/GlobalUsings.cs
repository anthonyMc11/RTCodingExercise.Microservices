﻿global using Microsoft.AspNetCore;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.EntityFrameworkCore.Migrations;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;

global using Catalog.API;
global using Catalog.API.Handlers;
global using Catalog.API.Data;
global using Catalog.API.Models.Plates;
global using Catalog.API.Repositories;
global using Catalog.API.Services;
global using Catalog.Domain;


global using Serilog;

global using System;
global using System.Collections.Generic;
global using System.IO;
global using System.Linq.Expressions;
global using System.Reflection;
global using System.Threading.Tasks;