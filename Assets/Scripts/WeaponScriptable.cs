using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponScriptable : ScriptableObject
{ 
    public GameObject Projectile;
    public int Force;
    public float FireRate;

    public virtual void Shoot(Transform transform,Transform centerpos)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = mousePos - currentPos;
        Vector2 pos2D = new Vector2();
        pos2D.x = centerpos.position.x;
        pos2D.y = centerpos.position.y;
        direction.Normalize();
        var projectile = Instantiate(Projectile, pos2D + direction, Quaternion.identity);
        var rb2d = projectile.GetComponent<Rigidbody2D>();
        rb2d.AddForce(direction * Force, ForceMode2D.Impulse);
    }
}
