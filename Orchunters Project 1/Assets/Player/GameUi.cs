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
    private object currentPlayerIndex;

    private void Start()
    {
        endTurnButton.onClick.AddListener(OnButtonPressed);
    }


    public void OnButtonPressed()
        {

         TurnManager.GetInstance().TriggerChangeTurn();
        Debug.Log(currentPlayerIndex);

        }














}
