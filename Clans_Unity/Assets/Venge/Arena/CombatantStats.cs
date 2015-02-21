using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Venge;

namespace Venge
{
	public class CombatantStats
	{
		protected int reaction; // how fast action is started
		protected int speed;	// how fast the action is performed
		protected int strength;	// how much damage the action does
		protected int damage;	// how much damage taken
		protected int criticalDamage; // how much damage is effecting stats
		
		
		public string Name {
			get;
			set;
		}

		public int Reaction {get {return reaction;}}
		public int Speed {get {return speed;}}
		public int Strength {get {return strength;}}
		public int Damage {get {return damage;}}
		public int CriticalDamage {get {return criticalDamage;}}
		
		
		public CombatantStats()
		{	
			this.InitalizeStats();

		}
		public CombatantStats(string name)
		{	
			this.InitalizeStats();
			this.Name = name;
		}
		
		public void InitalizeStats()
		{	
			this.Name = "Default";
			this.reaction = Venge.Random.Gaussian(10, 3, 0, 20);
			this.speed = Venge.Random.Gaussian(10, 3, 0, 20);
			this.strength = Venge.Random.Gaussian(10, 3, 0, 20);
			this.strength = Venge.Random.Gaussian(10, 3, 0, 20);
			this.damage = Venge.Random.Gaussian(10, 3, 0, 20);
			this.criticalDamage = Venge.Random.Gaussian(10, 3, 0, 20);
		}
	}
}
