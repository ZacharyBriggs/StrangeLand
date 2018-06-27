using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBehaviour : MonoBehaviour
{
    public GoblinLoot LootTable;
    public Item rat;
	void Start ()
	{
		
	}
	
	void Update ()
	{
	    if (Input.GetKey(KeyCode.Space))
	    {
            rat.Use();
	    }
	}
}
