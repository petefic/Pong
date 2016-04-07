using UnityEngine;
using System.Collections;

public class MovePaddle : MonoBehaviour {

    public float speed = 1f;

	void Update()
    {
        float zPos = transform.position.z + (Input.GetAxis("Vertical") * speed);
        Vector3 paddlePos = new Vector3(-15f, 1f, Mathf.Clamp(zPos, -7.5f, 7.5f));
        transform.position = paddlePos;
    }
}
