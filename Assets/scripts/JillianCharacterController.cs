using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JillianCharacterController : MonoBehaviour 
{
	//---Movement---
	private float currentSpeed = 6.0f;
	public float walkSpeed = 6.0f;
	public float sprintSpeed = 10.0f;
	//---health and armour
	public Text healthText;
	public Text armourText;
	public Text ammoText;
	public Text manaText;
	public Image redImage;
	public Image blueImage;
	public Image bossImage;
	public float health = 100;
	public float armour = 0;
	public float ammo = 10;
	public bool armourStat;
	public float mana = 0;
	private float moreMana;
	public float manaRate = 10;
    public bool redKeyStat = false;
	public bool blueKeyStat = false;
	public bool bossKeyStat = false;

	//---Mouse---
	public float mouseSpeed = 2.0f;

	//---Weapons---
	public int currentWeapon = 1;
	private float fireRate; //current firerate
	private float timeToShoot;
	private float timeToImp;
	public float fireRateVialLong = 0.5f;
	public float fireRateVialShort = 0.5f;
	public float fireRateFireball = 1.0f;
	public float fireRateImp= 30.0f;
	//Visual Models/Sprites
	public GameObject fireball;
	public GameObject vials;
	public GameObject imp;
	//weapon Hitboxes/Projectiles Spawners
	public Transform weaponSpawner;
	/*public GameObject fistsSpawner;
	public GameObject broadswordSpawner;
	public GameObject throwingAxeSpawner;*/

	//weapon Hitboxes/Projectiles (Prefabs)
	GameObject currentAttack;
	public GameObject fireballProjectile;
	public GameObject vialLongProjectile; //Thrust
	public GameObject vialShortProjectile; //Slash
	public GameObject impObject;

	// Use this for initialization
	void Start () 
	{
		currentWeapon = 1;
		currentAttack = vialLongProjectile;
		vials.SetActive (true);
		fireball.SetActive (false);
		imp.SetActive (false);
		fireRate = fireRateVialLong;
		redImage.enabled = false;
		blueImage.enabled = false;
		bossImage.enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{
		healthText.text = health.ToString();
		armourText.text = armour.ToString();
		ammoText.text = ammo.ToString();
		manaText.text = mana.ToString();
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
			currentWeapon = 1; //Second weapon "Vials"
			currentAttack = vialLongProjectile;
			vials.SetActive (false);
			fireball.SetActive (true);
			imp.SetActive (false);
			fireRate = fireRateVialLong;
		}

		if (Input.GetKeyDown(KeyCode.Alpha2)){
			currentWeapon = 2; //First weapon "FireBall"
			currentAttack = fireballProjectile;
			vials.SetActive (true);
			fireball.SetActive (false);
			imp.SetActive (false);
			fireRate = fireRateFireball;
		}

		if (Input.GetKeyDown(KeyCode.Alpha3)){
			currentWeapon = 3; //Third weapon "Imp"
			currentAttack = impObject;
			vials.SetActive (false);
			fireball.SetActive (false);
			imp.SetActive (true);
			fireRate = fireRateImp;
		}

		//Fire/Attack
		if(Input.GetKeyDown(KeyCode.Mouse0) && currentWeapon == 1 && Time.time > timeToShoot){
			Debug.Log("fire");
			Instantiate (vialLongProjectile, weaponSpawner.position, weaponSpawner.rotation);
			timeToShoot = Time.time + fireRateVialLong;
		}

		if(Input.GetKeyDown(KeyCode.Mouse1) && currentWeapon == 1 && Time.time > timeToShoot){
			Debug.Log("fire");
			Instantiate (vialShortProjectile, weaponSpawner.position, weaponSpawner.rotation);
			timeToShoot = Time.time + fireRateVialShort;
		}

		if(Input.GetKeyDown(KeyCode.Mouse0) && currentWeapon == 2 && ammo > 0 && Time.time > timeToShoot){
			Debug.Log("fire");
			Instantiate (fireballProjectile, weaponSpawner.position, weaponSpawner.rotation);
			ammo -= 1;
			timeToShoot = Time.time + fireRateFireball;
		}

		if(Input.GetKeyDown(KeyCode.Mouse0) && currentWeapon == 3 && mana == 100){
			Debug.Log("fire");
			if (GameObject.Find ("Imp(Clone)")) 
			{
				Destroy (GameObject.Find ("Imp(Clone)"));
			}
			Instantiate (impObject, weaponSpawner.position, weaponSpawner.rotation);
			//timeToImp = Time.time + fireRateImp;
		}

		if (armour > 0) {
			armourStat = true;
		} 
		else 
		{
			armourStat = false;
		}

		if(Time.time > moreMana){
			mana += 10;
			moreMana = Time.time + manaRate;
			if (mana > 100) {
				mana = 100;
				Debug.Log("Special is ready!");
				if (Input.GetKeyDown (KeyCode.Space)) {
					mana = 0;
				}
			}
		}
	}

	void OnTriggerEnter(Collider col) 
	{
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

        if (col.gameObject.tag == "RedKey")
        {
            redKeyStat = true;
			redImage.enabled = true;
            col.gameObject.SetActive(false);
        }

		if (col.gameObject.tag == "BlueKey")
		{
			blueKeyStat = true;
			blueImage.enabled = true;
			col.gameObject.SetActive(false);
		}

		if (col.gameObject.tag == "BossKey")
		{
			bossKeyStat = true;
			bossImage.enabled = true;
			col.gameObject.SetActive(false);
		}
    }

	void OnTriggerStay (Collider col)
	{
		//men at arms
		if (col.gameObject.tag == "Enemy" && armourStat == true) {
			armour -= 5;
			if (armour <= 0) {
				armourStat = false;
				armour = 0;
			}
		}

		if (col.gameObject.tag == "Enemy" && armourStat == false) {
			health -= 5;
			if (health <= 0) {
				Debug.Log ("Dead");
			}
		}

		//Projectile enemy
		if (col.gameObject.tag == "AI Shot" && armourStat == true) {
			armour -= 10;
			if (armour <= 0) {
				armourStat = false;
				armour = 0;
			}
		}

		if (col.gameObject.tag == "AI Shot" && armourStat == false) {
			health -= 10;
			if (health <= 0) {
				Debug.Log ("Dead");
			}
		}

		//HitScan enemy
		if (col.gameObject.tag == "AIhitscanbox" && armourStat == true) {
			armour -= 5;
			if (armour <= 0) {
				armourStat = false;
				armour = 0;
			}
		}

		if (col.gameObject.tag == "AIhitscanbox" && armourStat == false) {
			health -= 5;
			if (health <= 0) {
				Debug.Log ("Dead");
			}
		}

		//knight enemy
		if (col.gameObject.tag == "Melee Knight" && armourStat == true) {
			armour -= 10;
			if (armour <= 0) {
				armourStat = false;
				armour = 0;
			}
		}

		if (col.gameObject.tag == "Melee Knight" && armourStat == false) {
			health -= 10;
			if (health <= 0) {
				Debug.Log ("Dead");
			}
		}

		//Boss 1 Golden Knight
		if (col.gameObject.tag == "Golden Knight" && armourStat == true) {
			armour -= 15;
			if (armour <= 0) {
				armourStat = false;
				armour = 0;
			}
		}

		if (col.gameObject.tag == "Golden Knight" && armourStat == false) {
			health -= 15;
			if (health <= 0) {
				Debug.Log ("Dead");
			}
		}

		//Boss 2 Arthur
		if (col.gameObject.tag == "Arthur" && armourStat == true) {
			armour -= 20;
			if (armour <= 0) {
				armourStat = false;
				armour = 0;
			}
		}

		if (col.gameObject.tag == "Arthur" && armourStat == false) {
			health -= 20;
			if (health <= 0) {
				Debug.Log ("Dead");
			}
		}

		//Boss 3 Van Helsing
		if (col.gameObject.tag == "Helsing" && armourStat == true) {
			armour -= 10;
			if (armour <= 0) {
				armourStat = false;
				armour = 0;
			}
		}

		if (col.gameObject.tag == "Helsing" && armourStat == false) {
			health -= 10;
			if (health <= 0) {
				Debug.Log ("Dead");
			}
		}
	}
}

