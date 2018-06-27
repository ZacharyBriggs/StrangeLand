using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyBehaviour : MonoBehaviour {

    private GameObject Player;
    public float Speed;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 dirToPlayer;
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
	    var rb2d = this.GetComponent<Rigidbody2D>();
        rb2d.AddForce(dirToPlayer*Speed,ForceMode2D.Force);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
