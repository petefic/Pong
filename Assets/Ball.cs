using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float speed = 30; 

    public void Awake()
    {
        //calc launch direction
        int x = Random.Range(0, 2);
        if (x == 0)
        {
            x = -1;
        }
        int z = Random.Range(-1, 2);
        Vector3 initalDir = new Vector3(x, 0, z);

        //launch
        GetComponent<Rigidbody>().velocity = initalDir * speed;
    }

    public void Update()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * speed;
    }

    void OnCollisionEnter(Collision col)
    {
        int x = 0;
        if (col.gameObject.tag == "Paddle")
        {
            if (col.gameObject.name == "Player")
            {
                x = 1;
            }
            else //cpu paddle
            {
                x = -1;
            }
        }      
        else if (col.gameObject.tag == "Goal")
        {
            GameObject gameController = GameObject.Find("GameController");
            GameController gameControllerObj = gameController.GetComponent<GameController>();
            if (col.gameObject.name == "Player Goal")
            {
                gameControllerObj.Goal("Player");
            }
            else //cpu goal
            {
                gameControllerObj.Goal("CPU");
            }
        }
        else
        {
            return;
        }

        float z = GetCollisionPos(transform.position, col.transform.position, col.collider.bounds.size.z);
        Vector3 dir = new Vector3(x, 0.5F, z).normalized;

        GetComponent<Rigidbody>().velocity = dir * speed;
    }

    private float GetCollisionPos(Vector3 ballPos, Vector3 racketPos, float racketLength)
    {
        return ((ballPos.z - racketPos.z) / racketLength);
    }
        
}