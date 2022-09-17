using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMovement : MonoBehaviour
{

    public float MoveSpeed = 2f;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Time.deltaTime * MoveSpeed * Vector3.right;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Time.deltaTime * MoveSpeed * Vector3.left;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Time.deltaTime * MoveSpeed * Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Time.deltaTime * MoveSpeed * Vector3.back;
        }
    }

   
}
