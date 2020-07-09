using Jobify.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Jobify.Services {
    public abstract class Service {

    }

    public sealed class ServiceManager {
        //Variables 
        //(add services types here - they have to extend Service)
        private static Dictionary<Type, Service> Services { get; set; } = new Dictionary<Type, Service>() {
            {typeof(JobService) , null}
        };
        //Constructor
        private ServiceManager() {
            //instantiating all services
            Services = Services
                .Select(service => new KeyValuePair<Type, Service>(service.Key, (Service)Activator.CreateInstance(service.Key)))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        public Service GetService(Type type) {
            try {
                return Services[type];
            }catch(KeyNotFoundException e) {
                Console.WriteLine("No such service found!");
                throw e;
            }
        }

        //Singleton Pattern
        private static readonly ServiceManager instance = new ServiceManager();
        static ServiceManager() {
        }
        public static ServiceManager Instance {
            get {
                return instance;
            }
        }





    }



}

