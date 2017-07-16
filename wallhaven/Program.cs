using System;
using System.Linq;
using System.Net;
using System.IO;

namespace Wallhaven
{
	class Program
	{
		static bool DownloadWH(string filename)
		{
			WebClient client = new WebClient();
			Console.WriteLine("Downloading " + filename);
			try
			{
				client.DownloadFile("https://wallpapers.wallhaven.cc/wallpapers/full/" + filename, filename);
			}
			catch
			{
				return false;
			}
			return true;
		}

		static void Main(string[] args)
		{
			int wp = 0;

			if (args.Count() > 0)
			{
				try
				{
					wp = Int32.Parse(args[0]);
				}
				catch {	}
			}
			if (wp < 1)
			{
				Console.WriteLine("Usage: wallhaven.exe [wallpaper number to begin downloading]");
				Console.WriteLine("       No valid number was given, starting with 1.");
				wp = 1;
			}
			while (!Console.KeyAvailable)
			{
				if (File.Exists("wallhaven-" + wp + ".jpg") || File.Exists("wallhaven-" + wp + ".png"))
				{
					Console.WriteLine("Skipping " + wp);
				}
				else
				{
					if (!DownloadWH("wallhaven-" + wp + ".jpg")) DownloadWH("wallhaven-" + wp + ".png");
				}
				wp++;
			}
		}
	}
}
