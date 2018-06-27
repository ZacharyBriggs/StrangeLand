using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rat Gun")]
public class BazookaRatGun : Item
{
    public GameObject RatProjectile;
    public override void Use()
    {
        Debug.Log("Pew pew rat gun");
        for (int i = 0; i < 100; i++)
        {
            var rat = Instantiate(RatProjectile, Vector3.zero, Quaternion.identity);
            Rigidbody2D rb2d = rat.GetComponent<Rigidbody2D>();
            rb2d.AddForce(Vector2.right);
        }
    }
}
