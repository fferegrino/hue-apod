// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace HuePod.iOS
{
	[Register ("ApodTableViewCell")]
	partial class ApodTableViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel apodDateLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel apodTitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView apoImgView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (apodDateLabel != null) {
				apodDateLabel.Dispose ();
				apodDateLabel = null;
			}
			if (apodTitleLabel != null) {
				apodTitleLabel.Dispose ();
				apodTitleLabel = null;
			}
			if (apoImgView != null) {
				apoImgView.Dispose ();
				apoImgView = null;
			}
		}
	}
}
