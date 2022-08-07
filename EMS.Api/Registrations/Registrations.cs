using Autofac;
using EMS.Core.Application.Assemblers;
using EMS.Persistence.EntityFrameworkCore;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EMS.Api.Registrations
{
    public static class Registrations
    {
        private static readonly Assembly CoreAssembly = typeof(IDataTransferAssembler<,>).Assembly;
        private static readonly Assembly PersistenceAssembly = typeof(UnitOfWork).Assembly;

        public static void RegisterServices(this ContainerBuilder builder)
        {

            //Mediator -> Searches for Commands and Queries and registers them.
            builder.RegisterMediatR(CoreAssembly, PersistenceAssembly);
            //builder.RegisterGeneric(typeof(ValidationBehaviour<,>)).As(typeof(IPipelineBehavior<,>));

            // Services
            builder.RegisterAssemblyTypes(CoreAssembly)
                .PublicOnly()
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

    }
}
