using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    bool isAttacking = false;
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;
    public GameUi ui;
    [SerializeField] private Animator animator;

    private void Start()
    {
       
    }
         
   
    private void Update()
    {

        bool isPlayerTurn = playerTurn.IsPlayerTurn();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        { 
            if (isPlayerTurn)
            {
                if (isAttacking == false)
                {
                    animator.SetTrigger("Attack");
                    StartCoroutine(Test());
                    isAttacking = true;
                }               
            }
        }
    }


    IEnumerator Test()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 force = transform.forward * 500f + transform.up * 100f;
        GameObject newProjectile = Instantiate(projectilePrefab, shootingStartPosition.position, Quaternion.Euler(force));
        newProjectile.GetComponent<Projectile>().Initialize(force);
        yield return new WaitForSeconds(4f);
        isAttacking = false;
    }




}