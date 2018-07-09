using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WeaponMenuBehaviour : MonoBehaviour
{
    private WeaponScriptable Weapon;
    private string FileName = "Weapon";
    private UnityEngine.UI.Slider ForceSlider;
    private UnityEngine.UI.Slider FireRateSlider;

    // Use this for initialization
    void Start ()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, FileName);
        if(File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            Weapon = JsonUtility.FromJson<WeaponScriptable>(data);
        }
        else
        {
            Weapon = new WeaponScriptable();
            string dataAsJson = JsonUtility.ToJson(Weapon);
            File.WriteAllText(filePath, dataAsJson);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void StartGameButton()
    {

    }

    void SaveButton()
    {

    }

    void LoadButton()
    {

    }
}
