using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Internals;

namespace Jobify.Services {
    public abstract class Service {
        public abstract void Init();
    }

    public sealed class ServiceManager {
        //Variables 
        //(add services types here - they have to extend Service)
        private static Dictionary<Type, Service> Services { get; set; } = new Dictionary<Type, Service>() {
            {typeof(JobService) , null},
            {typeof(UserService) , null},
            {typeof(JobTypeService) , null},
        };
        //Constructor
        private ServiceManager() {
            //instantiating all services
            Services = Services
                .Select(service => new KeyValuePair<Type, Service>(service.Key, (Service)Activator.CreateInstance(service.Key)))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            
        }

        

        public static T GetService<T>() where T : Service{
            return (T)Instance.getService(typeof(T));
        }

        

        private Service getService(Type type) {
            try {
                return Services[type];
            }catch(KeyNotFoundException e) {
                Console.WriteLine("No such service found!");
                throw e;
            }
        }

        static ServiceManager() {
        }

        public static ServiceManager Instance { get; } = new ServiceManager();

        public static void Init() {
            Services.ForEach(s => s.Value.Init());
        }



    }



}

