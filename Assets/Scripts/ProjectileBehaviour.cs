using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Lifetime;
    // Update is called once per frame
    void Update()
    {
        if (Lifetime <= 0)
            Destroy(this.gameObject);
        Lifetime -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Wall")
            Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}