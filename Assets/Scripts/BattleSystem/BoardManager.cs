using UnityEngine;
using System;
using System.Collections.Generic; 		//Allows us to use Lists.
using Random = UnityEngine.Random; 		//Tells Random to use the Unity Engine random number generator.

namespace BattleSystem
{
	public class BoardManager : MonoBehaviour {





		public int columns = 8; 										//Number of columns in our game board.
		public int rows = 8;											//Number of rows in our game board.
		public Hex[] hexTiles;											//Array of floor prefabs. 
//		public GameObject[] outerWallTiles;			
		private float gridSpaceX = 1.18f;								//Offset Hexagon Spacing
		private float gridSpaceY = 1.037f;								//Offset Hexagon Spacing
		private float gridShift;										//Stagger Every other Row

		public static Transform boardHolder;									//A variable to store a reference to the transform of our Board object.




		public void BoardSetup ()
		{
			//Instantiate Board and set boardHolder to its transform.
			boardHolder = new GameObject ("Board").transform;
			
			//Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
			for(int x = 0; x < columns; x++)
			{
				//Loop along y axis, starting from -1 to place floor or outerwall tiles.
				for(int y = 0; y < rows; y++)
				{
					//Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
					Hex toInstantiate = hexTiles[Random.Range (0,hexTiles.Length)];

					toInstantiate.hexCoord = new HexCoord(x,y);

					//Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
					//if(x == -1 || x == columns || y == -1 || y == rows)
						//toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];
					
					//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
					if (y%2 == 0)
						gridShift = 0.59f;
					else
						gridShift = 0f;
					Hex instance =
						Instantiate (toInstantiate, new Vector3 ((x*gridSpaceX)+gridShift, y*gridSpaceY, 0f), Quaternion.identity) as Hex;


					//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.

					instance.transform.SetParent (boardHolder);

				}
			}
			BattleSystemManager.totalHex = FindObjectsOfType (typeof(Hex)) as Hex[];
		}

		public void LevelSetup (Level currentLevel) {
			foreach (Level.SpawningObject player in currentLevel.spawningPlayers) {
				Hex hexTarget = RetrieveHexFromHexCoord (player.SpawnLocation);
				GameObject playerObject = SpawnObjectOnHex (player.toBeSpawned, hexTarget);
				Player playerVar = playerObject.GetComponent <Player>();
				hexTarget.playerOnHex = playerVar;


			}
			foreach (Level.SpawningObject enemy in currentLevel.spawningEnemies) {
				Hex hexTarget = RetrieveHexFromHexCoord (enemy.SpawnLocation);
				GameObject enemyObject = SpawnObjectOnHex (enemy.toBeSpawned, hexTarget);
				Enemy enemyVar = enemyObject.GetComponent <Enemy>();
				hexTarget.enemyOnHex = enemyVar;

			}
			BattleSystemManager.players = FindObjectsOfType (typeof(Player))as Player[];
			BattleSystemManager.enemies = FindObjectsOfType (typeof(Enemy))as Enemy[];
		}
		
		public GameObject SpawnObjectOnHex (GameObject toSpawn, Hex hexTarget){

			GameObject currentObject = 
				Instantiate(toSpawn, hexTarget.transform.position, Quaternion.identity) as GameObject;
			currentObject.transform.SetParent(BoardManager.boardHolder);
			return currentObject;
//			foreach (SpawningObject enemy in spawningEnemies) {
//				enemies.Add(enemy.toBeSpawned) ;
//			}


		}

		public void MoveObjectToHex (GameObject toSpawn, HexCoord HexTarget){

		}

		public Hex RetrieveHexFromHexCoord (HexCoord TargetHexCoord){

			foreach (Hex hex in BattleSystemManager.totalHex) {
				if (hex.hexCoord.xCoord  == TargetHexCoord.xCoord && hex.hexCoord.yCoord  == TargetHexCoord.yCoord)
					return hex;
			}
			Debug.Log ("Invalid Hex Coord" + TargetHexCoord.xCoord + TargetHexCoord.yCoord);
			return null;
		}


////////////////////////////////////////////////
//TO BE ADDED LATER ONCE I FIGURE OUT SORTING //
////////////////////////////////////////////////
//		public Hex RetrieveHexsFromHexCoords (List<HexCoord> TargetHexCoords){
//			foreach (HexCoord TargetCoord in TargetHexCoords) {
//
//			}
//		}


	}
}

		//		void Awake (){
		//			foreach (SpawningObject player in spawningPlayers) {
		//				players.Add(player.toBeSpawned) ;
		//			}
		//			foreach (SpawningObject enemy in spawningEnemies) {
		//				enemies.Add(enemy.toBeSpawned) ;
		//			}
		//
		//		}
//		void LoadEnemies(Enemy[] enemies){
//			for (int i = 0; i < enemies.Length ; i++) {
//				
//				Enemy currentEnemy =
//					Instantiate(enemies[i], new Vector3 (enemySpawnX + i*1.18f, enemySpawnY, 0f), Quaternion.identity) as Enemy;
//				currentEnemy.transform.SetParent(BoardManager.boardHolder);
//				
//			}
//			
//		}
//		void LoadPlayer(Player[] players){
//			for (int i = 0; i < players.Length ; i++) {
//				Player currentPlayer =
//					Instantiate(players[i], new Vector3 (playerSpawnX + i*1.18f, playerSpawnY, 0f), Quaternion.identity) as Player;
//				currentPlayer.transform.SetParent(BoardManager.boardHolder);
//				
//			}
//			
//			
//			
//		}
	




	






