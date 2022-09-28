using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private PlayerTurn playerthree;
    [SerializeField] private PlayerTurn playerfour;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] UnitStats unitstats;
    [SerializeField] GameUi ui;
      private bool turned;
    private int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;
    public int currentPlayerIndexscript;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
            playerOne.SetPlayerTurn(1);
            playerTwo.SetPlayerTurn(2);
            playerthree.SetPlayerTurn(3);
            playerfour.SetPlayerTurn(4);
        }
    }

    private void Update()
    {
        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 60;
                waitingForNextTurn = false;
                ChangeTurn();
            }
        }

       
    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        {
            return false;
        }

        return index == currentPlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void TriggerChangeTurn()
    {
        waitingForNextTurn = true;
    }

    private void ChangeTurn()
    {
        turned = false;
        if (currentPlayerIndex == 1 && (turned == false))
        {
            currentPlayerIndex = 2;
            turned = true;
            for (int i = 3; i <= 5; i++)
            {
                UnitStats currentUnitStats = ui.playerUnits[i].GetComponent<UnitStats>();
                currentUnitStats.unitActionpoints = 10f;
                currentUnitStats.defend = false;
            }

        }
        if (currentPlayerIndex == 2 && (turned == false))
        {
            currentPlayerIndex = 3;
            turned = true;
            for (int i = 6; i <= 8; i++)
            {
                UnitStats currentUnitStats = ui.playerUnits[i].GetComponent<UnitStats>();
                currentUnitStats.unitActionpoints = 10f;
                currentUnitStats.defend = false;
            }
        }
        if (currentPlayerIndex == 3 && (turned == false))
        {
            currentPlayerIndex = 4;
            turned = true;
            for (int i = 9; i <= 11; i++)
            {
                UnitStats currentUnitStats = ui.playerUnits[i].GetComponent<UnitStats>();
                currentUnitStats.unitActionpoints = 10f;
                currentUnitStats.defend = false;
            }
        }
        if (currentPlayerIndex == 4 && (turned == false))
        {
            currentPlayerIndex = 1;
            turned = true;
            for (int i = 0; i <= 2; i++)
            {
                UnitStats currentUnitStats = ui.playerUnits[i].GetComponent<UnitStats>();
                currentUnitStats.unitActionpoints = 10f;
                currentUnitStats.defend = false;
            }
        }






    }
}