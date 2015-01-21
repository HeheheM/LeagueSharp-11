#region
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using SharpDX;
using LeagueSharp;
using LeagueSharp.Common;
#endregion

namespace JungleTimer
{
	internal class JungleCamp
	{
		public string Name;
		public int NextRespawnTime;
		public int RespawnTime;
		public bool IsDead;
		public bool Visibled;
		public Vector3 Position;
		public string[] Names;
		public readonly int Id;
		public JungleCamp(string name, int respawnTime, Vector3 position, string[] names, int id)
		{
			Name = name;
			RespawnTime = respawnTime;
			Position = position;
			Names = names;
			IsDead = false;
			Visibled = false;
			Id = id;
		}
	}
	
	internal class DrawText
	{
		private static int _layer;
		public Render.Text Text { get; set; }
		public JungleCamp JungleCamp;
		public DrawText(JungleCamp camp)
		{
			Text = new Render.Text(Drawing.WorldToMinimap(camp.Position),"",15,SharpDX.Color.White)
			{
				VisibleCondition = sender => (camp.NextRespawnTime > 0 ),
				TextUpdate = () => (camp.NextRespawnTime - (int)Game.ClockTime).ToString(CultureInfo.InvariantCulture),
			};
			JungleCamp = camp;
			Text.Add(_layer);
			_layer++;
		}
	}
}