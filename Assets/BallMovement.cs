using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

    public float speed = 30;

    void Start()
    {

        int x = Random.Range(0, 2);
        if (x == 0)
        {
            x = -1;
        }
        int z = Random.Range(-1, 2);
        
        Vector3 initalDir = new Vector3(x, 0, z);
        
        GetComponent<Rigidbody>().velocity = initalDir * speed;

    }
        
}
