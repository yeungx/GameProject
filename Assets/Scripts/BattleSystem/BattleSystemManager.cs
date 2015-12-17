using UnityEngine;
using System.Collections;
using System.Collections.Generic;		//Allows us to use Lists. 
using UnityEngine.UI;					//Allows us to use UI.

namespace BattleSystem
{

	public class BattleSystemManager : MonoBehaviour{

		public enum BattleStates{
			PLAYER_CHOICE,
			PLAYER_CHOOSING_MOVE_TARGET,
			PLAYER_CHOOSING_ATTACK_TARGET,
			ENEMY_CHOICE,
			ENEMY_ANIMATION,
			LOSE,
			WIN,
		}

		public static BattleSystemManager instance = null;
		public static Hex currentHex;
		public static Hex[] totalHex;

		public Level currentLevel;
		public BattleSystemUI UiInstance;
		public static bool playerTurn = true;
		public static bool enemyTurn = false;
		public static bool moveActive = false;
		public static bool control = false;
		public static BoardManager boardScript;
		public static BattleStates currentState;

		
		[HideInInspector] public static Player[] players;
		[HideInInspector] public static Enemy[] enemies;


//		public List<Enemy> enemies;
//		public List<Player> players;




		void Awake()
		{

			//Check if instance already exists
			if (instance == null)
				
				//if not, set instance to this
				instance = this;
			
			//If instance already exists and it's not this:
			else if (instance != this)
				
				//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
				Destroy(gameObject);	
			
			//Sets this to not be destroyed when reloading scene
			DontDestroyOnLoad(gameObject);
			
			boardScript = GetComponent<BoardManager>();
			
			InitGame();

			currentState = BattleStates.PLAYER_CHOICE;
			
		}
		
		void Update(){
			switch (currentState) {
		
			case (BattleStates.PLAYER_CHOICE):


				break;

			case (BattleStates.PLAYER_CHOOSING_MOVE_TARGET):
				
				break;
			case (BattleStates.PLAYER_CHOOSING_ATTACK_TARGET):
				
				break;
			case (BattleStates.ENEMY_CHOICE):
				
				break;
			case (BattleStates.ENEMY_ANIMATION):
				
				break;
			case (BattleStates.LOSE):
				
				break;
			case (BattleStates.WIN):
				
				break;


			}


		}


		void InitGame (){

			boardScript.BoardSetup ();

			Debug.Log (BattleSystemManager.totalHex.Length);
			boardScript.LevelSetup(currentLevel);
			UiInstance.PopulateUiPlayer (currentLevel);
			UiInstance.PopulateUIEnemy (currentLevel);

		}

		public static void UpdateMovement(){
			moveActive = true;
//			currentHex.UpdateSurroundingHexagons();

		}









	}
}
