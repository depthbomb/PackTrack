#region License
/*
	PackTrack
	Copyright(C) 2020 Caprine Logic
	
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.
	
	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
	GNU General Public License for more details.
	
	You should have received a copy of the GNU General Public License
	along with this program. If not, see <https://www.gnu.org/licenses/>.
*/
#endregion License

using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.UI.Notifications;

using RestSharp;
using CaprineNet.Common.Helpers;
using CaprineNet.Common.Extensions;

using PackTrack.Models;
using PackTrack.Models.Requests;
using PackTrack.Models.Responses;

namespace PackTrack
{
	class Program
	{
		static string LastActivity;

		static string TrackingNumber;
		static RestClient Client = new RestClient("https://www.ups.com");

		static async Task Main(string[] args)
		{
			Console.Title = "PackTrack";
			ConsoleHelpers.DisableMaximize();
			ConsoleHelpers.SetFixedSize(150, 40);

			if (args.Any())
			{
				TrackingNumber = args[0].Trim();

				if (TrackingNumber.IsNullOrEmpty())
				{
					Console.Error.WriteLine("Tracking number is invalid");
					Console.ReadLine();
					Environment.Exit(0);
				}
			}
			else
			{
				if (!File.Exists("ID.xml"))
				{
					Console.WriteLine("Please enter the UPS tracking ID of the delivery you want to track.");

					GetInput:
					Console.WriteLine();
					Console.Write("Tracking ID(s): ");

					TrackingNumber = Console.ReadLine().Trim();

					if(TrackingNumber.IsNullOrEmpty())
					{
						goto GetInput;
					}

					SaveID(TrackingNumber);

					Console.WriteLine("Tracking ID has been saved! To enter a new ID delete the ID.xml in the installation folder and restart the program.");

					await Task.Delay(5000);
				}
				else
				{
					LoadID("ID.xml");
				}
			}

			await Start();
		}

		static async Task Start()
		{
			MakeRequest:

			Console.Title = "Checking status...";

			var request = new RestRequest("track/api/Track/GetStatus", DataFormat.Json);
				request.AddJsonBody(new GetStatusRequest{ TrackingNumber = new string[] { TrackingNumber } });

			var response = Client.Post(request);

			if (response.IsSuccessful)
			{
				string json = response.Content;

				var data = JsonSerializer.Deserialize<GetStatusResponse>(json);

				Console.Clear();

				var details = data.trackDetails[0];

				if(LastActivity != null && LastActivity != details.shipmentProgressActivities[0].activityScan)
				{
					ConsoleHelpers.FlashWindow(5);
					ShowToast("New Activity!", details.shipmentProgressActivities[0].activityScan);
				}

				LastActivity = details.shipmentProgressActivities[0].activityScan;

				WriteDivider();
				Console.WriteLine("Delivery #{0}", details.trackingNumber);
				WriteDivider();
				Console.WriteLine();

				Console.WriteLine("{0,-15}{1,-15}", "Delivery date:", details.scheduledDeliveryDate);
				Console.WriteLine("{0,-15}{1,-15}", "Tracked time:", data.trackedDateTime);
				Console.WriteLine("{0,-15}{1,-15}", "Status:", details.packageStatus);
				Console.WriteLine("{0,-15}{1,-15}", "Delivery:", details.scheduledDeliveryDate);
				Console.WriteLine("{0,-15}{1}{2}", "Weight:", details.additionalInformation.weight, details.additionalInformation.weightUnit);

				Console.WriteLine();

				var activities = details.shipmentProgressActivities;

				foreach(var activity in activities)
				{
					if(activity.activityScan != null)
					{
						if (activities.ToList().FindAll(a => a.activityScan != null).IndexOf(activity) == 0)
						{
							Console.ForegroundColor = ConsoleColor.White;
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.DarkGray;
						}

						Console.WriteLine(activity.activityScan);
						Console.WriteLine("{0,-10}{1} {2}", "Date:", activity.date, activity.time);
						if(activity.location != null)
						{
							Console.WriteLine("{0,-10}{1}", "Location:", activity.location);
						}

						Console.ResetColor();

						Console.WriteLine("-".Repeat(24));
					}
				}

				WriteProgressBar(details.progressBarPercentage);

				Console.WriteLine();

				Console.Title = $"PackTrack - {details.progressBarPercentage}%";
			}

			await Task.Delay(30000);

			goto MakeRequest;
		}

		#region Helpers
		static void WriteProgressBar(string progress)
		{
			int percent = int.Parse(progress);
			string bar = new string('█', percent);
			string barSpace = new string('█', 100 - percent);

			Console.WriteLine();
			Console.Write("Progress ");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(bar);
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write(barSpace);
			Console.ResetColor();
			Console.Write(" {0}%", progress);
		}

		static void WriteDivider() => Console.WriteLine("-".Repeat(Console.BufferWidth - 1));

		static void SaveID(string id)
		{
			string file = "ID.xml";
			using (var sw = new StreamWriter(file))
			using (var wr = XmlWriter.Create(sw))
			{
				var serializer = new XmlSerializer(typeof(IDModel));
				serializer.Serialize(wr, new IDModel { ID = id });
			}
		}

		static void LoadID(string path)
		{
			using (var sr = new StreamReader(path))
			{
				var serializer = new XmlSerializer(typeof(IDModel));

				TrackingNumber = (serializer.Deserialize(sr) as IDModel).ID;
			}
		}

		static void ShowToast(string title, string content)
		{
			Windows.Data.Xml.Dom.XmlDocument template;
			Windows.Data.Xml.Dom.XmlNodeList textNodes;
			Windows.Data.Xml.Dom.XmlNodeList imgNodes;

			template = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText02);
			textNodes = template.GetElementsByTagName("text");
			textNodes[0].InnerText = title;
			textNodes[1].InnerText = content;

			imgNodes = template.GetElementsByTagName("image");
			imgNodes[0].Attributes.GetNamedItem("src").NodeValue = Path.GetFullPath(@".\Assets\PackTrack.png");

			var notifier = ToastNotificationManager.CreateToastNotifier("PackTrack");
			var notification = new ToastNotification(template);

			notifier.Show(notification);
		}
		#endregion
	}
}
