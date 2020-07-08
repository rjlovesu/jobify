using Jobify.Models;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace Jobify.Services
{
    public class JobService : Service {

        //TODO this will change
        public static List<Job> allJobs = new List<Job>{
            new Job(new Position(56.882859, 23.957760),"Example1"),
            new Job(new Position(57.075190, 24.316189),"Example2"),
            new Job(new Position(56.660865, 24.222805),"Example3"),
            new Job(new Position(56.633684, 23.772365),"Example4"),
            new Job(new Position(57.125913, 24.761135),"Example5"),
            new Job(new Position(56.916608, 23.319179),"Example6"),
            new Job(new Position(56.567159, 23.720180),"Example7"),
        };

        public List<Job> GetAllJobs() {

            //TODO later implement some access to a database
            return allJobs;
        }
    }
}
