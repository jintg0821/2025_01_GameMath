using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveX, 0, moveZ);
        float magnitude = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y + direction.z * direction.z);

        if (magnitude > 0)
        {
            Vector3 normalized = new Vector3(direction.x / magnitude, direction.y / magnitude, direction.z / magnitude);
            Vector3 move = normalized * speed * Time.deltaTime;
            transform.Translate(move);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, -rotationSpeed * Time.deltaTime, 0f);
            transform.rotation = deltaRotation * transform.rotation;
        }
        if (Input.GetKey(KeyCode.E))
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, rotationSpeed * Time.deltaTime, 0f);
            transform.rotation = deltaRotation * transform.rotation;
        }
    }
}