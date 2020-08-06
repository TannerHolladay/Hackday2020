using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start() {
        rb.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D (Collision2D hitInfo) {
        BadBox badBox = hitInfo.collider.GetComponent<BadBox>();
        if (badBox != null) {
            badBox.TakeDamage(damage);
        }
        MapDamage mapdamage;
        if (mapdamage = hitInfo.collider.GetComponent<MapDamage>()){
            Vector3 point = hitInfo.GetContact(0).point - hitInfo.GetContact(0).normal;
            mapdamage.DamageTile(50, Vector3Int.RoundToInt(point));
        }
        Destroy(gameObject);
    }

}
