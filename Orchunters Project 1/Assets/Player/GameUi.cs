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
    [SerializeField] private Image unit1Deadimage;
    [SerializeField] private Image unit2Deadimage;
    [SerializeField] private Image unit3Deadimage;
    [SerializeField] private Sprite unitDead;
    [SerializeField] private Button endTurnButton;
    [SerializeField] private Button AttackButton;
    [SerializeField] private Button DefendButton;
    [SerializeField] private Button unit1Button;
    [SerializeField] private Button unit2Button;
    [SerializeField] private Button unit3Button;
    [SerializeField] private TextMeshProUGUI health;    
    [SerializeField] private TextMeshProUGUI actionpoint;
    [SerializeField] private TextMeshProUGUI playerturnname;
    [SerializeField] private TextMeshProUGUI arrowPowertext;
    [SerializeField] private TextMeshProUGUI arrowHeightext;
    public List<GameObject> playerUnits = new List<GameObject>();
    [SerializeField] public TextMeshProUGUI combatlog;


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

    public GameObject defendshield;
    private int cameraInt = 0;
    public bool attack;
    public int selectedunit;
    public bool isAttackingDontAllowAttacking = true;


    //getting info from other script
    [SerializeField] Projectile projectile;
    [SerializeField] UnitStats unitStats;
    [SerializeField] CharacterWeapon characterWeapon;
    public int Wichunit;
    public int currentUnitIndex;
    public int currentPlayerIndex;
    private int playerturnint;

    private void Start()
    {
        playerturnint = 1;
        currentUnitIndex = 1;
        endTurnButton.onClick.AddListener(EndTurnButtonPressed);
        AttackButton.onClick.AddListener(AttackButtonPressed);
        DefendButton.onClick.AddListener(DefendButtonPressed);
        unit1Button.onClick.AddListener(delegate { UnitButtonPressed(1); });
        unit2Button.onClick.AddListener(delegate { UnitButtonPressed(2); });
        unit3Button.onClick.AddListener(delegate { UnitButtonPressed(3); });
        cameraplayer1unit1.m_Priority = cameraInt++;
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
        UnitButtonPressed(1);
        UnitButtonPressed(1);
        
    }
    public void AttackButtonPressed()
    {

        if (playerturnint == 1 || playerturnint == 2 || playerturnint == 3 || playerturnint == 4)
        {

            if (playerturnint == 1 && currentUnitIndex == 1)
            {
                Wichunit = 0;
            }
            if (playerturnint == 1 && currentUnitIndex == 2)
            {
                Wichunit = 1;
            }
            if (playerturnint == 1 && currentUnitIndex == 3)
            {
                Wichunit = 2;
            }
            if (playerturnint == 2 && currentUnitIndex == 1)
            {
                Wichunit = 3;
            }
            if (playerturnint == 2 && currentUnitIndex == 2)
            {
                Wichunit = 4;
            }
            if (playerturnint == 2 && currentUnitIndex == 3)
            {
                Wichunit = 5;
            }
            if (playerturnint == 3 && currentUnitIndex == 1)
            {
                Wichunit = 6;
            }
            if (playerturnint == 3 && currentUnitIndex == 2)
            {
                Wichunit = 7;
            }
            if (playerturnint == 3 && currentUnitIndex == 3)
            {
                Wichunit = 8;
            }
            if (playerturnint == 4 && currentUnitIndex == 1)
            {
                Wichunit = 9;
            }
            if (playerturnint == 4 && currentUnitIndex == 2)
            {
                Wichunit = 10;
            }
            if (playerturnint == 4 && currentUnitIndex == 3)
            {
                Wichunit = 11;
            }



            UnitStats currentUnitStats = playerUnits[Wichunit].GetComponent<UnitStats>();

            if (currentUnitStats.unitActionpoints >= 2)
            {

                if (playerUnits[Wichunit].GetComponent<GameUi>().isAttackingDontAllowAttacking == true)
                {
                    playerUnits[Wichunit].GetComponent<GameUi>().attack = true;
                    currentUnitStats.unitActionpoints = currentUnitStats.unitActionpoints - 2;
                    playerUnits[Wichunit].GetComponent<GameUi>().isAttackingDontAllowAttacking = false;
                }
            }

        }

    }


    public void EndTurnButtonPressed()
    {

        TurnManager.GetInstance().TriggerChangeTurn();

        playerturnint++;

        if (playerturnint >= 5)
        {
            playerturnint = 1;

        }

        ImageChange();
        
    }
    public void UnitButtonPressed(int index)
    {
        currentUnitIndex = index;
       

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
            UnitButtonPressed(1);
        }
        if (playerturnint == 2)
        {
            playerTurnFlag.sprite = Player2flag;
            playerturnname.text = "Blue Eagle";
            UnitButtonPressed(1);
        }
        if (playerturnint == 3)
        {
            playerTurnFlag.sprite = Player3flag;
            playerturnname.text = "Green Moose";
            UnitButtonPressed(1);
        }
        if (playerturnint == 4)
        {
            playerTurnFlag.sprite = Player4flag;
            playerturnname.text = "Purple Centaur";
            UnitButtonPressed(1);
        }




    }





    public void Update()
    {
        if (playerturnint == 1)
        {
            if (currentUnitIndex == 1)
            {
                selectedunit = 0;
                UnitStats currentUnitStats = playerUnits[0].GetComponent<UnitStats>();
                if (currentUnitStats.unitCurrentHealth > 0)
                {
                    health.text = currentUnitStats.unitCurrentHealth.ToString() + "/" + currentUnitStats.unitMaxHealth.ToString();
                    actionpoint.text = currentUnitStats.unitActionpoints.ToString("F1");
                    arrowPowertext.text = "Arrow Power: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().power).ToString();
                    arrowHeightext.text = "Arrow Height: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().height).ToString();

                }
                else     
                {
                    unit1Deadimage.sprite = unitDead;
                    unit1Deadimage.color = new Color(1, 1, 1, 1);
                }
            }

            if (currentUnitIndex == 2)
            {
                selectedunit = 1;
                UnitStats currentUnitStats = playerUnits[1].GetComponent<UnitStats>();
                if (currentUnitStats.unitCurrentHealth > 0)
                {
                    health.text = currentUnitStats.unitCurrentHealth.ToString() + "/" + currentUnitStats.unitMaxHealth.ToString();
                    actionpoint.text = currentUnitStats.unitActionpoints.ToString("F1");
                    arrowPowertext.text = "Arrow Power: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().power).ToString();
                    arrowHeightext.text = "Arrow Height: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().height).ToString();

                }
                else
                {
                    unit2Deadimage.sprite = unitDead;
                    unit2Deadimage.color = new Color(1, 1, 1, 1);
                }
            }

            if (currentUnitIndex == 3)
            {
                selectedunit = 2;

                UnitStats currentUnitStats = playerUnits[2].GetComponent<UnitStats>();
                if (currentUnitStats.unitCurrentHealth > 0)
                {
                    health.text = currentUnitStats.unitCurrentHealth.ToString() + "/" + currentUnitStats.unitMaxHealth.ToString();
                    actionpoint.text = currentUnitStats.unitActionpoints.ToString("F1");
                    arrowPowertext.text = "Arrow Power: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().power).ToString();
                    arrowHeightext.text = "Arrow Height: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().height).ToString();
                }

            }
        }
        if (playerturnint == 2)
        {
            if (currentUnitIndex == 1)
            {
                selectedunit = 3;
                UnitStats currentUnitStats = playerUnits[3].GetComponent<UnitStats>();
                if (currentUnitStats.unitCurrentHealth > 0)
                {
                    health.text = currentUnitStats.unitCurrentHealth.ToString() + "/" + currentUnitStats.unitMaxHealth.ToString();
                    actionpoint.text = currentUnitStats.unitActionpoints.ToString("F1");
                    arrowPowertext.text = "Arrow Power: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().power).ToString();
                    arrowHeightext.text = "Arrow Height: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().height).ToString();
                }
            }

            if (currentUnitIndex == 2)
            {
                selectedunit = 4;
                UnitStats currentUnitStats = playerUnits[4].GetComponent<UnitStats>();
                if (currentUnitStats.unitCurrentHealth > 0)
                {
                    health.text = currentUnitStats.unitCurrentHealth.ToString() + "/" + currentUnitStats.unitMaxHealth.ToString();
                    actionpoint.text = currentUnitStats.unitActionpoints.ToString("F1");
                    arrowPowertext.text = "Arrow Power: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().power).ToString();
                    arrowHeightext.text = "Arrow Height: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().height).ToString();
                }
            }

            if (currentUnitIndex == 3)
            {
                selectedunit = 5;
                UnitStats currentUnitStats = playerUnits[5].GetComponent<UnitStats>();
                if (currentUnitStats.unitCurrentHealth > 0)
                {
                    health.text = currentUnitStats.unitCurrentHealth.ToString() + "/" + currentUnitStats.unitMaxHealth.ToString();
                    actionpoint.text = currentUnitStats.unitActionpoints.ToString("F1");
                    arrowPowertext.text = "Arrow Power: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().power).ToString();
                    arrowHeightext.text = "Arrow Height: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().height).ToString();
                }
            }
        }
        if (playerturnint == 3)
        {
            if (currentUnitIndex == 1)
            {
                selectedunit = 6;
                UnitStats currentUnitStats = playerUnits[6].GetComponent<UnitStats>();
                if (currentUnitStats.unitCurrentHealth > 0)
                {
                    health.text = currentUnitStats.unitCurrentHealth.ToString() + "/" + currentUnitStats.unitMaxHealth.ToString();
                    actionpoint.text = currentUnitStats.unitActionpoints.ToString("F1");
                    arrowPowertext.text = "Arrow Power: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().power).ToString();
                    arrowHeightext.text = "Arrow Height: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().height).ToString();
                }
            }

            if (currentUnitIndex == 2)
            {
                selectedunit = 7;
                UnitStats currentUnitStats = playerUnits[7].GetComponent<UnitStats>();
                if (currentUnitStats.unitCurrentHealth > 0)
                {
                    health.text = currentUnitStats.unitCurrentHealth.ToString() + "/" + currentUnitStats.unitMaxHealth.ToString();
                    actionpoint.text = currentUnitStats.unitActionpoints.ToString("F1");
                    arrowPowertext.text = "Arrow Power: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().power).ToString();
                    arrowHeightext.text = "Arrow Height: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().height).ToString();
                }
            }

            if (currentUnitIndex == 3)
            {
                selectedunit = 8;
                UnitStats currentUnitStats = playerUnits[8].GetComponent<UnitStats>();
                if (currentUnitStats.unitCurrentHealth > 0)
                {
                    health.text = currentUnitStats.unitCurrentHealth.ToString() + "/" + currentUnitStats.unitMaxHealth.ToString();
                    actionpoint.text = currentUnitStats.unitActionpoints.ToString("F1");
                    arrowPowertext.text = "Arrow Power: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().power).ToString();
                    arrowHeightext.text = "Arrow Height: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().height).ToString();
                }
            }
        }
        if (playerturnint == 4)
        {
            if (currentUnitIndex == 1)
            {
                selectedunit = 9;
                UnitStats currentUnitStats = playerUnits[9].GetComponent<UnitStats>();
                if (currentUnitStats.unitCurrentHealth > 0)
                {
                    health.text = currentUnitStats.unitCurrentHealth.ToString() + "/" + currentUnitStats.unitMaxHealth.ToString();
                    actionpoint.text = currentUnitStats.unitActionpoints.ToString("F1");
                    arrowPowertext.text = "Arrow Power: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().power).ToString();
                    arrowHeightext.text = "Arrow Height: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().height).ToString();
                }
            }

            if (currentUnitIndex == 2)
            {
                selectedunit = 10;
                UnitStats currentUnitStats = playerUnits[10].GetComponent<UnitStats>();
                if (currentUnitStats.unitCurrentHealth > 0)
                {
                    health.text = currentUnitStats.unitCurrentHealth.ToString() + "/" + currentUnitStats.unitMaxHealth.ToString();
                    actionpoint.text = currentUnitStats.unitActionpoints.ToString("F1");
                    arrowPowertext.text = "Arrow Power: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().power).ToString();
                    arrowHeightext.text = "Arrow Height: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().height).ToString();
                }
            }

            if (currentUnitIndex == 3)
            {
                UnitStats currentUnitStats = playerUnits[11].GetComponent<UnitStats>();
                selectedunit = 11;
                if (currentUnitStats.unitCurrentHealth > 0)
                {
                    health.text = currentUnitStats.unitCurrentHealth.ToString() + "/" + currentUnitStats.unitMaxHealth.ToString();
                    actionpoint.text = currentUnitStats.unitActionpoints.ToString("F1");
                    arrowPowertext.text = "Arrow Power: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().power).ToString();
                    arrowHeightext.text = "Arrow Height: " + Mathf.RoundToInt(currentUnitStats.GetComponent<CharacterWeapon>().height).ToString();
                }
            }
        }

    }
    public void DefendButtonPressed()
    {

        UnitStats currentUnitStats = playerUnits[selectedunit].GetComponent<UnitStats>();

        if (currentUnitStats.unitActionpoints > 3)
        {
            currentUnitStats.defend = currentUnitStats.defend = true;
            currentUnitStats.unitActionpoints = currentUnitStats.unitActionpoints - 3;
        }
    }
   
}
