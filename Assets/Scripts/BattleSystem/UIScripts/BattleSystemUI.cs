using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
namespace BattleSystem{

	public class BattleSystemUI : MonoBehaviour {

		public GameObject enemyPanel;
		public GameObject playerPanel;
		public GameObject characterPanel;
		public Button abilityButton;
		public Text currentStateText;


		private Player[] players;
		private Enemy[] enemies;

		void Update(){
//			UpdateUI ();


			UpdateCurrentStateText ();		// this is test code that displays the current UI.
		}

//		void UpdateUI (){
		
		
//		}

		// this is test code that displays the current UI.
		void UpdateCurrentStateText (){
			currentStateText.text = "Current State: " + BattleSystemManager.currentState;
		
		
		}
		public void PopulateUiPlayer(Level currentLevel){
			foreach (Player player in BattleSystemManager.players) {
				GameObject newCharacterPanel = Instantiate (characterPanel) as GameObject;

				CharacterPanel panel = newCharacterPanel.GetComponent<CharacterPanel>();
				panel.nameLabel.text = player.name;
				panel.icon.sprite = player.portrait;
				panel.healthBar.maxValue = player.maxHealth;
				panel.healthBar.value = player.currentHealth;
				panel.manaBar.maxValue = player.maxMana;
				panel.manaBar.value = player.currentMana;
				newCharacterPanel.transform.SetParent (playerPanel.transform);
				foreach (Ability ability in player.abilities){
					Button newAbilityButton = Instantiate (abilityButton) as Button;
					AbilityButton buttonText = newAbilityButton.GetComponent<AbilityButton>();
					buttonText.abilityName.text = ability.name;
					Transform abilityTransform = panel.abilityPanel.transform;
					newAbilityButton.transform.SetParent(abilityTransform); 

				}

			}
		
		}
		public void PopulateUIEnemy (Level currentLevel){ 
			foreach (Enemy enemy in BattleSystemManager.enemies) {
				GameObject newCharacterPanel = Instantiate (characterPanel) as GameObject;
				
				CharacterPanel panel = newCharacterPanel.GetComponent<CharacterPanel>();
				panel.nameLabel.text = enemy.name;
				panel.icon.sprite = enemy.portrait;
				panel.healthBar.maxValue = enemy.maxHealth;
				panel.healthBar.value = enemy.currentHealth;
				panel.manaBar.maxValue = enemy.maxMana;
				panel.manaBar.value = enemy.currentMana;
				newCharacterPanel.transform.SetParent (enemyPanel.transform);
				foreach (Ability ability in enemy.abilities){
					Button newAbilityButton = Instantiate (abilityButton) as Button;
					AbilityButton buttonText = newAbilityButton.GetComponent<AbilityButton>();
					buttonText.abilityName.text = ability.name;
					Transform abilityTransform = panel.abilityPanel.transform;
					newAbilityButton.transform.SetParent(abilityTransform); 
				}
				
			}

		}

	}
}