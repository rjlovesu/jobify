using Jobify.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Jobify.Services {
    class JobTypeService : Service {

        //TODO
        private static List<JobType> jobTypes = new List<JobType>() {
             new JobType(){Name="Window Cleaning"}
            ,new JobType(){Name="Carpenter"}
            ,new JobType(){Name="Recreational Therapist"}
            ,new JobType(){Name="Medical Secretary"}
            ,new JobType(){Name="Customer Service Representative"}
            ,new JobType(){Name="Physician"}
            ,new JobType(){Name="Chemist"}
            ,new JobType(){Name="Systems Analyst"}
            ,new JobType(){Name="Writer"}
            ,new JobType(){Name="Executive Assistant"}
            ,new JobType(){Name="Loan Officer"}
            ,new JobType(){Name="College Professor"}
            ,new JobType(){Name="Logistician"}
            ,new JobType(){Name="Cost Estimator"}
            ,new JobType(){Name="Insurance Agent"}
            ,new JobType(){Name="Financial Advisor"}
            ,new JobType(){Name="Psychologist"}
        };

        public JobTypeService() {
             

        }

        public override void Init() { }

        public ReadOnlyCollection<JobType> GetAllJobTypes() {

            //TODO later implement some access to a database
            return jobTypes.AsReadOnly();
        }

        public string[] GetAllJobNames() {
            return jobTypes.Select(jt => jt.Name).ToArray();
        }

        public bool AddNewJobType(JobType jobtype) {
            if(jobtype.Name != null&& jobtype.Name != "" && !jobTypes.Exists(jt => jobtype.Name==jt.Name) ){
                jobTypes.Add(jobtype);
                return true;
            } else {
                return false;
            }
            
        }

        public JobType JobTypeByTitle(string str) {
            return jobTypes.Find(jt => jt.Name == str);
        }

    }
}
