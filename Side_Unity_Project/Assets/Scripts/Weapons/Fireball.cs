using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }

    Vector3 spawnPosition;

    private void Start()
    {
        // Will use stat system for Range, Damage.
        Range = 20f;
        Damage = 4;
        spawnPosition = transform.position;
        // To be changed with a speed Stat from player / weapon.
        GetComponent<Rigidbody>().AddForce(Direction * 50f);
    }

    private void Update()
    {
        if (Vector3.Distance(spawnPosition, transform.position) >= Range)
            Extinguish();
    }

    void Extinguish()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<IEnemy>().TakeDamage(Damage);
        }

        Extinguish();
    }
}
