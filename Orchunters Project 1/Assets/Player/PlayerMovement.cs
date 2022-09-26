using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool canmove= true;
    [SerializeField] UnitStats unitstats;
    [SerializeField]
    private int playerIndex;
    public int unitIndex;
    public GameUi gameUi;
    [SerializeField] private Animator animatorRun;
    // Start is called before the first frame update  
    void Start()
    {

    }

    // Update is called once per frame  
    void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex) && gameUi.IsUnitsTurn(unitIndex))
        {

            if (unitstats.unitActionpoints > 0)
            {
                if (canmove == true)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        this.transform.Translate(Vector3.forward * 5f * Time.deltaTime);
                        animatorRun.SetBool("Run", true);
                        unitstats.unitActionpoints = unitstats.unitActionpoints - Time.deltaTime;
                    }
                    if (Input.GetKeyUp(KeyCode.W))
                    {
                        animatorRun.SetBool("Run", false);
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        this.transform.Translate(Vector3.back * 5f * Time.deltaTime);
                        animatorRun.SetBool("Back", true);
                        unitstats.unitActionpoints = unitstats.unitActionpoints - Time.deltaTime;
                    }
                    if (Input.GetKeyUp(KeyCode.S))
                    {
                        animatorRun.SetBool("Back", false);
                    }

                    if (Input.GetKey(KeyCode.A))
                    {
                        this.transform.Rotate(Vector3.up, -0.5f);
                    }

                    if (Input.GetKey(KeyCode.D))
                    {
                        this.transform.Rotate(Vector3.up, 0.5f);
                    }

                }
                if (unitstats.unitActionpoints <= 0 )
                {
                    animatorRun.SetBool("Run", false);
                    animatorRun.SetBool("Back", false);
                }
            }

            if (canmove == false)
            {
                animatorRun.SetBool("Run", false);
                animatorRun.SetBool("Back", false);
            }
               


        }
     
    }
}