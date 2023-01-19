using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Client.Maui;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => Client.Maui.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
