﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using HuePod.Nasa;

namespace HuePod.Droid
{
	[Activity(Label = "Huepod", MainLauncher = true, Icon = "@mipmap/icon")]
	public class ApodListActivity : Activity
	{
		private List<Apod> _apods;
		private ListView _apodsListView;
		private Service _service;

		protected override async void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.apod_list_activity);

			FindViews();

			_service = new Service();

			await LoadLastPictures();

			WireEvents();
		}

		private void FindViews()
		{
			_apodsListView = FindViewById<ListView>(Resource.Id.apodsListView);
		}

		private void WireEvents()
		{
			_apodsListView.ItemClick += (sender, e) =>
			{
				var apod = _apods[e.Position];
				if (apod.MediaType == "image")
				{
					StartDetailActivity(apod.Date);
				}
				else 
				{
					StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse(apod.Url)));
				}
			};
		}

		void StartDetailActivity(DateTime date)
		{
			var i = new Intent(this, typeof(ApodDetailActivity));
			i.PutExtra("date", date.ToString());
			StartActivity(i);
		}

		private async Task LoadLastPictures()
		{
			_apods = await _service.GetLastAstronomicPictures(10);
			var adapter = new ApodListAdapter(this, _apods.ToArray());

			_apodsListView.Adapter = adapter;
		}

		public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.main_menu, menu);
			return true;
		}

		public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
		{
			if (item.ItemId == Resource.Id.open_calendar_menu)
			{
				var today = DateTime.Today;
				var picker = new DatePickerDialog(this, (s, a) =>
				{
					if (a.Date <= today)
					{
						StartDetailActivity(a.Date);
					}
					else 
					{
						var t = Toast.MakeText(this, "Oh! I can't foresee the future", ToastLength.Short);
						t.Show();
					}

				}, today.Year, today.Month, today.Day);
				picker.Show();
				return true;
			}
			return base.OnOptionsItemSelected(item);
		}
	}
}