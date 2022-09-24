using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMachine : MonoBehaviour
{
    public float speed;
    public float bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
