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
    [SerializeField] public int unitSelected;
    private object currentPlayerIndex;

    private void Start()
    {
        endTurnButton.onClick.AddListener(EndTurnButtonPressed);
        unit1Button.onClick.AddListener(Unit1ButtonPressed);
        unit2Button.onClick.AddListener(Unit2ButtonPressed);
        unit3Button.onClick.AddListener(Unit3ButtonPressed);
    }




    public void EndTurnButtonPressed()
        {

         TurnManager.GetInstance().TriggerChangeTurn();
        Debug.Log(currentPlayerIndex);

        }
    public void Unit1ButtonPressed()
    {
       unitSelected = unitSelected = 1;
        
    }
    public void Unit2ButtonPressed()
    {
        unitSelected = unitSelected = 2;
    }
    public void Unit3ButtonPressed()
    {
        unitSelected = unitSelected = 3;
    }







    public void Update()
    {
        
    }



}
