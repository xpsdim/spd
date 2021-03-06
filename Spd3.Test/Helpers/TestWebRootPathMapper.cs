﻿using System;
using System.IO;
using System.Reflection;

namespace Spd.Helpers
{
	public class TestWebRootPathMapper : IWebRootPathMapper
	{
		public string MapPath(string seedFile)
		{
			var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
			var directoryName = Path.GetDirectoryName(absolutePath).Replace(".Test", "");
			var path = Path.Combine(directoryName, seedFile);

			return path;
		}
	}
}
