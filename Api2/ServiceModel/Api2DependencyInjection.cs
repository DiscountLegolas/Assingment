using Api2.ServiceModel.Abstract.Repository;
using Api2.ServiceModel.Abstract.Service;
using Api2.ServiceModel.Concrete.Repository;
using Api2.ServiceModel.Concrete.Service;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.ServiceModel
{
    public class Api2DependencyInjection: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Repository Dependency Injectionları
            builder.RegisterType<UserRepo>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<CommentRepo>().As<ICommentRepo>().SingleInstance();
            builder.RegisterType<EntryRepo>().As<IEntryRepo>().SingleInstance();
            //Service Dependency Injectionları
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<CommentService>().As<ICommentService>().SingleInstance();
            builder.RegisterType<EntryService>().As<IEntryService>().SingleInstance();
        }
    }
}
