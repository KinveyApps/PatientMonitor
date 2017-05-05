using System;
using CoreGraphics;
using UIKit;

namespace PatientMonitor
{
	public partial class LoginViewController : UIViewController
	{
		public UIButton buttonLogin;
		public UIButton buttonLoginAuto;
		public UIButton buttonLoginAlice;
		public UIButton buttonLoginBob;
		public UIButton buttonLoginCharlie;
		public UIButton buttonLoginAdmin;

		UITextField usernameField;
		UITextField passwordField;
		//UIColor colorBackgroundButtonLogin = UIColor.FromRGB(5, 58, 114);
		UIColor colorBackgroundButtonLogin = UIColor.FromRGB(92, 127, 159);

		public LoginViewController()
		{
		}

		//protected MyViewController(IntPtr handle) : base(handle)
		//{
		//	// Note: this .ctor should not contain any initialization logic.
		//}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			View.BackgroundColor = UIColor.FromRGB(7, 69, 126);
			Title = "PatientMonitor - Feed Communication";

			nfloat h = 31.0f;
			nfloat w = View.Bounds.Width;

			usernameField = new UITextField
			{
				Placeholder = "Username",
				BorderStyle = UITextBorderStyle.RoundedRect,
				Frame = new CGRect(10, 82, w - 20, h)
			};
			View.AddSubview(usernameField);

			passwordField = new UITextField
			{
				SecureTextEntry = true,
				Placeholder = "Password",
				BorderStyle = UITextBorderStyle.RoundedRect,
				Frame = new CGRect(10, 122, w - 20, h)
			};
			View.AddSubview(passwordField);


			var buttonWidth = (w / 2) - 20;
			buttonLogin = UIButton.FromType(UIButtonType.System);
			buttonLogin.Frame = new CGRect(10, 162, w - 20, 44);
			buttonLogin.SetTitle("Login", UIControlState.Normal);
			buttonLogin.SetTitleColor(UIColor.White, UIControlState.Normal);
			buttonLogin.BackgroundColor = colorBackgroundButtonLogin;

			buttonLogin.TouchUpInside += async (sender, e) =>
			{
				//AppDelegate myAppDel = (UIApplication.SharedApplication.Delegate as DemoKLS.AppDelegate);
				//await myAppDel.Login(usernameField.Text, passwordField.Text);
			};

			View.AddSubview(buttonLogin);


			buttonLoginAlice = UIButton.FromType(UIButtonType.System);
			buttonLoginAlice.Frame = new CGRect(10, 250, w - 20, 44);
			buttonLoginAlice.SetTitle("Login Dr. Gregory Casa", UIControlState.Normal);
			buttonLoginAlice.SetTitleColor(UIColor.White, UIControlState.Normal);
			buttonLoginAlice.BackgroundColor = colorBackgroundButtonLogin;

			buttonLoginAlice.TouchUpInside += async (sender, e) =>
			{
				AppDelegate myAppDel = (UIApplication.SharedApplication.Delegate as AppDelegate);
				await myAppDel.LoginDrGregoryCasa();
			};

			View.AddSubview(buttonLoginAlice);

			buttonLoginBob = UIButton.FromType(UIButtonType.System);
			buttonLoginBob.Frame = new CGRect(10, 300, w - 20, 44);
			buttonLoginBob.SetTitle("Login Bob", UIControlState.Normal);
			buttonLoginBob.SetTitleColor(UIColor.White, UIControlState.Normal);
			buttonLoginBob.BackgroundColor = colorBackgroundButtonLogin;

			buttonLoginBob.TouchUpInside += async (sender, e) =>
			{
				AppDelegate myAppDel = (UIApplication.SharedApplication.Delegate as AppDelegate);
				await myAppDel.LoginBob();
			};

			View.AddSubview(buttonLoginBob);

			//buttonLoginCharlie = UIButton.FromType(UIButtonType.System);
			//buttonLoginCharlie.Frame = new CGRect(10, 350, w - 20, 44);
			//buttonLoginCharlie.SetTitle("Login Charlie", UIControlState.Normal);
			//buttonLoginCharlie.SetTitleColor(UIColor.White, UIControlState.Normal);
			//buttonLoginCharlie.BackgroundColor = colorBackgroundButtonLogin;

			//buttonLoginCharlie.TouchUpInside += async (sender, e) => {
			//	AppDelegate myAppDel = (UIApplication.SharedApplication.Delegate as DemoKLS.AppDelegate);
			//	await myAppDel.LoginCharlie();
			//};

			//View.AddSubview(buttonLoginCharlie);

			buttonLoginAdmin = UIButton.FromType(UIButtonType.System);
			buttonLoginAdmin.Frame = new CGRect(10, 400, w - 20, 44);
			buttonLoginAdmin.SetTitle("Login Admin", UIControlState.Normal);
			buttonLoginAdmin.SetTitleColor(UIColor.White, UIControlState.Normal);
			buttonLoginAdmin.BackgroundColor = colorBackgroundButtonLogin;

			buttonLoginAdmin.TouchUpInside += async (sender, e) =>
			{
				AppDelegate myAppDel = (UIApplication.SharedApplication.Delegate as AppDelegate);
				await myAppDel.LoginAdmin();
			};

			View.AddSubview(buttonLoginAdmin);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
