using UnityEngine;
using System.Collections;

namespace BattleSystem
{
	public class MouseControl : MonoBehaviour {

		SpriteRenderer hue;
		Transform pos;
		Hex thisHex;


		void Start(){
			hue = GetComponent<SpriteRenderer> ();
			pos = GetComponent<Transform> ();
			thisHex = GetComponent<Hex> ();
		}

		void OnMouseDown(){
		//	hue.color = new Color (1, 0, 1, 1);


		}


		void OnMouseUpAsButton(){
			if (BattleSystemManager.moveActive == false) {
				BattleSystemManager.UpdateMovement ();




			}

		}

		void OnMouseEnter(){
			hue.color = new Color (1, 0.92f, 0.016f, 1);
			BattleSystemManager.currentHex = thisHex;
		}

		void OnMouseExit(){
			hue.color = new Color (1, 1, 1, 1);


		}
	}
}