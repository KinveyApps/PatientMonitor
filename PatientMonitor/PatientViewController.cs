using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kinvey;
using CoreGraphics;
using UIKit;

namespace PatientMonitor
{
	public partial class PatientViewController : UIViewController
	{
		internal UITextField SenderIDView;
		internal UILabel MessageView;
		nfloat h = 31.0f;
		UIColor colorBackgroundButtonLogin = UIColor.FromRGB(5, 58, 114);
		//UIColor colorBackgroundButtonLogin = UIColor.FromRGB(92, 127, 159);
		UIColor colorDarkBlue = UIColor.FromRGB(7, 69, 126);
		UIColor colorLightBlue = UIColor.FromRGB(92, 127, 159);

		internal User Patient { get; set; }

		// REALTIME REGISTRATION
		int settingValue = 70;

		Stream<MedicalDeviceStatus> streamStatus;
		//Stream<MedicalDeviceCommand> streamCommand;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			SetupStreams();
		}

		public async Task SetupStreams()
		{
			//streamCommand = new Stream<MedicalDeviceCommand>("device_command");
			streamStatus = new Stream<MedicalDeviceStatus>("device_status");
			await GrantAccess();
			//await Subscribe();

			RenderView();

			//StartMonitor();
		}

		public async Task GrantAccess()
		{
			// Look up Patient record
			DataStore<Patient> patientStore = DataStore<Patient>.Collection("Patients", DataStoreType.NETWORK);

			var query = from patient in patientStore
						where patient.UserID == Patient.Id
						select patient;
			List<Patient> results = await patientStore.FindAsync(query);
			var activePatient = results.FirstOrDefault();

			if (activePatient != null)
			{
				// Grant permission for Bob's doctor to follow Bob (feed communication)
				var aclForBob = new StreamAccessControlList();
				aclForBob.Publishers.Add(activePatient.UserID); // Give Bob permission to publish to himself
				aclForBob.Subscribers.Add(activePatient.DoctorID); // Give Bob's doctor permission to follow his updates
				await streamStatus.GrantStreamAccess(Patient.Id, aclForBob);
			}
		}

		//public async Task Subscribe()
		//{
		//	var sender = Client.SharedClient.ActiveUser.Id;
		//	// Set up command subscribe delegate
		//	var streamDelegate = new KinveyStreamDelegate<MedicalDeviceCommand>
		//	{
		//		OnError = (err) => Console.WriteLine("STREAM Error: " + err.Message),
		//		OnNext = async (senderID, message) =>
		//		{
		//			//Console.WriteLine("STREAM SenderID: " + senderID + " -- Command: " + message.Command);
		//			if (message.Command == MedicalDeviceCommand.EnumCommand.INCREMENT)
		//			{
		//				settingValue++;
		//			}
		//			else
		//			{
		//				settingValue--;
		//			}
		//			InvokeOnMainThread(() => this.ChangeText(senderID, settingValue.ToString()));
		//			await this.PublishStatus(settingValue.ToString());
		//		},
		//		OnStatus = (status) =>
		//		{
		//			Console.WriteLine("Status: " + status.Status);
		//		}
		//	};

		//	await streamCommand.Listen(streamDelegate);

		//}

		public async Task PublishStatus(string setting)
		{
			var receiver = Patient.Id;
			var mds = new MedicalDeviceStatus();
			mds.Setting = setting;
			await streamStatus.Send(receiver, mds);
		}


		public void ChangeText(string msg)
		{
			MessageView.Text = msg;
		}

		private void RenderView()
		{
			Title = "Kinvey Live Service - Patient";
			View.BackgroundColor = UIColor.FromRGB(7, 69, 126);
			nfloat w = View.Bounds.Width;

			AppDelegate myAppDel = (UIApplication.SharedApplication.Delegate as AppDelegate);

			var titleLabel = new UILabel
			{
				Text = "My Device Reading",
				TextColor = UIColor.White,
				TextAlignment = UITextAlignment.Center,
				Frame = new CGRect(10, 80, w - 20, h)
			};

			View.AddSubview(titleLabel);

			MessageView = new UILabel
			{
				Frame = new CGRect(10, 120, w - 20, 3 * h),
				Text = this.settingValue.ToString(),
				TextColor = UIColor.White,
				Font = UIFont.FromName("Helvetica-Bold", 60f),
				TextAlignment = UITextAlignment.Center
			};

			View.AddSubview(MessageView);

			UIButton buttonLogout;
			buttonLogout = UIButton.FromType(UIButtonType.System);
			buttonLogout.Frame = new CGRect(10, 322, w - 20, 44);
			buttonLogout.SetTitle("Logout", UIControlState.Normal);
			buttonLogout.SetTitleColor(UIColor.Black, UIControlState.Normal);
			buttonLogout.BackgroundColor = UIColor.Gray;

			var user = new UIViewController();
			user.View.BackgroundColor = colorDarkBlue;

			buttonLogout.TouchUpInside += async (sender, e) =>
			{
				await myAppDel.Logout();
			};

			View.AddSubview(buttonLogout);

			Task.Run(async () => {
				var random = new Random(12345);
				while (true)
				{
					int delta = random.Next() % 5;
					int sign = random.Next() % 2;
					settingValue = sign == 0 ? settingValue + delta : settingValue - delta;
					InvokeOnMainThread(() => this.ChangeText(settingValue.ToString()));
					await this.PublishStatus(settingValue.ToString());
					await Task.Delay(1000); // sleep for 5 seconds avoiding computer overcharge
				}
			});
		}

		//public async Task StartMonitor()
		//{
		//	var random = new Random(12345);
		//	while (true)
		//	{
		//		int delta = random.Next() % 5;
		//		int sign = random.Next() % 2;
		//		settingValue = sign == 0 ? settingValue + delta : settingValue - delta;
		//		InvokeOnMainThread(() => this.ChangeText(settingValue.ToString()));
		//		//this.PublishStatus(settingValue.ToString());
		//		await Task.Delay(5000); // sleep for 5 seconds avoiding computer overcharge
		//	}
		//}

	}
}
