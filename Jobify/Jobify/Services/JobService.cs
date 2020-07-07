using Jobify.Models;
using Naxam.Mapbox;
using System.Collections.Generic;

namespace Jobify.Services
{
    public interface IJobService{
        List<Job> GetAllJobs();
    }

    public class JobService : IJobService {

        //TODO this will change
        static List<Job> allJobs = new List<Job>{
            new Job(new LatLng(56.957535, 24.115249),"Example1"),
            new Job(new LatLng(56.957513, 24.114702),"Example2"),
            new Job(new LatLng(56.957449, 24.115963),"Example3"),
            new Job(new LatLng(56.957440, 24.116970),"Example4"),
            new Job(new LatLng(56.957777, 24.115555),"Example5"),
            new Job(new LatLng(56.957000, 24.115000),"Example6"),
            new Job(new LatLng(56.957999, 24.115777),"Example7"),
        };

        public List<Job> GetAllJobs() {

            //TODO later implement some access to a database
            return allJobs;
        }
    }
}
