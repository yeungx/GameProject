using UnityEngine;
using System.Collections;
using System.Collections.Generic; 		//Allows us to use Lists.
using System;
using Random = UnityEngine.Random; 		//Tells Random to use the Unity Engine random number generator.

namespace BattleSystem{

	public class Level : MonoBehaviour {

		[Serializable]
		public class SpawningObject
		{
			public GameObject toBeSpawned; 			//Minimum value for our Count class.
			public HexCoord SpawnLocation; 			//Maximum value for our Count class.
			
			
			//Assignment constructor.
			public SpawningObject (GameObject toBeSpawn, HexCoord SpawnLoc)
			{
				toBeSpawned = toBeSpawn;
				SpawnLocation = SpawnLoc;
			}
		}

		public List<SpawningObject> spawningPlayers;
		public List<SpawningObject> spawningEnemies;



	}
}