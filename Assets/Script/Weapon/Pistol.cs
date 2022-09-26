using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using System;

public class Pistol : Weapons
{
    [Header("References")]
    [SerializeField] private Transform normalTransform;
    [Space]
    [SerializeField] private Transform shootPoint;
    [Space]
    [SerializeField] private Camera cam;
    [Space]
    [SerializeField] private GameObject crossHair;
    [SerializeField] private Animator animator;
    [Space]
    [SerializeField] private TMP_Text ammoText;
    [Space]
    [SerializeField] private PhotonView pv;

    [Header("Settings")]
    [SerializeField] private int magSize = 10;
    [SerializeField] private int amountLeft = 0;
    [SerializeField] private float reloadTime = 1f;
    [Space]
    [Range(0f, 10f)][SerializeField] private float lerpTime = 10f;
    [Space]
    public bool automatic;

    [Header("Shooting")]
    //[SerializeField] private float shootForce = 3f;
    public float fireRate = 15f;
    [HideInInspector] public float nextTimeToFire = 0f;

    /*[Header("Camera Shake")]
    [SerializeField] private float intensity = 0.6f;
    [SerializeField] private float roughness = 0.8f;*/

    [Header("KeyCodes")]
    [SerializeField] private KeyCode shootKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode scopeKey = KeyCode.Mouse1;
    [SerializeField] private KeyCode reloadKey = KeyCode.R;

    [Header("Script References")]
    [SerializeField] private AvatarMovement playerMovement;
    [SerializeField] private WeaponSway sway;

    [Header("Debug")]
    public bool isShooting;
    public bool isReloading;

    private bool shootNonAuto;
    private bool shootAuto;
    private bool reload;

    private RaycastHit hit;

    private void Update()
    {
        if (pv.IsMine)
        {
            shootNonAuto = Input.GetKeyDown(shootKey);
            shootAuto = Input.GetKey(shootKey);
            reload = Input.GetKeyDown(reloadKey);

            if (isReloading || isShooting)
            {
                playerMovement.canSwitchGuns = false;
            }
            else
            {
                playerMovement.canSwitchGuns = true;
            }
            if (automatic)
            {
                if (shootAuto)
                {
                    isShooting = true;
                }
                else
                {
                    isShooting = false;
                }
            }
            if (!isReloading && amountLeft != 0 && amountLeft != magSize && reload)
            {
                Reload();
            }
            else if (!isReloading && amountLeft == 0)
            {
                Reload();
            }

            SetAmmoText();
        }
    }

    public override void Use()
    {
        //Debug.Log("Using gun: " + itemInfo.itemName);

        if (automatic)
        {
            Shoot();
            StartShootingAnimationAuto();
        }
        else
        {
            Shoot();
            StartShootingAnimationNonAuto();
        }
    }

    private void Shoot()
    {
        if (Physics.Raycast(shootPoint.position, cam.transform.forward, out hit, 500f))
        {
            if (isReloading) return;

            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(((GunInfo)itemInfo).damage);
            pv.RPC("Shoot_RPC", RpcTarget.All, hit.point, hit.normal);
        }

        amountLeft--;
        //camShaker.ShakeOnce(intensity, roughness, 0.1f, 0.1f);
    }

    private void Reload()
    {
        if (pv.IsMine)
        {
            isReloading = true;
            animator.SetBool("isReloading", true);
            Invoke("StopReload", reloadTime);
        }
    }

    private void StopReload()
    {
        if (pv.IsMine)
        {
            animator.SetBool("isReloading", false);
            amountLeft = magSize;
            isReloading = false;
        }
    }
    public void StartShootingAnimationAuto()
    {
        if (pv.IsMine)
        {
            animator.SetBool("isShooting", true);
        }
    }

    public void StopShootingAnimationAuto()
    {
        if (pv.IsMine)
        {
            animator.SetBool("isShooting", false);
            animator.gameObject.transform.position = new Vector3(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y, normalTransform.position.z);
        }
    }

    public void StartShootingAnimationNonAuto()
    {
        if (pv.IsMine)
        {
            animator.SetBool("isShooting", true);
        }

    }

    public void StopShootingAnimationNonAuto()
    {
        if (pv.IsMine)
        {
            animator.SetBool("isShooting", false);
            //animator.gameObject.transform.position = new Vector3(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y, normalTransform.position.z);   
        }
    }

    private void SetAmmoText()
    {
        if (!isReloading)
        {
            ammoText.text = magSize + "/" + amountLeft;
        }
        else
        {
            ammoText.text = "RELOADING";
        }
    }

    [PunRPC]
    private void Shoot_RPC(Vector3 hitPosition, Vector3 hitNormal)
    {
        if (!playerMovement.gameObject.GetComponent<PhotonView>().IsMine)
            return;

        /*if (hit.rigidbody != null)
        {
            Vector3 forceDir = shootPoint.position - hit.point;
            hit.rigidbody.AddForce(-forceDir * shootForce);
        }*/

        if (hit.transform.CompareTag("OtherPlayer"))
        {
            Collider[] colliders = Physics.OverlapSphere(hitPosition, 0.3f);
            if (colliders.Length != 0)
            {
                GameObject bulletImpact = Instantiate(bulletImpactPrefab, hitPosition + hitNormal * 0.001f, Quaternion.LookRotation(hitNormal, Vector3.up) * bulletImpactPrefab.transform.rotation);
                Destroy(bulletImpact, 2.5f);
                bulletImpact.transform.SetParent(colliders[0].transform);
            }
        }
    }
}
