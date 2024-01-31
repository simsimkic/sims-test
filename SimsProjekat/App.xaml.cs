using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using SimsProjekat.Repositories;
using SimsProjekat.Domain.Interfaces.Repositories;
using SimsProjekat.Domain.Interfaces.Services;
using SimsProjekat.Applications.Services;
using SimsProjekat.Applications.Controllers;

namespace SimsProjekat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public static IServiceProvider Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .Build();

            _host.Start();
        }

        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddTransient(typeof(IApartmentRepository), typeof(ApartmentRepository));
            services.AddTransient(typeof(IReservationRepository), typeof(ReservationRepository));
            services.AddTransient(typeof(IHotelRepository), typeof(HotelRepository));
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));

            services.AddTransient(typeof(IApartmentService), typeof(ApartmentService));
            services.AddTransient(typeof(IApartmentReservationService), typeof(ApartmentReservationService));
            services.AddTransient(typeof(IHotelSearchService), typeof(HotelSearchService));
            services.AddTransient(typeof(IHotelService), typeof(HotelService));
            services.AddTransient(typeof(ILoginService), typeof(LoginService));
            services.AddTransient(typeof(IUserService), typeof(UserService));

            services.AddTransient<ApartmentController>();
            services.AddTransient<ApartmentReservationController>();
            services.AddTransient<HotelController>();
            services.AddTransient<LoginController>();
            services.AddTransient<UserController>();

            Services = services.BuildServiceProvider();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            _host.Dispose();
        }
    }
}
