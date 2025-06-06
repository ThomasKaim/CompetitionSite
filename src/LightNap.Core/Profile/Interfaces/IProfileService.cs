using LightNap.Core.Api;
using LightNap.Core.Notifications.Dto.Request;
using LightNap.Core.Notifications.Dto.Response;
using LightNap.Core.Profile.Dto.Request;
using LightNap.Core.Profile.Dto.Response;

namespace LightNap.Core.Profile.Interfaces
{
    /// <summary>
    /// Service for managing the logged-in user's profile.
    /// </summary>
    public interface IProfileService
    {
        /// <summary>
        /// Retrieves the profile of the requesting user.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="ProfileDto"/> with the user's profile.</returns>
        Task<ProfileDto> GetProfileAsync();

        /// <summary>
        /// Updates the profile of the requesting user.
        /// </summary>
        /// <param name="requestDto">The data transfer object containing the profile update information.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="ProfileDto"/> with the updated profile.</returns>
        Task<ProfileDto> UpdateProfileAsync(UpdateProfileDto requestDto);

        /// <summary>
        /// Changes the password of the requesting user.
        /// </summary>
        /// <param name="requestDto">The data transfer object containing the password change information.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task ChangePasswordAsync(ChangePasswordRequestDto requestDto);

        /// <summary>
        /// Retrieves the settings of the requesting user.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="BrowserSettingsDto"/> with the user's settings.</returns>
        Task<BrowserSettingsDto> GetSettingsAsync();

        /// <summary>
        /// Updates the settings of the requesting user.
        /// </summary>
        /// <param name="requestDto">The data transfer object containing the settings update information.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateSettingsAsync(BrowserSettingsDto requestDto);

        /// <summary>  
        /// Retrieves a list of devices for the requesting user.  
        /// </summary>  
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="DeviceDto"/>.</returns>  
        Task<IList<DeviceDto>> GetDevicesAsync();

        /// <summary>  
        /// Revokes a device for the requesting user.  
        /// </summary>  
        /// <param name="deviceId">The ID of the device to be revoked.</param>  
        /// <returns>A task that represents the asynchronous operation.</returns>  
        Task RevokeDeviceAsync(string deviceId);

        /// <summary>
        /// Starts the email change process for the logged-in user.
        /// </summary>
        /// <param name="requestDto">The data transfer object containing the new email.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="UserFriendlyApiException">Thrown when the email change fails.</exception>
        Task ChangeEmailAsync(ChangeEmailRequestDto requestDto);

        /// <summary>
        /// Confirms the email change for the specified user.
        /// </summary>
        /// <param name="requestDto">The data transfer object containing the new email and the confirmation code.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="UserFriendlyApiException">Thrown when the email confirmation fails.</exception>
        Task ConfirmEmailChangeAsync(ConfirmEmailChangeRequestDto requestDto);

        /// <summary>
        /// Searches the logged-in user's notifications based on the provided criteria.
        /// </summary>
        /// <param name="requestDto">The data transfer object containing the search criteria.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="NotificationSearchResultsDto"/> with the search results.</returns>
        Task<NotificationSearchResultsDto> SearchNotificationsAsync(SearchNotificationsDto requestDto);

        /// <summary>
        /// Marks all notifications as read for the requesting user.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task MarkAllNotificationsAsReadAsync();

        /// <summary>
        /// Marks a specific notification as read for the requesting user.
        /// </summary>
        /// <param name="id">The ID of the notification to be marked as read.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task MarkNotificationAsReadAsync(int id);
    }
}