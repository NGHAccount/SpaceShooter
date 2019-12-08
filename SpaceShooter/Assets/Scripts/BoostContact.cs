using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostContact : MonoBehaviour
{

    private GameController gameController;
    private Mover mover;
    public float newSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {

            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("cant find this");
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKey("F"))
        {
            mover.speed = -1f;
        }
        
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            mover.speed = -2f;
            Destroy(this);
        }
        
    }
    */

    
}
