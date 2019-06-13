using System.Threading.Tasks;


namespace CubeXNative
{
    public interface ISqliteDataStore<T>
    {
        //Task<T> SaveUserAsync(User user);
        Task<T> GetUserAsync();
        //Task<T> SavedJobIdAsync(User user);
        //Task<T2> AppliedJobIdAsync(DbAppliedJobs user);
        //Task<T3> MassNotificationAsync(DbMassNotification user);
        //Task<T4> NotificationAsync(DbNotification user);
        //Task<T5> VideoAsync(DbVideos user);
    }
}
