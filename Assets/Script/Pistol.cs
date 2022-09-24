using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float fireRate;
    public GameObject shot;
    public GameObject fire;
    public Transform shotSpawn;
    public AudioClip reload;
    public AudioClip shoot;

    private float nextFire;
    private float ammo;
    void Start()
    {
        ammo = 30;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            if (ammo < 1)
            {
                return;
            }
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            Instantiate(fire, shotSpawn.position, shotSpawn.rotation);
            ammo--;
            Debug.Log(ammo);
        }
        if (ammo < 1)
        {
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2);
        ammo = 30;
    }
}
