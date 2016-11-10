using System;

using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;

using Dealership.Contracts;
using Dealership.CommandHandler;
using Dealership.Engine;
using Dealership.Models;
using Dealership.Factories;

namespace Dealership
{
    public class NinjectConfig : NinjectModule
    {
        private const string CarName = "Car";
        private const string MotorcycleName = "Motorcycle";
        private const string TruckName = "Truck";

        private const string RegisterUserCommandHandlerName = "RegisterUserCommandHandler";
        private const string LoginUserCommandHandlerName = "LoginUserCommandHandler";
        private const string LogoutUserCommandHandlerName = "LogoutUserCommandHandler";
        private const string AddVehicleCommandHandlerName = "AddVehicleCommandHandler";
        private const string RemoveVehicleCommandHandlerName = "RemoveVehicleCommandHandler";
        private const string AddCommentCommandHandlerName = "AddCommentCommandHandler";
        private const string RemoveCommentCommandHandlerName = "RemoveCommentCommandHandler";
        private const string ShowUsersCommandHandlerName = "ShowUsersCommandHandler";
        private const string ShowVehiclesCommandHandlerName = "ShowVehiclesCommandHandler";

        public override void Load()
        {
            Kernel.Bind(x =>
            x.FromThisAssembly()
            .SelectAllClasses()
            .BindDefaultInterface());

            this.Bind<Func<string>>().ToMethod(ctx => () =>
            {
                return Console.ReadLine();
            });

            this.Bind<Action<string>>().ToMethod(ctx => (param) =>
            {
                Console.Write(param);
            });

            this.Bind<IVehicle>().To<Car>().Named(CarName);
            this.Bind<IVehicle>().To<Motorcycle>().Named(MotorcycleName);
            this.Bind<IVehicle>().To<Truck>().Named(TruckName);
            this.Bind<IDealershipFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommandHandler>().To<RegisterUserCommandHandler>().Named(RegisterUserCommandHandlerName);
            this.Bind<ICommandHandler>().To<LoginUserCommandHandler>().Named(LoginUserCommandHandlerName);
            this.Bind<ICommandHandler>().To<LogoutUserCommandHandler>().Named(LogoutUserCommandHandlerName);
            this.Bind<ICommandHandler>().To<AddVehicleCommandHandler>().Named(AddVehicleCommandHandlerName);
            this.Bind<ICommandHandler>().To<RemoveVehicleCommandHandler>().Named(RemoveVehicleCommandHandlerName);
            this.Bind<ICommandHandler>().To<AddCommentCommandHandler>().Named(AddCommentCommandHandlerName);
            this.Bind<ICommandHandler>().To<RemoveCommentCommandHandler>().Named(RemoveCommentCommandHandlerName);
            this.Bind<ICommandHandler>().To<ShowUsersCommandHandler>().Named(ShowUsersCommandHandlerName);
            this.Bind<ICommandHandler>().To<ShowVehiclesCommandHandler>().Named(ShowVehiclesCommandHandlerName);

            this.Bind<ICommandHandler>().ToMethod(ctx =>
            {
                var registerHandler = ctx.Kernel.Get<ICommandHandler>(RegisterUserCommandHandlerName);
                var loginHandler = ctx.Kernel.Get<ICommandHandler>(LoginUserCommandHandlerName);
                var logoutHandler = ctx.Kernel.Get<ICommandHandler>(LogoutUserCommandHandlerName);
                var addVehicleHandler = ctx.Kernel.Get<ICommandHandler>(AddVehicleCommandHandlerName);
                var removeVehicleHandler = ctx.Kernel.Get<ICommandHandler>(RemoveVehicleCommandHandlerName);
                var addCommenthandler = ctx.Kernel.Get<ICommandHandler>(AddCommentCommandHandlerName);
                var removeCommentHandler = ctx.Kernel.Get<ICommandHandler>(RemoveCommentCommandHandlerName);
                var showUsersHandler = ctx.Kernel.Get<ICommandHandler>(ShowUsersCommandHandlerName);
                var showVehiclesHandler = ctx.Kernel.Get<ICommandHandler>(ShowVehiclesCommandHandlerName);

                registerHandler.AddCommandHandler(loginHandler);
                loginHandler.AddCommandHandler(logoutHandler);
                logoutHandler.AddCommandHandler(addVehicleHandler);
                addVehicleHandler.AddCommandHandler(removeVehicleHandler);
                removeVehicleHandler.AddCommandHandler(addCommenthandler);
                addCommenthandler.AddCommandHandler(removeCommentHandler);
                removeCommentHandler.AddCommandHandler(showUsersHandler);
                showUsersHandler.AddCommandHandler(showVehiclesHandler);
                return registerHandler;
            })
            .WhenInjectedInto<DealershipEngine>()
            .InSingletonScope();

            this.Bind<IEngine>().To<DealershipEngine>().InSingletonScope();
        }
    }
}
