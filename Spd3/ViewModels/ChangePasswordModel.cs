namespace Spd3.ViewModels
{
    public class ChangePasswordViewModel
    {
		public string UserId { get; set; }
		public string OldPassword { get; set; }
		public string NewPassword { get; set; }
		public string RepeatNewPassword { get; set; }
    }
}
