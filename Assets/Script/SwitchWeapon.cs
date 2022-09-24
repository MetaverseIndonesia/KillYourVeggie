using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public GameObject gunOne;
    public GameObject gunTwo;
    public GameObject gunThree;

    private void Start()
    {
        //Tulis tembakan yang mau dipakai untuk sementara. Contoh: Pistol();
    }
    public void Pistol()
    {
        gunOne.SetActive(true);
        gunTwo.SetActive(false);
        gunThree.SetActive(false);
    }
    public void Shotgun()
    {
        gunOne.SetActive(false);
        gunTwo.SetActive(true);
        gunThree.SetActive(false);
    }
    public void Machinegun()
    {
        gunOne.SetActive(false);
        gunTwo.SetActive(false);
        gunThree.SetActive(true);
    }
}
