using System;
using System.Collections.Generic;
using System.Text;

namespace CubeXNative.Models
{
    public class Login : BaseDataObject
    {
        public string linkId { get; set; }
        public string emailId { get; set; }
        public string ImageName { get; set; }
        public string Message { get; set; }
        public string name { get; set; }
        public int UserId { get; set; }
        public string code { get; set; }

        public string savedJobList { get; set; }
        public string appliedJobList { get; set; }
        public List<LoginJobList> savedjobs { set; get; }
        public List<LoginJobList> appliedjobs { set; get; }
    }

    public class LoginJobList
    {
        public string appliedJobId { get; set; }
        public string savedJobId { get; set; }
        public string position { get; set; }
        public string date { get; set; }
        public string jobId { get; set; }
        public string subject { get; set; }
    }
}
