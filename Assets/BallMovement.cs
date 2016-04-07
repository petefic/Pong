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

    void OnCollisionEnter(Collision col)
    {
        float z = getCollisionPos(transform.position, col.transform.position, col.collider.bounds.size.z);

        int x;
        if (col.gameObject.name == "Player")
        {
            x = 1;
        }
        else if (col.gameObject.name == "CPU")
        {
            x = -1;
        }
        else
        {
            return;
        }

        Vector3 dir = new Vector3(x, 0.5F, z).normalized;

        GetComponent<Rigidbody>().velocity = dir * speed;
    }

    float getCollisionPos(Vector3 ballPos, Vector3 racketPos, float racketLength)
    {
        return ((ballPos.z - racketPos.z) / racketLength);
    }
        
}
