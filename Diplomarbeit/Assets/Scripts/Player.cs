//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
namespace AssemblyCSharp
{
	public class Player
	{
		public string Id {
			get;
			set;
		}
		public string Revision {
			get;
			set;
		}
		public string Name {
			get;
			set;
		}		
		public int Coins {
			get;
			set;
		}
		public int Highscore {
			get;
			set;
		}

		public List<Powerup> Powerups {
			get;
			set;
		}
		public List<Match> Matches {
			get;
			set;
		}

		public Player ()
		{
		}
		public Player (string Id, string Revision, string Name, int Coins, int Highscore, List<Powerup> Powerups)
		{
			this.Id = Id;
			this.Revision = Revision;
			this.Name = Name;
			this.Coins = Coins;
			this.Highscore = Highscore;
			this.Powerups = Powerups;
		}
	}
}

