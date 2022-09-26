using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HandleGun : MonoBehaviour
{
    [SerializeField] private PhotonView pv;
    [Space(50)]
    [SerializeField] private GameObject AK_74;
    [SerializeField] private GameObject M1991;
    [SerializeField] private GameObject M4_8;

    private void Start()
    {
        if (!pv.IsMine)
        {
            AK_74.transform.localScale += new Vector3(0.9f, 0.9f, 0.9f);
            M1991.transform.localScale += new Vector3(0.9f, 0.9f, 0.9f);
            M4_8.transform.localScale += new Vector3(0.9f, 0.9f, 0.9f);
        }
        else
        {
            AK_74.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            M1991.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            M4_8.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }
}
