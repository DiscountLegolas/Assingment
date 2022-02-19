using Api.ServiceModel.Abstract.Repository;
using Api.ServiceModel.Abstract.Service;
using Api.ServiceModel.Concrete.Repository;
using Api.ServiceModel.Concrete.Service;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ServiceModel.DependencyResolvers.Autofac
{
    public class DependenyInjectionModülü:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Repository Dependency Injectionları
            builder.RegisterType<CommentRepo>().As<ICommentRepo>().SingleInstance();
            builder.RegisterType<UserRepo>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<EntryRepo>().As<IEntryRepo>().SingleInstance();
            //Service Dependency Injectionları
            builder.RegisterType<EntryService>().As<IEntryService>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
        }
    }
}
