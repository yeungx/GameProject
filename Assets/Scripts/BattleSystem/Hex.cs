using UnityEngine;
using System.Collections;

namespace BattleSystem
{
	public class Hex : MonoBehaviour {


		public HexCoord hexCoord;
		public GameObject hexOverlay;
//		[HideInInspector]
		public Player playerOnHex;
//		[HideInInspector]
		public Enemy enemyOnHex;
//		[HideInInspector]
		public bool isTargetable;

		private SpriteRenderer overlayRenderer;


		void Start (){
			overlayRenderer = hexOverlay.GetComponent <SpriteRenderer>();
			overlayRenderer.color = new Color (0f,0f,0f,0f);
		}
		void Update(){
			UpdateHexOverlay ();


		}

		void UpdateHexOverlay (){
			// This code determins what color the overlay should be depending on the state, and if there is a character on it)

			if (playerOnHex == null && enemyOnHex == null) {
				overlayRenderer.color = new Color (0f, 0f, 0f, 0f);
//				Debug.Log ("Hexoverlay update");
			}

			if (BattleSystemManager.currentState == BattleSystemManager.BattleStates.PLAYER_CHOICE) {
				if (playerOnHex != null){
					overlayRenderer.color = Color.green;

				}
			}


			if (BattleSystemManager.currentState == BattleSystemManager.BattleStates.PLAYER_CHOOSING_MOVE_TARGET) {
				if (enemyOnHex == null && isTargetable == true){
					overlayRenderer.color = Color.yellow;

				}
			}
			// 
			if (BattleSystemManager.currentState == BattleSystemManager.BattleStates.PLAYER_CHOOSING_ATTACK_TARGET) {
				if (enemyOnHex == null && isTargetable == true)
					overlayRenderer.color = Color.yellow;

			}

		}
	}
}




//		public HexCoord [] UpdateSurroundingHexagons(){
//
//			hexAdjacent = new HexCoord[6];
//
//				
//			
//			for (int i = 0; i < hexAdjacent.Length;) {
//				for (int x = 0; x < BattleSystemManager.totalHex.Length; x++) {
//					if (BattleSystemManager.currentHex.hexCoord.yCoord % 2 == 0) {
//						if (BattleSystemManager.currentHex.hexCoord.xCoord == BattleSystemManager.totalHex [x].hexCoord.xCoord && BattleSystemManager.currentHex.hexCoord.yCoord + 1 == BattleSystemManager.totalHex [x].hexCoord.yCoord) {
//							hexAdjacent [i] = new HexCoord(BattleSystemManager.totalHex [x].hexCoord.xCoord, BattleSystemManager.totalHex [x].hexCoord.yCoord);
//							i++;
//						}					
//						if (BattleSystemManager.currentHex.hexCoord.xCoord + 1 == BattleSystemManager.totalHex [x].hexCoord.xCoord && BattleSystemManager.currentHex.hexCoord.yCoord + 1 == BattleSystemManager.totalHex [x].hexCoord.yCoord) {
//							hexAdjacent [i] = new HexCoord(BattleSystemManager.totalHex [x].hexCoord.xCoord, BattleSystemManager.totalHex [x].hexCoord.yCoord);
//							i++;
//						}
//						if (BattleSystemManager.currentHex.hexCoord.xCoord - 1 == BattleSystemManager.totalHex [x].hexCoord.xCoord && BattleSystemManager.currentHex.hexCoord.yCoord == BattleSystemManager.totalHex [x].hexCoord.yCoord) {
//							hexAdjacent [i] = new HexCoord(BattleSystemManager.totalHex [x].hexCoord.xCoord, BattleSystemManager.totalHex [x].hexCoord.yCoord);
//							i++;
//						}
//						if (BattleSystemManager.currentHex.hexCoord.xCoord + 1 == BattleSystemManager.totalHex [x].hexCoord.xCoord && BattleSystemManager.currentHex.hexCoord.yCoord == BattleSystemManager.totalHex [x].hexCoord.yCoord) {
//							hexAdjacent [i] = new HexCoord(BattleSystemManager.totalHex [x].hexCoord.xCoord, BattleSystemManager.totalHex [x].hexCoord.yCoord);
//							i++;
//						}
//						if (BattleSystemManager.currentHex.hexCoord.xCoord == BattleSystemManager.totalHex [x].hexCoord.xCoord && BattleSystemManager.currentHex.hexCoord.yCoord - 1 == BattleSystemManager.totalHex [x].hexCoord.yCoord) {
//							hexAdjacent [i] = new HexCoord(BattleSystemManager.totalHex [x].hexCoord.xCoord, BattleSystemManager.totalHex [x].hexCoord.yCoord);
//							i++;
//						}
//						if (BattleSystemManager.currentHex.hexCoord.xCoord + 1 == BattleSystemManager.totalHex [x].hexCoord.xCoord && BattleSystemManager.currentHex.hexCoord.yCoord - 1 == BattleSystemManager.totalHex [x].hexCoord.yCoord) {
//							hexAdjacent [i] = new HexCoord(BattleSystemManager.totalHex [x].hexCoord.xCoord, BattleSystemManager.totalHex [x].hexCoord.yCoord);
//							i++;
//						}
//
//					} else {
//						if (BattleSystemManager.currentHex.hexCoord.xCoord - 1 == BattleSystemManager.totalHex [x].hexCoord.xCoord && BattleSystemManager.currentHex.hexCoord.yCoord + 1 == BattleSystemManager.totalHex [x].hexCoord.yCoord) {
//							hexAdjacent [i] = new HexCoord(BattleSystemManager.totalHex [x].hexCoord.xCoord, BattleSystemManager.totalHex [x].hexCoord.yCoord);
//							i++;
//						}					
//						if (BattleSystemManager.currentHex.hexCoord.xCoord == BattleSystemManager.totalHex [x].hexCoord.xCoord && BattleSystemManager.currentHex.hexCoord.yCoord + 1 == BattleSystemManager.totalHex [x].hexCoord.yCoord) {
//							hexAdjacent [i] = new HexCoord(BattleSystemManager.totalHex [x].hexCoord.xCoord, BattleSystemManager.totalHex [x].hexCoord.yCoord);
//							i++;
//						}
//						if (BattleSystemManager.currentHex.hexCoord.xCoord - 1 == BattleSystemManager.totalHex [x].hexCoord.xCoord && BattleSystemManager.currentHex.hexCoord.yCoord == BattleSystemManager.totalHex [x].hexCoord.yCoord) {
//							hexAdjacent [i] = new HexCoord(BattleSystemManager.totalHex [x].hexCoord.xCoord, BattleSystemManager.totalHex [x].hexCoord.yCoord);
//							i++;
//						}
//						if (BattleSystemManager.currentHex.hexCoord.xCoord + 1 == BattleSystemManager.totalHex [x].hexCoord.xCoord && BattleSystemManager.currentHex.hexCoord.yCoord == BattleSystemManager.totalHex [x].hexCoord.yCoord) {
//							hexAdjacent [i] = new HexCoord(BattleSystemManager.totalHex [x].hexCoord.xCoord, BattleSystemManager.totalHex [x].hexCoord.yCoord);
//							i++;
//						}
//						if (BattleSystemManager.currentHex.hexCoord.xCoord - 1 == BattleSystemManager.totalHex [x].hexCoord.xCoord && BattleSystemManager.currentHex.hexCoord.yCoord - 1 == BattleSystemManager.totalHex [x].hexCoord.yCoord) {
//							hexAdjacent [i] = new HexCoord(BattleSystemManager.totalHex [x].hexCoord.xCoord, BattleSystemManager.totalHex [x].hexCoord.yCoord);
//							i++;
//						}
//						if (BattleSystemManager.currentHex.hexCoord.xCoord == BattleSystemManager.totalHex [x].hexCoord.xCoord && BattleSystemManager.currentHex.hexCoord.yCoord - 1 == BattleSystemManager.totalHex [x].hexCoord.yCoord) {
//							hexAdjacent [i] = new HexCoord(BattleSystemManager.totalHex [x].hexCoord.xCoord, BattleSystemManager.totalHex [x].hexCoord.yCoord);
//							i++;
//						}
//
//						
//					}
//					
//					
//
//				}
//			}

//			SpriteRenderer hue1 = topLeftHex.GetComponent<SpriteRenderer>();
//			SpriteRenderer hue2 = topRightHex.GetComponent<SpriteRenderer>();
//			SpriteRenderer hue3 = middleLeftHex.GetComponent<SpriteRenderer>();
//			SpriteRenderer hue4 = middleRightHex.GetComponent<SpriteRenderer>();
//			SpriteRenderer hue5 = bottomLeftHex.GetComponent<SpriteRenderer>();
//			SpriteRenderer hue6 = bottomRightHex.GetComponent<SpriteRenderer>();
//			hue1.color = new Color (1, 0, 0, 1);
//			hue2.color = new Color (1, 0, 0, 1);
//			hue3.color = new Color (1, 0, 0, 1);
//			hue4.color = new Color (1, 0, 0, 1);
//			hue5.color = new Color (1, 0, 0, 1);
//			hue6.color = new Color (1, 0, 0, 1);
//			
			
//		}
	