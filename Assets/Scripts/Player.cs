using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7;


    private void Update()
    {
        Vector2 inputVector2 = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector2.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector2.y -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector2.x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector2.x -= 1;
        }

        inputVector2 = inputVector2.normalized;

        Vector3 moveDir = new Vector3(inputVector2.x, 0f, inputVector2.y);

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float rotateSpeed = 10f;

        transform.forward += Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);

    }
}
