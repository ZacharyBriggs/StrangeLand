using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Melee")]
public class MeleeScriptable : WeaponScriptable
{
    public override void Shoot(Transform transform, Transform centerpos)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = mousePos - currentPos;
        Vector2 pos2D = new Vector2();
        pos2D.x = centerpos.position.x;
        pos2D.y = centerpos.position.y;
        direction.Normalize();
        var projectile = Instantiate(Projectile, pos2D + direction, Quaternion.identity);
    }
}
