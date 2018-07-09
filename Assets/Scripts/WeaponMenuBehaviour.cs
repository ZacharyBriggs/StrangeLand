using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WeaponMenuBehaviour : MonoBehaviour
{
    private WeaponClass ClassWeapon = new WeaponClass();
    private string FileName = "Weapon.txt";
    private string filePath;
    public Slider ForceSlider;
    public Slider FireRateSlider;
    private Text ForceText;
    private Text FireRateText;

    void Start ()
    {
        filePath = Path.Combine(Application.streamingAssetsPath, FileName);
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

        ForceText = ForceSlider.GetComponentInChildren<Text>();
        FireRateText = FireRateSlider.GetComponentInChildren<Text>();
    }
	
	void Update ()
	{
	    ClassWeapon.Force = (int)ForceSlider.value;
	    ClassWeapon.FireRate = FireRateSlider.value;
        ForceText.text = ClassWeapon.Force.ToString();
	    FireRateText.text = FireRateSlider.value.ToString();
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("scene");
    }

    public void SaveButton()
    {
        string data = JsonUtility.ToJson(ClassWeapon);
        File.WriteAllText(filePath,data);
    }
}
