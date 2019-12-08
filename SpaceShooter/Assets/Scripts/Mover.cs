using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private GameController controller;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        

        //Made by Nick Hennessy 
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            //speed = -10;
            GameObject.FindGameObjectsWithTag("Enemy");
            rb.velocity = rb.velocity * 1.04f;

        }
    }
}