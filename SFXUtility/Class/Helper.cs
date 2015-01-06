
namespace SFXUtility.Class
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Reflection;
	using System.Text.RegularExpressions;
	using System.Xml;
	using LeagueSharp.Common;
	using SharpDX;
	using SharpDX.Direct3D9;
	
	public static class Helper
	{
		public static void DrawText(Font font, string text, int posX, int posY, Color color)
		{
			Rectangle rec = font.MeasureText(null, text, FontDrawFlags.Center);
			font.DrawText(null, text, posX + 1 + rec.X, posY + 1, Color.Black);
			font.DrawText(null, text, posX + rec.X, posY + 1, Color.Black);
			font.DrawText(null, text, posX - 1 + rec.X, posY - 1, Color.Black);
			font.DrawText(null, text, posX + rec.X, posY - 1, Color.Black);
			font.DrawText(null, text, posX + rec.X, posY, color);
		}
	}
}