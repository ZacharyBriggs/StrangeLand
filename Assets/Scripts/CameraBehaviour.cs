using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private GameObject Player;
	// Use this for initialization
	void Start ()
	{
		Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 pos = Vector3.zero;
        if(Player != null)
	        pos = Player.transform.position;
	    pos.z = -10;
	    transform.position = pos;
	}
}
