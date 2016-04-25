using UnityEngine;
using System.Collections;

public class MovePaddle : MonoBehaviour
{

    public float speed = 1f;

	void Update()
    {
        GameObject gameControllerObj = GameObject.Find("GameController");

        if (!gameControllerObj.GetComponent<GameController>().counting)
        {
            float zPos = transform.position.z + (Input.GetAxis("Vertical") * speed);
            Vector3 paddlePos = new Vector3(-15f, 1f, Mathf.Clamp(zPos, -7.5f, 7.5f));
            transform.position = paddlePos;
        }
        
    }

    public void Reset()
    {
        transform.position = new Vector3(-15F, 1F, 0F);
    }
}
