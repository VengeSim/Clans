using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Venge;

namespace Venge
{
	public static class Random
	{
		
		static System.Random random;
		
		static Random()
		{
			random = new System.Random(69);
		}
		
		public static int Range(int min, int max)
		{
			return random.Next(min, max + 1);
		}
		
		
		public static int Gaussian(double mean, double standardDeviation)
		{
			///http://en.wikipedia.org/wiki/Normal_distribution#Standard_deviation_and_tolerance_intervals
			///https://bitbucket.org/Superbest/superbest-random/src/f067e1dc014c31be62c5280ee16544381e04e303/Superbest%20random/RandomExtensions.cs?at=master
			/// param 1 = Mean of the distribution (The middle number)
			/// param 2 = Standard deviation
			///Generates normally distributed numbers. 
			///Each operation makes two Gaussians for the price of one, 
			///and apparently they can be cached or something for better performance, but who cares.
			double u1 = random.NextDouble();
			double u2 = random.NextDouble();
			
			double rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
				Math.Sin(2.0 * Math.PI * u2);
			
			double rand_normal = mean + standardDeviation * rand_std_normal;
			
			return Convert.ToInt32(rand_normal);
		}
		
		public static int Gaussian(double mean, double standardDeviation, int min, int max)
		{
			return Mathf.Clamp(Venge.Random.Gaussian(mean, standardDeviation), min, max);
		}
		
		public static int DiceRoll()
		{
			return Venge.Random.Range(1, 6);
		}
			
		public static int OpenDiceRoll()
		{
			return Venge.Random.OpenDiceRoll(0);
		}
		
		public static int OpenDiceRoll(int add)
		{
			int diceRoll = Venge.Random.DiceRoll();
			if(diceRoll == 6)
			{
				diceRoll --;
				return Venge.Random.OpenDiceRoll(diceRoll + add);
			}
			
			return diceRoll + add;
		}

	}
}
