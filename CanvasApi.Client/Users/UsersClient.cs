using System.Net.Http;
using System.Threading.Tasks;
using CanvasApi.Client._Base;
using CanvasApi.Client.Users.Models;
using CanvasApi.Client.Users.Models.Concretes;

namespace CanvasApi.Client.Users
{
    internal class UsersClient: ApiClientBase, IUsersApi
    {
        internal UsersClient(CanvasApiClient parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns user profile data, including user id, name, and profile pic.
        /// 
        /// When requesting the profile for the user accessing the API, the user's calendar feed URL and LTI user id will be returned as well.
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns><see cref="IUserProfile"/>Profile for the requested user</returns>
        public async Task<IUserProfile> GetProfile(long userId) =>
            await this.ApiClient.ApiOperation<UserProfile>(HttpMethod.Get, $"/api/v1/users/{userId}/profile");

        /// <summary>
        /// Return user profile data, includeing user id, name and profile pic.
        /// 
        /// When requesting the profile for the user accessing the API, the user's calendar feed URL and LTI user id will be returned as well.
        /// 
        /// </summary>
        /// <param name="sisUserId">The sis user identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<IUserProfile> GetProfile ( string sisUserId ) =>
            await this.ApiClient.ApiOperation<UserProfile>(HttpMethod.Get, $"/api/v1/users/sis_user_id:{sisUserId}/profile");
    }
}
