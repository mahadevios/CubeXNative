using System.Threading.Tasks;
using CubeXNative.Models;
using System.Collections.Generic;

namespace CubeXNative.Services
{
    public interface IApiStore
    {
        //Task<T> mobileVerticalJob(User user);
        //Task<T> mobileHorizontalJob(User user);
        //Task<T> mobileRolesJob(User user);
        //Task<T> mobileLoadMoreVerticalJob(User user);
        //Task<T> mobileLoadMoreHorizontalJob(User user);
        //Task<T> mobileLoadMoreRoleJob(User user);
        //Task<T> mobileLoadMoreLocationJob(User user);
        //Task<T> mobileSaveJob(User user);
        //Task<T> mobileApplyJob(User user);

        //Task<T> mobileVerticalJobDescription(User user);
        //Task<T> mobileRoleJobDescription(User user);
        //Task<T> mobileHorizontalJobDescription(User user);

        //Task<T> mobileResumeList(User user);
        //Task<T> mobileVideoList(User user);
        Task<Login> login(User user);
        //Task<T> mobileProfileDetails(User user);
        Task<ItemVerticals> mobileItemVerticalList(User user);
        //Task<T> mobileItemRoleList(User user);
        //Task<T> mobileItemHorizontalList(User user);
        //Task<T> mobileItemLocationList(User user);
        //Task<T> mobileLocationJob(User user);
        //Task<T> resetPassword(User user);
        
    }
}
