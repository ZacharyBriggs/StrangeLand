using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBehaviour : MonoBehaviour
{
    public float Speed;
    public InventoryScriptable Inventory;
    public Vector2 CurrentPosition;
    private ShootingBehaviour CurrentWeapon;
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start ()
	{
	    Speed *= 100;
	    CurrentPosition = transform.position;
	    CurrentWeapon = GetComponent<ShootingBehaviour>();
	    rb2d = GetComponent<Rigidbody2D>();
	    Input.multiTouchEnabled = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
        var h = Input.GetAxis("Horizontal");
	    var v = Input.GetAxis("Vertical");
        Vector2 InputVec = new Vector2(h,v);
	    if (Input.GetButtonDown("Weapon1"))
	    {
	        CurrentWeapon.weapon = Inventory.Weapons[0];
	    }
	    if (Input.GetButtonDown("Weapon2"))
	    {
	        CurrentWeapon.weapon = Inventory.Weapons[1];
	    }
	    if (Input.GetButtonDown("Weapon3"))
	    {
	        CurrentWeapon.weapon = Inventory.Weapons[2];
	    }
	    rb2d.AddForce(InputVec * Speed * Time.deltaTime);
    }

    public void WeaponOneButtonClick()
    {
        CurrentWeapon.weapon = Inventory.Weapons[0];
    }
    public void WeaponTwoButtonClick()
    {
        CurrentWeapon.weapon = Inventory.Weapons[1];
    }
    public void WeaponThreeButtonClick()
    {
        CurrentWeapon.weapon = Inventory.Weapons[2];
    }
}
