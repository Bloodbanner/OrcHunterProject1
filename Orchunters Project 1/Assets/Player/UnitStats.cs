using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    [SerializeField] private int UnitMaxHealth = 100;
    private int UnitCurrentHealth ;
    [SerializeField] private float unitDamageMin = 5f;
    [SerializeField] private float unitDamageMax = 10f;
    [SerializeField] private int unitActionpoints = 100;
    [SerializeField] private GameObject unit;

    void start()
    {
        UnitCurrentHealth = UnitMaxHealth;
    }


   





 }



