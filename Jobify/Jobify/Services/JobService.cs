using Jobify.Models;
using System.Collections.Generic;
using Xamarin.Forms.GoogleMaps;
using System.Linq;
using System;

namespace Jobify.Services
{
    public class JobService : Service {
        

        //TODO this will change
        public static List<Job> allJobs = new List<Job>{
            new Job(new Position(56.882859, 23.957760),"Window Cleaning") { SkillsRequired ="Basic knowledge", PhoneNumber="29583958", Pay="25€", Info="I have all the necessary equipment"},
            new Job(new Position(57.075190, 24.316189),"Car Wash"),
            new Job(new Position(56.660865, 24.222805),"Janitor"),
            new Job(new Position(56.633684, 23.772365),"Moving Helper"),
            new Job(new Position(57.125913, 24.761135),"Construction Site Guard"),
            new Job(new Position(56.916608, 23.319179),"IT Support"),
            new Job(new Position(56.567159, 23.720180),"Life Guard")
        };

        public JobService() {
            
            
        }

        
        public List<Job> GetAllJobs() {

            //TODO later implement some access to a database
            return allJobs;
        }

        public Job FindFirstJobByTitle(string title) {
            return allJobs.FirstOrDefault(j => j.Title.Equals(title));
        }

        public override void Init() {
            var job = FindFirstJobByTitle("Window Cleaning");
            job.Author = ServiceManager.GetService<UserService>().FindUserByEmail("zack.example@gmail.com");

        }
    }
}
