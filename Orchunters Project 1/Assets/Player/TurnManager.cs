using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;

    public int currentPlayerIndex;
    public int currentUnitIndex;


    private void Awake()
    {
        if (instance == null)

        {
            instance = this;
            currentPlayerIndex = 1;
            currentUnitIndex = 1;
        }

    }

    public bool IsItPlayerTurn(int index)

    {
        return index == currentPlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
        }
        if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 3;
        }
        if (currentPlayerIndex == 3)
        {
            currentPlayerIndex = 4;
        }
        if (currentPlayerIndex == 4)
        {
            currentPlayerIndex = 1;
        }





    }



}
