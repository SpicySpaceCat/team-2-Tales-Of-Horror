using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnnyCharacterController : MonoBehaviour {
	//---Movement---
	private float currentSpeed = 6.0f;
	public float walkSpeed = 6.0f;
	public float sprintSpeed = 10.0f;
	//---health and armour
	public float health = 100;
	public float armour = 0;
	public float ammo = 10;
	public bool armourStat;
	//---Mouse---
	public float mouseSpeed = 2.0f;

	//---Weapons---
	public int currentWeapon = 1;
	private float fireRate; //current firerate
	private float timeToShoot;
	private float timeToSlash;
	public float fireRateFists = 0.3f;
	public float fireRateThrust = 0.5f;
	public float fireRateSlash = 0.5f;
	public float fireRateAxe = 1.0f;
	//Visual Models/Sprites
	public GameObject fists;
	public GameObject broadsword;
	public GameObject throwingAxe;
	//weapon Hitboxes/Projectiles Spawners
	public Transform weaponSpawner;
	/*public GameObject fistsSpawner;
	public GameObject broadswordSpawner;
	public GameObject throwingAxeSpawner;*/

	//weapon Hitboxes/Projectiles (Prefabs)
	GameObject currentAttack;
	public GameObject fistsHitbox;
	public GameObject broadswordHitbox; //Thrust
	public GameObject attackSwordSlash; //Slash
	public GameObject throwingAxeProjectile;

	// Use this for initialization
	void Start () {
		currentWeapon = 1;
		currentAttack = fistsHitbox;
		fists.SetActive (true);
		broadsword.SetActive (false);
		throwingAxe.SetActive (false);
		fireRate = fireRateFists;
	}
	
	// Update is called once per frame
	void Update () {
		//Player Movement (WASD)
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * currentSpeed;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * currentSpeed;

		transform.Translate(x, 0, z); //allows player to walk and sprint

		//Player Sprint (Left Shift)
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			currentSpeed = sprintSpeed; //changes to sprinting speed
		} 
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			currentSpeed = walkSpeed; //changes back to walking speed
		}

		//Player Mouse (Mouse)
		Cursor.visible = false;
		Screen.lockCursor = true;
		float h = mouseSpeed * Input.GetAxis("Mouse X");

		transform.Rotate(0, h, 0); //allows mouse aiming

		//Weapon Switching
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			currentWeapon = 1; //First weapon "fists"
			currentAttack = fistsHitbox;
			fists.SetActive (true);
			broadsword.SetActive (false);
			throwingAxe.SetActive (false);
			fireRate = fireRateFists;
		}

		if (Input.GetKeyDown(KeyCode.Alpha2)){
			currentWeapon = 2; //Second weapon "Broadsword"
			currentAttack = broadswordHitbox;
			fists.SetActive (false);
			broadsword.SetActive (true);
			throwingAxe.SetActive (false);
			fireRate = fireRateThrust;
		}

		if (Input.GetKeyDown(KeyCode.Alpha3)){
			currentWeapon = 3; //Third weapon "Throwing Axe"
			currentAttack = throwingAxeProjectile;
			fists.SetActive (false);
			broadsword.SetActive (false);
			throwingAxe.SetActive (true);
			fireRate = fireRateAxe;
		}

		//Fire/Attack
		if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time > timeToShoot){
			Debug.Log("fire");
			Instantiate (currentAttack, weaponSpawner.position, weaponSpawner.rotation);
			timeToShoot = Time.time + fireRate;
		}

		if(Input.GetKeyDown(KeyCode.Mouse1) && currentWeapon == 2 && Time.time > timeToSlash){
			Debug.Log("fire");
			Instantiate (attackSwordSlash, weaponSpawner.position, weaponSpawner.rotation);
			timeToSlash = Time.time + fireRateSlash;
		}

		if(Input.GetKeyDown(KeyCode.Mouse0) && currentWeapon == 3 && ammo >= 0 && Time.time > timeToSlash){
			Debug.Log("fire");
			Instantiate (throwingAxeProjectile, weaponSpawner.position, weaponSpawner.rotation);
			ammo -= 1;
			timeToSlash = Time.time + fireRateAxe;
		}

		if (armour > 0) {
			armourStat = true;
		} 
		else 
		{
			armourStat = false;
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Minor Health" && health < 100) {
			health += 25;
			col.gameObject.SetActive (false);
			if (health > 100) {
				health = 100;
			}
		}

		if (col.gameObject.tag == "Major Health" && health < 100) {
			health += 75;
			col.gameObject.SetActive (false);
			if (health > 100) {
				health = 100;
			}
		}

		if (col.gameObject.tag == "Minor Armour" && armour < 100) {
			armour += 25;
			col.gameObject.SetActive (false);
			if (armour > 100) {
				armour = 100;
			}
		}

		if (col.gameObject.tag == "Major Armour" && armour < 100) {
			armour += 75;
			col.gameObject.SetActive (false);
			if (armour > 100) {
				armour = 100;
			}
		}

		if (col.gameObject.tag == "Ammo" && ammo < 10) {
			ammo += 10;
			col.gameObject.SetActive (false);
			if (ammo > 10) {
				ammo = 10;
			}
		}

		if (col.gameObject.tag == "Enemy" && armourStat == true) {
			armour -= 5;
			if (armour <= 0) {
				armourStat = false;
			}
		}

		if (col.gameObject.tag == "Enemy" && armourStat == false) {
			health -= 5;
			if (health <= 0) {
				Debug.Log ("Dead");
			}
		}
	}
}
