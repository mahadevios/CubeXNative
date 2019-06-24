using CubeXNative.Helpers;
using CubeXNative.Models;
//using ListDemo.ViewModels;
//using ListDemo.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//using Xamarin.Forms;

//[assembly: Dependency(typeof(ListDemo.Services.ApiStore))]

namespace CubeXNative.Services
{
    public class ApiStore : IApiStore
    {
        HttpClient client = null;
        //List<JobList> JobList = new List<JobList>();

        public ApiStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(APIConstants.BaseUrl);
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
        }


        //return Task<LoginResponse>
        public async Task<Login> login(User user)
        {
            Login loginResponse = null;

            try
            {

                HttpContent content = new StringContent(String.Format(RequestConstants.mobileLogin,
                    user.username, user.password,
                    user.deviceToken), Encoding.UTF8, "application/x-www-form-urlencoded");
                //response from API
                var response = await client.PostAsync(APIConstants.login, content);
                //data from response  in string format
                var responseString = await response.Content.ReadAsStringAsync();

                //Convert to Joblist object
                if (!string.IsNullOrEmpty(responseString))
                {
                    loginResponse = JsonConvert.DeserializeObject<Login>(responseString);

                    if (!string.IsNullOrEmpty(responseString) && loginResponse.code.Equals("1000"))
                    {
                        //loginResponse.savedjobs = JsonConvert.DeserializeObject<List<LoginJobList>>(loginResponse.savedJobList);
                        //loginResponse.appliedjobs = JsonConvert.DeserializeObject<List<LoginJobList>>(loginResponse.appliedJobList);
                    }    
                }

                return loginResponse;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public async Task<JobList> mobileVerticalJob(ExtendedUser user)
        //{
        //    JobList jobListResponse = null;
        //    try
        //    {
        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileVerticalJob, user.username, user.password, user.varticalId, user.linkedinId),
        //            Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileVerticalJob, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            jobListResponse = JsonConvert.DeserializeObject<JobList>(responseString);

        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(jobListResponse.verticalJobList))
        //        {
        //            jobListResponse.VerticalJobDetailsList = JsonConvert.DeserializeObject<List<JobDetailsList>>(jobListResponse.verticalJobList);

        //            foreach (JobDetailsList jobDetails in jobListResponse.VerticalJobDetailsList)
        //            {
        //                jobDetails.totalCount = jobListResponse.totalCount;
        //                long dateMilliseconds = jobDetails.date;
        //                DateTime startTime = new DateTime(1970, 1, 1);

        //                TimeSpan time = TimeSpan.FromMilliseconds(dateMilliseconds);
        //                DateTime dateTime = startTime.Add(time);

        //                string DateString = dateTime.ToString();

        //                string[] SplDate = DateString.Split(' ');

        //                //DateTime dt = DateTime.ParseExact(SplDate[0], "M/d/yyyy", CultureInfo.InvariantCulture);
        //                DateTime dt = DateTime.Parse(SplDate[0]);

        //                jobDetails.dateFromMillisceonds = SplDate[0];

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobListResponse;
        //}

        //public async Task<ResetPassword> resetPassword(ExtendedUser user)
        //{
        //    ResetPassword resetPassword = null;

        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileResetPassword,
        //            user.username, user.password,
        //            user.updatedPassword), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.resetPassword, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();

        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //        {
        //            resetPassword = JsonConvert.DeserializeObject<ResetPassword>(responseString);
        //        }

        //        //additional checks if the login was successful
        //        //return LoginResponse
        //        //else return null.
        //        if (!string.IsNullOrEmpty(responseString) && resetPassword.code.Equals("1000"))
        //        {
        //            return resetPassword;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return null;
        //}

        //public async Task<ForgotPassword> forgotPassword(string email)
        //{
        //    ForgotPassword forgotResponse = null;

        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileForgotPassword, email), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.forgotPassword, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();

        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //        {
        //            forgotResponse = JsonConvert.DeserializeObject<ForgotPassword>(responseString);
        //        }

        //        //if (!string.IsNullOrEmpty(responseString) && forgotResponse.code.Equals("1000"))
        //        //{
        //        //    return forgotResponse;
        //        //}

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return forgotResponse;
        //}

        public async Task<ItemVerticals> mobileItemVerticalList(User user)
        {
            ItemVerticals itemListResponse = null;
            try
            {
                HttpContent content = new StringContent(String.Format(RequestConstants.mobileItemList, user.username, user.password, "", user.itemName),
                    Encoding.UTF8, "application/x-www-form-urlencoded");
                //response from API
                var response = await client.PostAsync(APIConstants.mobileItemList, content);
                //data from response  in string format
                var responseString = await response.Content.ReadAsStringAsync();
                //Convert to Joblist object
                if (!string.IsNullOrEmpty(responseString))
                    itemListResponse = JsonConvert.DeserializeObject<ItemVerticals>(responseString);

                Console.WriteLine("");
                //convert jobDetails list from string format to object
                if (!string.IsNullOrEmpty(itemListResponse.itemList))
                {
                    itemListResponse.itemVerticals = JsonConvert.DeserializeObject<List<ItemVerticalList>>(itemListResponse.itemList);// convert string to list
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemListResponse;
        }

        //public async Task<ItemRoles> mobileItemRoleList(ExtendedUser user)
        //{
        //    ItemRoles itemListResponse = null;
        //    try
        //    {
        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileItemList, user.username, user.password, user.linkedinId, user.itemName),
        //            Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileItemList, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            itemListResponse = JsonConvert.DeserializeObject<ItemRoles>(responseString);

        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(itemListResponse.itemList))
        //        {
        //            itemListResponse.itemRoles = JsonConvert.DeserializeObject<List<ItemRolesList>>(itemListResponse.itemList);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return itemListResponse;
        //}

        //public async Task<ItemHorizontals> mobileItemHorizontalList(ExtendedUser user)
        //{
        //    ItemHorizontals itemListResponse = null;
        //    try
        //    {
        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileItemList, user.username, user.password, user.linkedinId, user.itemName),
        //            Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileItemList, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            itemListResponse = JsonConvert.DeserializeObject<ItemHorizontals>(responseString);

        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(itemListResponse.itemList))
        //        {
        //            itemListResponse.itemHorizontals = JsonConvert.DeserializeObject<List<ItemHorizontalsList>>(itemListResponse.itemList);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return itemListResponse;
        //}

        //public async Task<ItemLocations> mobileItemLocationList(ExtendedUser user)
        //{
        //    ItemLocations itemListResponse = null;
        //    try
        //    {
        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileItemList, user.username, user.password, user.linkedinId, user.itemName),
        //            Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileItemList, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            itemListResponse = JsonConvert.DeserializeObject<ItemLocations>(responseString);

        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(itemListResponse.itemList))
        //        {
        //            itemListResponse.itemLocations = JsonConvert.DeserializeObject<List<ItemLocationsList>>(itemListResponse.itemList);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return itemListResponse;
        //}

        //public async Task<JobList> mobileHorizontalJob(ExtendedUser user)
        //{
        //    JobList jobListResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileHorizontalJob, user.username, user.password, user.horizontalId, user.linkedinId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileHorizontalJob, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            jobListResponse = JsonConvert.DeserializeObject<JobList>(responseString);

        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(jobListResponse.verticalJobList))
        //        {
        //            jobListResponse.VerticalJobDetailsList = JsonConvert.DeserializeObject<List<JobDetailsList>>(jobListResponse.verticalJobList);

        //            foreach (JobDetailsList jobDetails in jobListResponse.VerticalJobDetailsList)
        //            {
        //                long dateMilliseconds = jobDetails.date;
        //                DateTime startTime = new DateTime(1970, 1, 1);

        //                TimeSpan time = TimeSpan.FromMilliseconds(dateMilliseconds);
        //                DateTime dateTime = startTime.Add(time);
        //                string DateString = dateTime.ToString();

        //                string[] SplDate = DateString.Split(' ');
        //                jobDetails.dateFromMillisceonds = SplDate[0];

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobListResponse;
        //}

        //public async Task<JobList> mobileRolesJob(ExtendedUser user)
        //{
        //    JobList jobListResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileRoleJob, user.username, user.password, user.roleId, user.linkedinId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileRoleJob, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            jobListResponse = JsonConvert.DeserializeObject<JobList>(responseString);

        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(jobListResponse.verticalJobList))
        //        {
        //            jobListResponse.VerticalJobDetailsList = JsonConvert.DeserializeObject<List<JobDetailsList>>(jobListResponse.verticalJobList);

        //            foreach (JobDetailsList jobDetails in jobListResponse.VerticalJobDetailsList)
        //            {
        //                long dateMilliseconds = jobDetails.date;
        //                DateTime startTime = new DateTime(1970, 1, 1);

        //                TimeSpan time = TimeSpan.FromMilliseconds(dateMilliseconds);
        //                DateTime dateTime = startTime.Add(time);
        //                string DateString = dateTime.ToString();

        //                string[] SplDate = DateString.Split(' ');
        //                jobDetails.dateFromMillisceonds = SplDate[0];

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobListResponse;
        //}

        //public async Task<LocationList> mobileLocationJob(ExtendedUser user)
        //{
        //    LocationList jobListResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileLocationJob,
        //             user.username,
        //             user.password,
        //             user.stateId,
        //             user.linkedinId), Encoding.UTF8, "application/x-www-form-urlencoded");

        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileLocationJob, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            jobListResponse = JsonConvert.DeserializeObject<LocationList>(responseString);

        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(jobListResponse.JobList))
        //        {
        //            jobListResponse.VerticalJobDetailsList = JsonConvert.DeserializeObject<List<JobDetailsList>>(jobListResponse.JobList);

        //            foreach (JobDetailsList jobDetails in jobListResponse.VerticalJobDetailsList)
        //            {
        //                long dateMilliseconds = jobDetails.date;
        //                DateTime startTime = new DateTime(1970, 1, 1);

        //                TimeSpan time = TimeSpan.FromMilliseconds(dateMilliseconds);
        //                DateTime dateTime = startTime.Add(time);
        //                string DateString = dateTime.ToString();

        //                string[] SplDate = DateString.Split(' ');
        //                jobDetails.dateFromMillisceonds = SplDate[0];

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobListResponse;
        //}

        //public async Task<JobList> mobileLoadMoreVerticalJob(ExtendedUser user)
        //{
        //    JobList jobListResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileLoadMoreVerticalJob, user.username, user.password, user.linkedinId, user.varticalId, user.existingJobId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileLoadMoreVerticalJob, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            jobListResponse = JsonConvert.DeserializeObject<JobList>(responseString);

        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(jobListResponse.verticalJobList))
        //        {
        //            jobListResponse.VerticalJobDetailsList = JsonConvert.DeserializeObject<List<JobDetailsList>>(jobListResponse.verticalJobList);

        //            foreach (JobDetailsList jobDetails in jobListResponse.VerticalJobDetailsList)
        //            {
        //                long dateMilliseconds = jobDetails.date;
        //                DateTime startTime = new DateTime(1970, 1, 1);

        //                TimeSpan time = TimeSpan.FromMilliseconds(dateMilliseconds);
        //                DateTime dateTime = startTime.Add(time);
        //                string DateString = dateTime.ToString();

        //                string[] SplDate = DateString.Split(' ');
        //                jobDetails.dateFromMillisceonds = SplDate[0];

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobListResponse;
        //}

        //public async Task<JobList> mobileLoadMoreHorizontalJob(ExtendedUser user)
        //{
        //    JobList jobListResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileLoadMoreHorizontalJob, user.username, user.password, user.linkedinId, user.horizontalId, user.existingJobId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileLoadMoreHorizontalJob, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            jobListResponse = JsonConvert.DeserializeObject<JobList>(responseString);

        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(jobListResponse.verticalJobList))
        //        {
        //            jobListResponse.VerticalJobDetailsList = JsonConvert.DeserializeObject<List<JobDetailsList>>(jobListResponse.verticalJobList);

        //            foreach (JobDetailsList jobDetails in jobListResponse.VerticalJobDetailsList)
        //            {
        //                long dateMilliseconds = jobDetails.date;
        //                DateTime startTime = new DateTime(1970, 1, 1);

        //                TimeSpan time = TimeSpan.FromMilliseconds(dateMilliseconds);
        //                DateTime dateTime = startTime.Add(time);
        //                string DateString = dateTime.ToString();

        //                string[] SplDate = DateString.Split(' ');
        //                jobDetails.dateFromMillisceonds = SplDate[0];

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobListResponse;
        //}

        //public async Task<JobList> mobileLoadMoreRoleJob(ExtendedUser user)
        //{
        //    JobList jobListResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileLoadMoreRoleJob, user.username, user.password, user.linkedinId, user.roleId, user.existingJobId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileLoadMoreRoleJob, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            jobListResponse = JsonConvert.DeserializeObject<JobList>(responseString);

        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(jobListResponse.verticalJobList))
        //        {
        //            jobListResponse.VerticalJobDetailsList = JsonConvert.DeserializeObject<List<JobDetailsList>>(jobListResponse.verticalJobList);

        //            foreach (JobDetailsList jobDetails in jobListResponse.VerticalJobDetailsList)
        //            {
        //                long dateMilliseconds = jobDetails.date;
        //                DateTime startTime = new DateTime(1970, 1, 1);

        //                TimeSpan time = TimeSpan.FromMilliseconds(dateMilliseconds);
        //                DateTime dateTime = startTime.Add(time);
        //                string DateString = dateTime.ToString();

        //                string[] SplDate = DateString.Split(' ');
        //                jobDetails.dateFromMillisceonds = SplDate[0];

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobListResponse;
        //}

        //public async Task<JobList> mobileLoadMoreLocationJob(ExtendedUser user)
        //{
        //    JobList jobListResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileLoadMoreLocationWiseJob, user.username, user.password, user.linkedinId, user.stateId, user.cityId, user.existingJobId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileLoadMoreLocationWiseJob, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            jobListResponse = JsonConvert.DeserializeObject<JobList>(responseString);

        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(jobListResponse.verticalJobList))
        //        {
        //            jobListResponse.VerticalJobDetailsList = JsonConvert.DeserializeObject<List<JobDetailsList>>(jobListResponse.verticalJobList);

        //            foreach (JobDetailsList jobDetails in jobListResponse.VerticalJobDetailsList)
        //            {
        //                long dateMilliseconds = jobDetails.date;
        //                DateTime startTime = new DateTime(1970, 1, 1);

        //                TimeSpan time = TimeSpan.FromMilliseconds(dateMilliseconds);
        //                DateTime dateTime = startTime.Add(time);
        //                string DateString = dateTime.ToString();

        //                string[] SplDate = DateString.Split(' ');
        //                jobDetails.dateFromMillisceonds = SplDate[0];

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobListResponse;
        //}

        //public async Task<AppliedJob> mobileSaveJob(BaseUser user)
        //{
        //    AppliedJob savedResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileSaveUserJob,
        //            user.username, user.password, user.linkedinId, user.jobId),
        //            Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileSaveUserJob, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            savedResponse = JsonConvert.DeserializeObject<AppliedJob>(responseString);

        //        //convert jobDetails list from string format to object
        //        //if (!string.IsNullOrEmpty(jobListResponse.verticalJobList))
        //        //{
        //        //    jobListResponse.VerticalJobDetailsList = JsonConvert.DeserializeObject<List<JobDetails>>(jobListResponse.verticalJobList);
        //        //}

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return savedResponse;
        //}

        //public async Task<AppliedJob> mobileApplyJob(ExtendedUser user)
        //{
        //    AppliedJob jobListResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileSaveAppliedJob, user.username, user.password, user.linkedinId, user.jobId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileSaveAppliedJob, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            jobListResponse = JsonConvert.DeserializeObject<AppliedJob>(responseString);

        //        //convert jobDetails list from string format to object
        //        //if (!string.IsNullOrEmpty(jobListResponse.verticalJobList))
        //        //{
        //        //    jobListResponse.VerticalJobDetailsList = JsonConvert.DeserializeObject<List<JobDetails>>(jobListResponse.verticalJobList);


        //        //}

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobListResponse;
        //}

        //public async Task<JobList> mobileSaveInterestedJob(BaseUser user)
        //{
        //    JobList jobListResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileSaveInterestedJob, user.username, user.password, user.linkedinId, user.jobId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileSaveInterestedJob, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        //if (!string.IsNullOrEmpty(responseString))
        //        //    jobListResponse = JsonConvert.DeserializeObject<JobList>(responseString);

        //        //convert jobDetails list from string format to object
        //        //if (!string.IsNullOrEmpty(jobListResponse.verticalJobList))
        //        //{
        //        //    jobListResponse.VerticalJobDetailsList = JsonConvert.DeserializeObject<List<JobDetails>>(jobListResponse.verticalJobList);


        //        //}

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobListResponse;
        //}

        //public async Task<JobList> mobileReferFriend(ExtendedUser user)
        //{
        //    JobList jobListResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileReferedJob, user.username, user.password, user.linkedinId, user.email, user.jobId, user.name, user.linkedinIdOfFriend, user.mobile), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileReferedJob, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        //if (!string.IsNullOrEmpty(responseString))
        //        //    jobListResponse = JsonConvert.DeserializeObject<JobList>(responseString);

        //        //convert jobDetails list from string format to object
        //        //if (!string.IsNullOrEmpty(jobListResponse.verticalJobList))
        //        //{
        //        //    jobListResponse.VerticalJobDetailsList = JsonConvert.DeserializeObject<List<JobDetails>>(jobListResponse.verticalJobList);
        //        //}

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobListResponse;
        //}

        //public async Task<ProfileDetails> mobileProfileDetails(BaseUser user)
        //{
        //    //JobList jobListResponse = null;
        //    ProfileDetails profileDetailsResponse = null;

        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileGetUserModelDetails,
        //            user.username, user.password,
        //            user.linkedinId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileGetUserModelDetails, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();

        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //        {
        //            profileDetailsResponse = JsonConvert.DeserializeObject<ProfileDetails>(responseString);
        //            //profileDetailsResponse.userModelDetails = JsonConvert.DeserializeObject<UserDetails>(profileDetailsResponse.usermodelDetails);
        //        }

        //        //additional checks if the login was successful
        //        //return LoginResponse
        //        //else return null.
        //        if (!string.IsNullOrEmpty(responseString) && profileDetailsResponse.code.Equals("1000"))
        //        {
        //            //loginResponse = JsonConvert.DeserializeObject<LoginResponseClass>(responseString);

        //            return profileDetailsResponse;
        //        }
        //        return profileDetailsResponse;
        //        //return new ProfileDetails();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        //public async Task<JobDetailsList> mobileVerticalJobDescription(ExtendedUser user)
        //{
        //    JobDetailsList jobDetailsListResponse = null;

        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileVerticalJobDescription,
        //            user.username, user.password,
        //            user.linkedinId,
        //            user.varticalId,
        //            user.jobId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileVerticalJobDescription, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            jobDetailsListResponse = JsonConvert.DeserializeObject<JobDetailsList>(responseString);

        //        List<string> stateList = null;
        //        if (!string.IsNullOrEmpty(jobDetailsListResponse.cityStateList))
        //        {
        //            var st = JsonConvert.DeserializeObject<List<StateList>>(jobDetailsListResponse.cityStateList);
        //            stateList = st.Select(x => x.state).ToList();
        //        }

        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(jobDetailsListResponse.VerticalJobDetails))
        //        {
        //            jobDetailsListResponse = JsonConvert.DeserializeObject<JobDetailsList>(jobDetailsListResponse.VerticalJobDetails);
        //        }

        //        if (stateList != null)
        //            jobDetailsListResponse.cityStateList = String.Join(", ", stateList);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobDetailsListResponse;
        //}

        //public async Task<JobDetailsList> mobileRoleJobDescription(ExtendedUser user)
        //{
        //    JobDetailsList jobDetailsListResponse = null;

        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileRoleJobDescription,
        //            user.username, user.password,
        //            user.linkedinId,
        //            user.roleId,
        //            user.jobId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileRolesJobDescription, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            jobDetailsListResponse = JsonConvert.DeserializeObject<JobDetailsList>(responseString);

        //        List<string> stateList = null;
        //        if (!string.IsNullOrEmpty(jobDetailsListResponse.cityStateList))
        //        {
        //            var st = JsonConvert.DeserializeObject<List<StateList>>(jobDetailsListResponse.cityStateList);
        //            stateList = st.Select(x => x.state).ToList();

        //        }
        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(jobDetailsListResponse.roleJobDetails))
        //        {
        //            jobDetailsListResponse = JsonConvert.DeserializeObject<JobDetailsList>(jobDetailsListResponse.roleJobDetails);
        //        }
        //        if (stateList != null)
        //            jobDetailsListResponse.cityStateList = String.Join(", ", stateList);
        //                //string.Join(",", stateList);


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobDetailsListResponse;
        //}

        //public async Task<JobDetailsList> mobileHorizontalJobDescription(ExtendedUser user)
        //{
        //    JobDetailsList jobDetailsListResponse = null;

        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileHorizontalJobDescription,
        //            user.username, user.password,
        //            user.linkedinId,
        //            user.horizontalId,
        //            user.jobId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileHorizontalJobDescription, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            jobDetailsListResponse = JsonConvert.DeserializeObject<JobDetailsList>(responseString);

        //        List<string> stateList = null;
        //        if (!string.IsNullOrEmpty(jobDetailsListResponse.cityStateList))
        //        {
        //            var st = JsonConvert.DeserializeObject<List<StateList>>(jobDetailsListResponse.cityStateList);
        //            stateList = st.Select(x => x.state).ToList();
        //        }

        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(jobDetailsListResponse.HorizontalJobDetails))
        //        {
        //            jobDetailsListResponse = JsonConvert.DeserializeObject<JobDetailsList>(jobDetailsListResponse.HorizontalJobDetails);
        //        }

        //        if (stateList != null)
        //            jobDetailsListResponse.cityStateList = String.Join(", ", stateList);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobDetailsListResponse;
        //}

        //public async Task<SavedJobDetails> mobileSavedJobDescription(ExtendedUser user)
        //{
        //    SavedJobDetails jobDetailsListResponse = null;

        //    try
        //    {
        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileSaveAppliedJobDescription,
        //            user.username, user.password,
        //            user.linkedinId,
        //            user.jobId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileSaveAppliedJobDescription, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();

        //        if (!string.IsNullOrEmpty(responseString))
        //            jobDetailsListResponse = JsonConvert.DeserializeObject<SavedJobDetails>(responseString);

        //        List<string> stateList = null;
        //        if (!string.IsNullOrEmpty(jobDetailsListResponse.cityStateList))
        //        {
        //            var st = JsonConvert.DeserializeObject<List<SavedStateList>>(jobDetailsListResponse.cityStateList);
        //            stateList = st.Select(x => x.state).ToList();
        //        }

        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(jobDetailsListResponse.JobDetailList))
        //        {
        //            jobDetailsListResponse = JsonConvert.DeserializeObject<SavedJobDetails>(jobDetailsListResponse.JobDetailList);
        //        }
                
        //        if (stateList != null)
        //            jobDetailsListResponse.cityStateList = String.Join(", ", stateList);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobDetailsListResponse;
        //}

        //public async Task<AppliedJobDetails> mobileAppliedJobDescription(ExtendedUser user)
        //{
        //    AppliedJobDetails jobDetailsListResponse = null;

        //    try
        //    {
        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileSaveAppliedJobDescription,
        //            user.username, user.password,
        //            user.linkedinId,
        //            user.jobId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileSaveAppliedJobDescription, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();

        //        if (!string.IsNullOrEmpty(responseString))
        //            jobDetailsListResponse = JsonConvert.DeserializeObject<AppliedJobDetails>(responseString);

        //        List<string> stateList = null;
        //        if (!string.IsNullOrEmpty(jobDetailsListResponse.cityStateList))
        //        {
        //            var st = JsonConvert.DeserializeObject<List<SavedStateList>>(jobDetailsListResponse.cityStateList);
        //            stateList = st.Select(x => x.state).ToList();
        //        }

        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //        {
        //            jobDetailsListResponse = JsonConvert.DeserializeObject<AppliedJobDetails>(jobDetailsListResponse.JobDetailList);
        //        }

        //        if (stateList != null)
        //            jobDetailsListResponse.cityStateList = String.Join(", ", stateList);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobDetailsListResponse;
        //}


        //public async Task<SavedJobList> mobileSavedJobList(BaseUser user)
        //{
        //    SavedJobList jobListResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileSavedJob,
        //            user.username, user.password,
        //            user.linkedinId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileSavedJob, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();

        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            jobListResponse = JsonConvert.DeserializeObject<SavedJobList>(responseString);

        //        ////convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(jobListResponse.savedJobList))
        //        {
        //            jobListResponse.savedJobListItem = JsonConvert.DeserializeObject<List<SavedJobListItem>>
        //                (jobListResponse.savedJobList);

        //            foreach (SavedJobListItem jobDetails in jobListResponse.savedJobListItem)
        //            {
        //                long dateMilliseconds = jobDetails.date;
        //                DateTime startTime = new DateTime(1970, 1, 1);

        //                TimeSpan time = TimeSpan.FromMilliseconds(dateMilliseconds);
        //                DateTime dateTime = startTime.Add(time);

        //                string DateString = dateTime.ToString();

        //                string[] SplDate = DateString.Split(' ');

        //                //DateTime dt = DateTime.ParseExact(SplDate[0], "M/d/yyyy", CultureInfo.InvariantCulture);
        //                DateTime dt = DateTime.Parse(SplDate[0]);

        //                jobDetails.dateFromMillisceonds = SplDate[0];

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobListResponse;
        //}

        //public async Task<AppliedJobList> mobileAppliedJobList(BaseUser user)
        //{
        //    AppliedJobList jobListResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileAppliedJob,
        //            user.username, user.password,
        //            user.linkedinId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileAppliedJob, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            jobListResponse = JsonConvert.DeserializeObject<AppliedJobList>(responseString);

        //        //convert jobDetails list from string format to object
        //        if (!string.IsNullOrEmpty(jobListResponse.appliedJobList))
        //        {
        //            jobListResponse.appliedJobListItem = JsonConvert.DeserializeObject<List<AppliedJobListItem>>(jobListResponse.appliedJobList);

        //            foreach (AppliedJobListItem jobDetails in jobListResponse.appliedJobListItem)
        //            {
        //                long dateMilliseconds = jobDetails.date;
        //                DateTime startTime = new DateTime(1970, 1, 1);

        //                TimeSpan time = TimeSpan.FromMilliseconds(dateMilliseconds);
        //                DateTime dateTime = startTime.Add(time);

        //                string DateString = dateTime.ToString();

        //                string[] SplDate = DateString.Split(' ');

        //                //DateTime dt = DateTime.ParseExact(SplDate[0], "M/d/yyyy", CultureInfo.InvariantCulture);
        //                DateTime dt = DateTime.Parse(SplDate[0]);

        //                jobDetails.dateFromMillisceonds = SplDate[0];

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return jobListResponse;
        //}

        //public async Task<ResumeList> mobileResumeList(BaseUser user)
        //{
        //    ResumeList resumeListResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileResumeList,
        //            user.username, user.password,
        //            user.linkedinId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileResumeList, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();

        //        if (!string.IsNullOrEmpty(responseString))
        //            resumeListResponse = JsonConvert.DeserializeObject<ResumeList>(responseString);

        //        if (!string.IsNullOrEmpty(resumeListResponse.ResumeName))
        //        {
        //            string[] resumeName = resumeListResponse.ResumeName.Split(new[] { "#@" }, StringSplitOptions.None);

        //            List<ResumeNameDetailList> resumeNameDetailList = new List<ResumeNameDetailList>();

        //            foreach (string resumeNameString in resumeName)
        //            {
        //                ResumeNameDetailList obj = new ResumeNameDetailList();
        //                if (resumeNameString != "")
        //                {
        //                    obj.resumeName = resumeNameString;
        //                    resumeNameDetailList.Add(obj);
        //                }

        //            }

        //            resumeListResponse.ResumeNameDetailList = resumeNameDetailList;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return resumeListResponse;
        //}

        //public async Task<VideoList> mobileVideoList(BaseUser user)
        //{
        //    VideoList videoListResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileVideoList,
        //            user.username, user.password,
        //            user.linkedinId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.mobileVideoList, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();

        //        if (!string.IsNullOrEmpty(responseString))
        //            videoListResponse = JsonConvert.DeserializeObject<VideoList>(responseString);

        //        if (!string.IsNullOrEmpty(videoListResponse.videoName))
        //        {
        //            string[] videoName = videoListResponse.videoName.Split(new[] { "#@" }, StringSplitOptions.None);

        //            List<VideoDetailList> videoNameDetailList = new List<VideoDetailList>();

        //            foreach (string videoNameString in videoName)
        //            {
        //                VideoDetailList obj = new VideoDetailList();
        //                if (videoNameString != "")
        //                {
        //                    obj.videoName = videoNameString;
        //                    videoNameDetailList.Add(obj);
        //                }

        //            }

        //            videoListResponse.VideoDetailList = videoNameDetailList;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return videoListResponse;
        //}

        //public async Task<LogoutModel> logout(BaseUser user)
        //{
        //    LogoutModel logoutResponse = null;
        //    try
        //    {

        //        HttpContent content = new StringContent(String.Format(RequestConstants.mobileLogout,
        //            user.username, user.password,
        //            user.linkedinId), Encoding.UTF8, "application/x-www-form-urlencoded");
        //        //response from API
        //        var response = await client.PostAsync(APIConstants.logout, content);
        //        //data from response  in string format
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        //Convert to Joblist object
        //        if (!string.IsNullOrEmpty(responseString))
        //            logoutResponse = JsonConvert.DeserializeObject<LogoutModel>(responseString);

        //        //convert jobDetails list from string format to object
        //        //if (logoutResponse.code.Equals("1000"))
        //        //{
        //        //    //await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        //        //    ////await App.Current.MainPage.Navigation.PopModalAsync();

        //        //}

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return logoutResponse;
        //}

        //public async Task<DeleteModel> deleteAccount(BaseUser user)
        //{
            //DeleteModel deleteResponse = null;
            //try
            //{

            //    HttpContent content = new StringContent(String.Format(RequestConstants.mobileDeleteAccount,
            //        user.username, user.password), Encoding.UTF8, "application/x-www-form-urlencoded");
            //    //response from API
            //    var response = await client.PostAsync(APIConstants.deleteAccount, content);
            //    //data from response  in string format
            //    var responseString = await response.Content.ReadAsStringAsync();
            //    //Convert to Joblist object
            //    if (!string.IsNullOrEmpty(responseString))
            //        deleteResponse = JsonConvert.DeserializeObject<DeleteModel>(responseString);

            //    //convert jobDetails list from string format to object
            //    if (deleteResponse.code.Equals("1000"))
            //    {
            //        MessagingCenter.Send(new MessagingCenterAlert
            //        {
            //            Title = "Alert",
            //            Message = deleteResponse.Message, // "Unable to delete account",
            //            Cancel = "Ok"
            //        }, "Message");

            //        await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return deleteResponse;
        //}

    }
}
