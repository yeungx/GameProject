using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace BattleSystem
{

	public class Player : MonoBehaviour{
		public string name;
		public int maxHealth = 10;
		public int currentHealth;
		public int maxMana = 10;
		public int currentMana;
		public int strength = 5;
		public Ability[] abilities;
		public Sprite portrait;
		public int turnsLeft;
		[HideInInspector] public bool activePlayer = false;
		
		void Awake(){
			currentHealth = maxHealth;
			
			
		}

		void OnMouseDown(){
			if (BattleSystemManager.playerTurn == true && BattleSystemManager.control == false){
				BattleSystemManager.control = true;
				activePlayer = true;
			}
		}

	}
}
