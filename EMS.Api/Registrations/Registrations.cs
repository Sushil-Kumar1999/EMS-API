using Autofac;
using EMS.Core.Application.Assemblers;
using EMS.Core.Application.Infrastructure.Persistence;
using EMS.Core.Application.Infrastructure.Security;
using EMS.Persistence.EntityFrameworkCore;
using EMS.Security.Jwt;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EMS.Api.Registrations
{
    public static class Registrations
    {
        private static readonly Assembly CoreAssembly = typeof(IDataTransferAssembler<,>).Assembly;
        private static readonly Assembly PersistenceAssembly = typeof(UnitOfWork).Assembly;

        public static void RegisterServices(this ContainerBuilder builder)
        {
            // Mediator -> Searches for Commands and Queries and registers them.
            builder.RegisterMediatR(CoreAssembly, PersistenceAssembly);
            //builder.RegisterGeneric(typeof(ValidationBehaviour<,>)).As(typeof(IPipelineBehavior<,>));

            // Services
            builder.RegisterAssemblyTypes(CoreAssembly)
                .PublicOnly()
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // Managers
            builder.RegisterType<TokenManager>().As<ITokenManager>().InstancePerLifetimeScope();
            builder.RegisterType<SecurityManager>().As<ISecurityManager>().InstancePerLifetimeScope();
        }

        public static void RegisterPersistence(this ContainerBuilder builder)
        {
            // Repositories
            builder.RegisterAssemblyTypes(PersistenceAssembly)
                .PublicOnly()
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // Units of work
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
        }

    }
}
