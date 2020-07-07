using Jobify.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jobify {
    public class MainController {

        private readonly JobService job_S;

        public JobService Job_S { get => job_S; }

        public MainController() {
            job_S = new JobService();
        }

        
    }
}
