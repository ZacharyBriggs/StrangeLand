using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class BestTimeClass
{
    public float BestTime;
}
public class GameManagerBehaviour : MonoBehaviour
{
    private float TimePassed = 0;
    private GameObject Player;
    public Text CurrentText;
    public GameObject winText;
    public GameObject loseText;
    private string path = System.IO.Path.Combine(Environment.CurrentDirectory, "time.txt");
	
	void Update ()
	{
	    if (FindObjectOfType<PlayerBehaviour>() == null)
	    {
	        loseText.SetActive(true);
        }
        else if (FindObjectOfType<EnemyBehaviour>() == null && FindObjectOfType<FastEnemyBehaviour>() == null && FindObjectOfType<EnemySpawnerBehaviour>() == null)
	    {
	        winText.SetActive(true);
	        string data = File.ReadAllText(path);
	        BestTimeClass loadedTime = JsonUtility.FromJson<BestTimeClass>(data);
	    }
	    else
	    {
	        TimePassed += Time.deltaTime;
	        CurrentText.text = "Current Time " + TimePassed.ToString() + " Seconds";
        }
	}
}
