using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public Item item;
	// Use this for initialization
	void Start ()
	{
	    SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
	    sprite.sprite = item.image;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GoblinBehaviour gob = other.GetComponent<GoblinBehaviour>();
            gob.LootTable.Add(item); 
        }
    }
}
