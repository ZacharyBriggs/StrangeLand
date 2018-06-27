using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    public float Cooldown;
    private Vector3 SpawnPosition;
    private float Timer;
    public GameObject Prefab;
	// Use this for initialization
	void Start ()
	{
	    Timer = Cooldown;
	    SpawnPosition = transform.position + Vector3.one;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Timer <= 0)
	    {
	        Instantiate(Prefab,SpawnPosition,Quaternion.identity);
	        Timer = Cooldown;
	    }

	    Timer -= Time.deltaTime;
	}
}
