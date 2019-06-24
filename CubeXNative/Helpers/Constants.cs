using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CubeXNative.Helpers
{
    public static class APIConstants
    {
        public static string BaseUrl = "https://investhr.biz/investhr/";
        //public static string BaseUrl = "http://192.168.3.66:8080/coreflex/investhr/login/";
        public static string registration = "registration";
        public static string login = "login";

        public static string mobileItemList = "login/mobileItemList";


        //public static string mobileVerticalJob = "mobileVerticalJob";
        //public static string mobileHorizontalJob = "mobileHorizontalJob";
        //public static string mobileLocationJob = "mobileLocationWiseJob";
        //public static string mobileRoleJob = "mobileRoleJob";
        //public static string mobileAppliedJob = "mobileAppliedJob";
        //public static string mobileSavedJob = "mobileSavedJob";

        //public static string mobileVerticalJobDescription = "mobileVerticalJobDescription";
        //public static string mobileRolesJobDescription = "mobileRoleJobDescription";
        //public static string mobileHorizontalJobDescription = "mobileHorizontalJobDescription";

        //public static string mobileSaveAppliedJob = "mobileSaveAppliedJob";
        //public static string mobileSaveUserJob = "mobileSaveUserJob";
        //public static string mobileSaveAppliedJobDescription = "mobileSaveAppliedJobDescription";
        //public static string mobileLoadMoreVerticalJob = "mobileLoadMoreVerticalJob";
        //public static string mobileLoadMoreHorizontalJob = "mobileLoadMoreHorizontalJob";
        //public static string mobileLoadMoreRoleJob = "mobileLoadMoreRoleJob";
        //public static string mobileLoadMoreLocationWiseJob = "mobileLoadMoreLocationWiseJob";

        //public static string mobileGetUserModelDetails = "mobileGetUserModelDetails";
        //public static string mobileSaveInterestedJob = "mobilSaveInterestedJob";
        //public static string mobileUploadVideo = "mobileUploadVideo";
        //public static string mobilUploadResume = "mobilUploadResume";
        //public static string mobileResumeList = "mobileResumeList";
        //public static string mobileVideoList = "mobileVideoList";
        //public static string mobileEditProfile = "mobileEditProfile";
        //public static string mobileDeleteVideo = "mobileDeleteVideo";
        //public static string mobileDeleteResume = "mobileDeleteResume";
        //public static string mobileGetNotificationMessageDetails = "mobileGetNotificationMessageDetails";
        //public static string updateDeviceToken = "updateDeviceToken";// for ios only
        //public static string forgotPassword = "forgotPassword";
        //public static string resetPassword = "resetpassword";
        //public static string logout = "logout";
        //public static string deleteAccount = "deleteAccount";
        //public static string mobileReferedJob = "mobileReferedJob";
        //public static string mobileCloseJob = "mobileCloseJob";

        public static string linkedInLogout = "https://api.linkedin.com/uas/oauth/invalidateToken";
        public static string linkedInAccessTokenEndPoint = "https://www.linkedin.com/uas/oauth2/accessToken";

    }
    public static class RequestConstants
    {
        public static string mobileVerticalJob = "username={0}&password={1}&varticalId={2}&linkedinId={3}";
        public static string mobileItemList = "username={0}&password={1}&linkedinId={2}&itemName={3}";
        public static string mobileHorizontalJob = "username={0}&password={1}&horizontalId={2}&linkedinId={3}";
        public static string mobileRoleJob = "username={0}&password={1}&roleId={2}&linkedinId={3}";
        public static string mobileLocationJob = "username={0}&password={1}&stateId={2}&linkedinId={3}";
        public static string mobileSavedJob = "username={0}&password={1}&linkedinId={2}";
        public static string mobileAppliedJob = "username={0}&password={1}&linkedinId={2}";
        public static string mobileSaveAppliedJob = "username={0}&password={1}&linkedinId={2}&jobId={3}";
        public static string mobileSaveUserJob = "username={0}&password={1}&linkedinId={2}&jobId={3}";
        public static string mobileSaveAppliedJobDescription = "username={0}&password={1}&linkedinId={2}&jobId={3}";

        public static string mobileVerticalJobDescription = "username={0}&password={1}&linkedinId={2}&varticalId={3}&jobId={4}";
        public static string mobileRoleJobDescription = "username={0}&password={1}&linkedinId={2}&roleId={3}&jobId={4}";
        public static string mobileHorizontalJobDescription = "username={0}&password={1}&linkedinId={2}&horizontalId={3}&jobId={4}";

        public static string mobileLoadMoreVerticalJob = "username={0}&password={1}&linkedinId={2}&varticalId={3}&existingJobId={4}";
        public static string mobileLoadMoreHorizontalJob = "username={0}&password={1}&linkedinId={2}&horizontalId={3}&existingJobId={4}";
        public static string mobileLoadMoreRoleJob = "username={0}&password={1}&linkedinId={2}&roleId={3}&existingJobId={4}";
        public static string mobileLoadMoreLocationWiseJob = "username={0}&password={1}&linkedinId={2}&stateId={3}&cityId={4}&existingJobId={5}";
        public static string mobileGetUserModelDetails = "username={0}&password={1}&linkedinId={2}";
        public static string mobileSaveInterestedJob = "username={0}&password={1}&linkedinId={2}&jobId={3}";
        public static string mobileUploadVideo = "username={0}&password={1}&roleId={2}&linkedinId={3}&videoName={4}";
        public static string mobilUploadResume = "username={0}&password={1}&roleId={2}&linkedinId={3}&resumeName={4}";
        public static string mobileResumeList = "username={0}&password={1}&linkedinId={2}";
        public static string mobileVideoList = "username={0}&password={1}&linkedinId={2}";
        public static string mobileEditProfile = "registrationDict={0}";
        public static string mobileDeleteVideo = "username={0}&password={1}&linkedinId={2}&videoName={3}";
        public static string mobileDeleteResume = "username={0}&password={1}&linkedinId={2}&resumeName={3}";
        public static string mobileGetNotificationMessageDetails = "username={0}&password={1}&linkedinId={2}";
        public static string mobileUpdateDeviceToken = "username={0}&password={1}&linkedinId={2}&deviceToken={3}";// for ios only
        public static string mobileForgotPassword = "email={0}";
        public static string mobileResetPassword = "username={0}&password={1}&updatedPassword={2}";
        public static string mobileLogout = "username={0}&password={1}&linkedinId={2}";
        public static string mobileDeleteAccount = "username={0}&password={1}";
        public static string mobileReferedJob = "username={0}&password={1}&r&linkedinId={2}&email={3}&jobId={4}&name={5}&linkedInIdOfFriend={6}&mobile={7}";
        public static string mobileCloseJob = "username={0}&password={1}&linkedinId={2}";
        public static string mobileRegistration = "registrationDict={0}";
        public static string mobileLogin = "username={0}&password={1}&deviceToken={2}";
        
    }   
}
