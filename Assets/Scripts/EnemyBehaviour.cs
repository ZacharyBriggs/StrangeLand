using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    protected GameObject Player;
    protected Vector3 dirToPlayer;
    public float Speed;

	// Use this for initialization
	void Start ()
	{
	    Player = GameObject.Find("Player");
        dirToPlayer = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Move(Speed);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    protected void Move(float speed)
    {
        if (Player != null)
        {
            dirToPlayer = Player.transform.position;
            dirToPlayer -= transform.position;
            dirToPlayer.Normalize();
        }
        else
        {
            dirToPlayer = Vector3.zero;
        }
        var rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(dirToPlayer * speed);
    }
}
