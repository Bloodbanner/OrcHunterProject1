using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Cinemachine;

public class GameUi : MonoBehaviour
{
    [SerializeField] private Sprite Player1flag;
    [SerializeField] private Sprite Player2flag;
    [SerializeField] private Sprite Player3flag;
    [SerializeField] private Sprite Player4flag;
    [SerializeField] private Image playerTurnFlag;
    [SerializeField] private Image endtextbutton;
    [SerializeField] private Sprite unit1Dead;
    [SerializeField] private Sprite unit2Dead;
    [SerializeField] private Sprite unit3Dead;
    [SerializeField] private Button endTurnButton;
    [SerializeField] private Button unit1Button;
    [SerializeField] private Button unit2Button;
    [SerializeField] private Button unit3Button;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI damage;
    [SerializeField] private TextMeshProUGUI actionpoint;
    [SerializeField] private TextMeshProUGUI playerturnname;


    [SerializeField] CinemachineVirtualCamera cameraplayer1unit1;
    [SerializeField] CinemachineVirtualCamera cameraplayer1unit2;
    [SerializeField] CinemachineVirtualCamera cameraplayer1unit3;
    [SerializeField] CinemachineVirtualCamera cameraplayer2unit1;
    [SerializeField] CinemachineVirtualCamera cameraplayer2unit2;
    [SerializeField] CinemachineVirtualCamera cameraplayer2unit3;
    [SerializeField] CinemachineVirtualCamera cameraplayer3unit1;
    [SerializeField] CinemachineVirtualCamera cameraplayer3unit2;
    [SerializeField] CinemachineVirtualCamera cameraplayer3unit3;
    [SerializeField] CinemachineVirtualCamera cameraplayer4unit1;
    [SerializeField] CinemachineVirtualCamera cameraplayer4unit2;
    [SerializeField] CinemachineVirtualCamera cameraplayer4unit3;
    private int cameraInt = 1;





    //getting info from other script
    private int currentUnitIndex;

    private int currentPlayerIndex;
    private int playerturnint;

    private void Start()
    {
        playerturnint = 1;
        currentUnitIndex = 1;
        endTurnButton.onClick.AddListener(EndTurnButtonPressed);
        unit1Button.onClick.AddListener(delegate { UnitButtonPressed(1); });
        unit2Button.onClick.AddListener(delegate { UnitButtonPressed(2); });
        unit3Button.onClick.AddListener(delegate { UnitButtonPressed(3); });
        cameraplayer1unit1.m_Priority = cameraInt;
        cameraplayer1unit2.m_Priority = cameraInt;
        cameraplayer1unit3.m_Priority = cameraInt;
        cameraplayer1unit1.m_Priority = cameraInt;
        cameraplayer2unit2.m_Priority = cameraInt;
        cameraplayer2unit3.m_Priority = cameraInt;
        cameraplayer2unit1.m_Priority = cameraInt;
        cameraplayer3unit2.m_Priority = cameraInt;
        cameraplayer3unit1.m_Priority = cameraInt;
        cameraplayer3unit3.m_Priority = cameraInt;
        cameraplayer4unit1.m_Priority = cameraInt;
        cameraplayer4unit2.m_Priority = cameraInt;
        cameraplayer4unit3.m_Priority = cameraInt;
        playerturnname.text = "Red Stalion";
    }


    public void EndTurnButtonPressed()
    {

        TurnManager.GetInstance().TriggerChangeTurn();

        playerturnint++;

        if (playerturnint >= 5)
        {
            playerturnint = 1;
        }

        
        UnitButtonPressed(1);
        UnitButtonPressed(1);
        ImageChange();
        
    }
    public void UnitButtonPressed(int index)
    {
        currentUnitIndex = index;
        Debug.Log(currentUnitIndex);
        Debug.Log(playerturnint);

        if (playerturnint == 1)
        {
            if (currentUnitIndex == 1)
            {
                cameraplayer1unit1.m_Priority = cameraInt++; 
            }
            if (currentUnitIndex == 2)
            {
                cameraplayer1unit2.m_Priority = cameraInt++;
            }
            if (currentUnitIndex == 3)
            {
                cameraplayer1unit3.m_Priority = cameraInt++;
            }
        }
        if (playerturnint == 2)
        {
            if (currentUnitIndex == 1)
            {
                cameraplayer2unit1.m_Priority = cameraInt++;
            }
            if (currentUnitIndex == 2)
            {
                cameraplayer2unit2.m_Priority = cameraInt++;
            }
            if (currentUnitIndex == 3)
            {
                cameraplayer2unit3.m_Priority = cameraInt++;
            }
        }
        if (playerturnint == 3)
        {
            if (currentUnitIndex == 1)
            {
                cameraplayer3unit1.m_Priority = cameraInt++;
            }
            if (currentUnitIndex == 2)
            {
                cameraplayer3unit2.m_Priority = cameraInt++;
            }
            if (currentUnitIndex == 3)
            {
                cameraplayer3unit3.m_Priority = cameraInt++;
            }
        }
        if (playerturnint == 4)
        {
            if (currentUnitIndex == 1)
            {
                cameraplayer4unit1.m_Priority = cameraInt++;
            }
            if (currentUnitIndex == 2)
            {
                cameraplayer4unit2.m_Priority = cameraInt++;
            }
            if (currentUnitIndex == 3)
            {
                cameraplayer4unit3.m_Priority = cameraInt++;
            }
        }
    }

    public bool IsUnitsTurn(int unitIndex)
    {
        return currentUnitIndex == unitIndex;
    }

    public void ImageChange()
    {
        if (playerturnint == 1)
        {
            playerTurnFlag.sprite = Player1flag;
            playerturnname.text = "Red Stalion";
        }
        if (playerturnint == 2)
        {
            playerTurnFlag.sprite = Player2flag;
            playerturnname.text = "Blue Eagle";
        }
        if (playerturnint == 3)
        {
            playerTurnFlag.sprite = Player3flag;
            playerturnname.text = "Green Moose";
        }
        if (playerturnint == 4)
        {
            playerTurnFlag.sprite = Player4flag;
            playerturnname.text = "Purple Centaur";
        }



    }
}
