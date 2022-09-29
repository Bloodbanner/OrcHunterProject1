using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    [SerializeField] private GameObject damageIndicatorsPrefab;
    [SerializeField] UnitStats unitstats;
    [SerializeField] GameUi ui;
    private bool isActive;
    public int damagemade;
   

    private void Start()
    {
        projectileBody = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 direction)
    {
        isActive = true;
        projectileBody.AddForce(direction);
        gameObject.transform.rotation = Quaternion.LookRotation(direction);
    }

    // Update is called once per frame
    void Update()
    {
        // MathF.Abs Will change the float if its a negative number to a positive. we just want to check if the number isn't 0.
        if (isActive && (Mathf.Abs(projectileBody.velocity.x) > 0 || Mathf.Abs(projectileBody.velocity.y) > 0 || Mathf.Abs(projectileBody.velocity.z) > 0))
        {
            gameObject.transform.rotation = Quaternion.LookRotation(projectileBody.velocity, Vector3.up);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {       
        Destroy(this.gameObject);
        GameObject damageIndicator = Instantiate(damageIndicatorsPrefab);
        damageIndicator.transform.position = collision.GetContact(0).point;
        if (collision.gameObject.CompareTag("Player"))
        {
            UnitStats currentUnitStats = collision.gameObject.GetComponent<UnitStats>();
            if (currentUnitStats.defend == true)
            {
                damagemade = (Random.Range(currentUnitStats.unitDamageMin, currentUnitStats.unitDamageMax));
                currentUnitStats.unitCurrentHealth = currentUnitStats.unitCurrentHealth - damagemade/2;
            }
            else if (currentUnitStats.defend == false)
            {
                damagemade = (Random.Range(currentUnitStats.unitDamageMin, currentUnitStats.unitDamageMax));
                currentUnitStats.unitCurrentHealth = currentUnitStats.unitCurrentHealth - damagemade;
            }
            
        }
        
                      
        
    }
   

}