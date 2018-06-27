using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBehaviour : MonoBehaviour {

    private float Timer;

    // Use this for initialization
    void Start()
    {
        Timer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer <= 0)
            Destroy(this.gameObject);
        Timer -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        Destroy(this.gameObject);
    }
}
