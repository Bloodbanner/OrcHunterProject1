using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [SerializeField] private Image endtextbutton;
    [SerializeField] private Image unit1;
    [SerializeField] private Image unit2;
    [SerializeField] private Image unit3;
    [SerializeField] private Button endTurnButton;
    [SerializeField] private Button unit1Button;
    [SerializeField] private Button unit2Button;
    [SerializeField] private Button unit3Button;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI damage;
    [SerializeField] private TextMeshProUGUI actionpoint;



    //getting info from other script
    private int currentUnitIndex;

    private object currentPlayerIndex;

    private void Start()
    {
        currentUnitIndex = 1;
        endTurnButton.onClick.AddListener(EndTurnButtonPressed);
        unit1Button.onClick.AddListener(delegate { UnitButtonPressed(1); });
        unit2Button.onClick.AddListener(delegate { UnitButtonPressed(2); });
        unit3Button.onClick.AddListener(delegate { UnitButtonPressed(3); });

    }


    public void EndTurnButtonPressed()
    {

        TurnManager.GetInstance().TriggerChangeTurn();
        Debug.Log(currentPlayerIndex);

    }
    public void UnitButtonPressed(int index)
    {
        currentUnitIndex = index;
        Debug.Log(currentUnitIndex);
    }

    public bool IsUnitsTurn(int unitIndex)
    {
        return currentUnitIndex == unitIndex;
    }
}