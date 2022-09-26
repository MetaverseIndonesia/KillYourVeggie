using System;
using System.Collections;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AvatarMovement : MonoBehaviour
{
    [SerializeField] private Item[] items;
    public bool canSwitchGuns;
    public float MoveSpeed = 2f;
    public PhotonView pv;

    private int itemIndex;
    private int previousIndex = -1;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Time.deltaTime * MoveSpeed * Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Time.deltaTime * MoveSpeed * Vector3.left;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Time.deltaTime * MoveSpeed * Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Time.deltaTime * MoveSpeed * Vector3.back;
        }
    }
    private void HandleInventory()
    {
        if (canSwitchGuns)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (Input.GetKeyDown((i + 1).ToString()))
                {
                    EquipItem(i);
                    break;
                }
            }

            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
            {
                if (itemIndex >= items.Length - 1)
                    EquipItem(0);
                else
                    EquipItem(itemIndex + 1);
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
            {
                if (itemIndex <= 0)
                    EquipItem(items.Length - 1);
                else
                    EquipItem(itemIndex - 1);
            }
        }
    }
    private void EquipItem(int _index)
    {
        if (pv == null) return;

        if (_index == previousIndex) return;

        itemIndex = _index;
        items[itemIndex].itemGameObject.SetActive(true);

        if (previousIndex != -1)
        {
            items[previousIndex].itemGameObject.SetActive(false);
        }

        previousIndex = itemIndex;

        if (pv.IsMine)
        {
            Hashtable hash = new Hashtable();
            hash.Add("itemIndex", itemIndex);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
    }
}
