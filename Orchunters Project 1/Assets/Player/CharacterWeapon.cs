using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{

    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;

    private void Update()
    {

        bool isPlayerTurn = playerTurn.IsPlayerTurn();
        if (Input.GetKeyDown(KeyCode.Mouse0))

            if (isPlayerTurn)
        {
                Vector3 force = transform.forward * 500f + transform.up * 100f;
                GameObject newProjectile = Instantiate(projectilePrefab);
                newProjectile.transform.position = shootingStartPosition.position;
                newProjectile.GetComponent<Projectile>().Initialize(force);
                
            }
    }

}
