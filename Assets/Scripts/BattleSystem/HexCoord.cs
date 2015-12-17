using UnityEngine;
using System;
using System.Collections;


namespace BattleSystem
{
	[Serializable]
	public class HexCoord{

			public int xCoord;
			public int yCoord;

			public HexCoord (int x, int y)
			{
				xCoord = x;
				yCoord = y;
			}
	}

}
