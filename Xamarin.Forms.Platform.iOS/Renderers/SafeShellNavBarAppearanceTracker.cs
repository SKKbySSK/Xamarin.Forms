﻿using UIKit;

namespace Xamarin.Forms.Platform.iOS
{
	public class SafeShellNavBarAppearanceTracker : IShellNavBarAppearanceTracker
	{
		private UIColor _defaultBarTint;
		private UIColor _defaultTint;
		private UIStringAttributes _defaultTitleAttributes;

		public void UpdateLayout(UINavigationController controller)
		{
		}

		public void ResetAppearance(UINavigationController controller)
		{
			if (_defaultTint != null)
			{
				var navBar = controller.NavigationBar;
				navBar.TintColor = _defaultTint;
				navBar.TitleTextAttributes = _defaultTitleAttributes;
			}
		}

		public void SetAppearance(UINavigationController controller, ShellAppearance appearance)
		{
			var background = appearance.BackgroundColor.Value;
			var foreground = appearance.ForegroundColor.Value;
			var titleColor = appearance.TitleColor.Value;

			var navBar = controller.NavigationBar;

			if (_defaultTint == null)
			{
				_defaultBarTint = navBar.BarTintColor;
				_defaultTint = navBar.TintColor;
				_defaultTitleAttributes = navBar.TitleTextAttributes;
			}

			if (!background.IsDefault)
				navBar.BarTintColor = background.ToUIColor();
			if (!foreground.IsDefault)
				navBar.TintColor = foreground.ToUIColor();
			if (!titleColor.IsDefault)
			{
				navBar.TitleTextAttributes = new UIStringAttributes
				{
					ForegroundColor = titleColor.ToUIColor()
				};
			}
		}

		#region IDisposable Support
		protected virtual void Dispose(bool disposing)
		{
		}

		public void Dispose()
		{
			Dispose(true);
		}
		#endregion
	}
}