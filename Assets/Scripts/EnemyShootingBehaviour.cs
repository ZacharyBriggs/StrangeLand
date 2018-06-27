using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingBehaviour : EnemyBehaviour
{
    public GameObject ProjectilePrefab;
    public float Cooldown;
    private float Timer;
    public float Force;

    // Use this for initialization
    void Start()
    {
        Timer = Cooldown;
        Player = GameObject.Find("Player");
        dirToPlayer = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update ()
    {
        Move(Speed);
	    if (Timer <= 0)
	    {
            Shoot();
	        Timer = Cooldown;
	    }

	    Timer -= Time.deltaTime;
	}

    void Shoot()
    {
        var projectile = Instantiate(ProjectilePrefab, transform.position + dirToPlayer, Quaternion.identity);
        var rb2d = projectile.GetComponent<Rigidbody2D>();
        rb2d.AddForce(dirToPlayer * Force, ForceMode2D.Impulse);
    }
}
