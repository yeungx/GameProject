using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public string name;
	public int maxHealth = 10;
	public int currentHealth;
	public int maxMana = 10;
	public int currentMana;
	public int strangth = 5;
	public Ability[] abilities;
	public Sprite portrait;

}
