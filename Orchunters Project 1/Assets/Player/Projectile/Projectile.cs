using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    private bool isActive;

    public void Initialize()
    {
        isActive = true;
        projectileBody.AddForce((transform.forward * 400f + transform.up * -40f ));
    }


    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
           
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;
        
    }



}