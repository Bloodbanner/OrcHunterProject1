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
    [SerializeField] PlayerMovement playerMovement;
    public GameObject whosattacking;
    public float power = 500f;
    public float height = 100f;
    private void Start()
    {
       
    }
         
   
    private void Update()
    {
        
        bool isPlayerTurn = playerTurn.IsPlayerTurn();
        if (whosattacking.GetComponent<GameUi>().attack == true)
        {
            
            if (whosattacking.GetComponent<CharacterWeapon>().isAttacking == false)
            {
                whosattacking.GetComponent<GameUi>().attack = false;
                animator.SetTrigger("Attack");
                StartCoroutine(Test());
                whosattacking.GetComponent<CharacterWeapon>().isAttacking = true;
                playerMovement.canmove = false;

            }


        }
        if (Input.GetKey(KeyCode.Q))
        {
            ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().power = ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().power + 25f * Time.deltaTime;
           
            if (ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().power < 50)
            {
                ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().power = 50f;
            }
            if (ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().power > 1000f)
            {
                ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().power = 1000f;
            }
        }
        if (Input.GetKey(KeyCode.Z))
        {
            ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().power = ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().power - 25f * Time.deltaTime;
           
            if (ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().power < 50)
            {
                ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().power = 50f;
            }
            if (ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().power > 1000f)
            {
                ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().power = 1000f;
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().height = ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().height + 10f * Time.deltaTime;
            
            if (ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().height < 5)
            {
                ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().height = 5f;
            }
            if (ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().height > 500f)
            {
                ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().height = 500f;
            }
        }
        if (Input.GetKey(KeyCode.C))
        {
            ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().height = ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().height - 10f * Time.deltaTime;
           
            if (ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().height < 5)
            {
                ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().height = 5f;
            }
            if (ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().height > 500f)
            {
                ui.playerUnits[ui.selectedunit].GetComponent<CharacterWeapon>().height = 500f;
            }
        }


    }


    IEnumerator Test()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 force = transform.forward * whosattacking.GetComponent<CharacterWeapon>().power + transform.up * whosattacking.GetComponent<CharacterWeapon>().height;
        GameObject newProjectile = Instantiate(projectilePrefab, shootingStartPosition.position, Quaternion.Euler(force));
        newProjectile.GetComponent<Projectile>().Initialize(force);
        
        yield return new WaitForSeconds(3f);
        whosattacking.GetComponent<CharacterWeapon>().isAttacking = false;
        playerMovement.canmove = true;
        whosattacking.GetComponent<GameUi>().isAttackingDontAllowAttacking = true;
    }




}