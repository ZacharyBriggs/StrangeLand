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
    public WeaponScriptable CustomWeapon;
    private float TimePassed = 0;
    private GameObject Player;
    public Text CurrentText;
    public GameObject winText;
    public GameObject loseText;
    private string path = System.IO.Path.Combine(Environment.CurrentDirectory, "time.txt");

    void Start()
    {
        WeaponClass ClassWeapon = new WeaponClass();
        ClassWeapon.Force = 9;
        ClassWeapon.FireRate = 0.3f;
        string filePath = Path.Combine(Application.streamingAssetsPath, "Weapon.txt");
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            ClassWeapon = JsonUtility.FromJson<WeaponClass>(data);
        }
        else
        {
            string data = JsonUtility.ToJson(ClassWeapon);
            File.WriteAllText(filePath, data);
        }

        CustomWeapon.Force = ClassWeapon.Force;
        CustomWeapon.FireRate = ClassWeapon.FireRate;
    }

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
