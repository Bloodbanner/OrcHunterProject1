using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    [SerializeField] private GameObject damageIndicatorsPrefab;


    private bool isActive;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 direction)
    {
        isActive = true;
        projectileBody.AddForce(direction);        
    }


    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            gameObject.transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        GameObject damageIndicator = Instantiate(damageIndicatorsPrefab);
        damageIndicator.transform.position = collision.GetContact(0).point;


    }



}