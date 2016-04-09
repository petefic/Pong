using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour
{

    public float speed;

    private GameObject ballObj;

    // Update is called once per frame
    void Update ()
    {
        if (GameObject.FindGameObjectWithTag("Ball") != null)
        {
            ballObj = GameObject.FindGameObjectWithTag("Ball");
            int ballZ = Mathf.RoundToInt(ballObj.transform.position.z);
            int paddleZ = Mathf.RoundToInt(gameObject.transform.position.z);

            if (ballZ % 2 == 1) { ballZ++; }
            if (paddleZ % 2 == 1) { paddleZ++; }

            if (ballZ > paddleZ)
            {
                //dir = 1F;
                GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
            }
            else if (ballZ < paddleZ)
            {
                //dir = -1F;
                GetComponent<Rigidbody>().velocity = Vector3.back * speed;
            }

        }   
    }

    public void Reset()
    {
        transform.position = new Vector3(15F, 1F, 0F);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

}