using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ShootingBehaviour : MonoBehaviour
{
    public WeaponScriptable weapon;
    public Transform centerPos;
    private float Timer;

    void Start()
    {
        Timer = 0;
    }

    public void Update()
    {
#if UNITY_ANDROID
        if (Input.GetButtonUp("Fire1") && Timer <= 0)
        {
            weapon.Shoot(transform, centerPos);
            Timer = weapon.FireRate;
        }
#else
    if (Input.GetButton("Fire1") && Timer <= 0)
        {
            weapon.Shoot(transform, centerPos);
            Timer = weapon.FireRate;
        }
#endif

        Timer -= Time.deltaTime;
    }
}
