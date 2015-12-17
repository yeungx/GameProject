using UnityEngine;
using System.Collections;

namespace BattleSystem
{

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rbody;
	Animator anim;
	CircleCollider2D cirCollider;
	Player player;
	public LayerMask blockingLayer;

	private float moveTime = 0.07f;
	Vector2 mouseClick;

	// Use this for initialization
	void Start () {
		
		player = GetComponent<Player> ();
		cirCollider = GetComponent<CircleCollider2D> ();
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		anim.SetFloat ("input_y", -1f);
		


	}

	
//	void Update () {
//		
//
//		
//		if (!BattleSystemManager.playerTurn)
//			return;
//
////Old Movement code, taking direction input from keyboard
////		float horizontal = 0;
////		float vertical = 0;
////
////
////		horizontal = (float)Input.GetAxisRaw ("Horizontal");
////		vertical = (float)Input.GetAxisRaw ("Vertical");
////		
////		if (horizontal != 0) {
////			vertical = 0;
////		}
////
////		Vector2 movement_vector = new Vector2 (horizontal, vertical);
////		
////		if (movement_vector != Vector2.zero) {
////			anim.SetBool ("iswalking", true);
////			anim.SetFloat ("input_x", movement_vector.x);
////			anim.SetFloat ("input_y", movement_vector.y);
////		} else {
////			anim.SetBool ("iswalking", false);
////		}
//
//		if (player.turnsLeft == 0) {
//				player.activePlayer = false;
//				BattleSystemManager.control = false;
//			}
//
//			//Initialize Raycasting to variable hit
//		RaycastHit2D hit;
//			//Check movement conditions to move
//
//			if (player.transform.position == BattleSystemManager.currentHex.transform.position) {
//				BattleSystemManager.moveActive = false;
//			}
//			if(BattleSystemManager.moveActive == true && player.activePlayer == true && player.turnsLeft>0 && player.transform.position != BattleSystemManager.currentHex.transform.position){
//				Move (BattleSystemManager.currentHex.transform.position.x ,BattleSystemManager.currentHex.transform.position.y ,out hit);
//
//
//				
//
//				}
//
//
//		
//
//
//
//	}

	public void Move(float x, float y, out RaycastHit2D hit){
		BattleSystemManager.playerTurn = false;
		Vector2 start = transform.position;
		Vector2 end =  new Vector2 (x, y);
		
		cirCollider.enabled = false;
		hit = Physics2D.Linecast (start, end, blockingLayer);
		cirCollider.enabled = true;
		
		if (hit.transform == null) {
			StartCoroutine (SmoothMovement (end));
			player.turnsLeft--;
			
		} else {
			anim.SetBool ("iswalking", false);
			BattleSystemManager.playerTurn = true;
		}
				
		
	}

	protected IEnumerator SmoothMovement (Vector3 end)
	{
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
		
		while (sqrRemainingDistance > float.Epsilon)
		{
			Vector3 newPosition = Vector3.MoveTowards (rbody.position, end, moveTime);
			rbody.MovePosition(newPosition);
			sqrRemainingDistance = (transform.position - end).sqrMagnitude;
			
			
			
			yield return null;
			
		}

			BattleSystemManager.moveActive = false;
//		Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, transform.position, 0.1f);

		
		BattleSystemManager.playerTurn = true;
	}


	}
}
