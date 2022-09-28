using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool canmove = true;
    [SerializeField] UnitStats unitstats;
    [SerializeField]
    private int playerIndex;
    public int unitIndex;
    public GameUi gameUi;
    [SerializeField] private Animator animatorRun;

    Rigidbody m_Rigidbody;
    public float m_Speed;
    
    // Start is called before the first frame update  
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame  
    void FixedUpdate()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex) && gameUi.IsUnitsTurn(unitIndex))
        {

            if (unitstats.unitActionpoints > 0)
            {
                if (canmove == true)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        m_Rigidbody.velocity = transform.forward * m_Speed * Time.deltaTime;

                        animatorRun.SetBool("Run", true);
                        unitstats.unitActionpoints = unitstats.unitActionpoints - Time.deltaTime;
                    }
                    if (Input.GetKeyUp(KeyCode.W))
                    {
                        animatorRun.SetBool("Run", false);
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        m_Rigidbody.velocity = transform.forward *-1 * m_Speed * Time.deltaTime;
                        animatorRun.SetBool("Back", true);
                        unitstats.unitActionpoints = unitstats.unitActionpoints - Time.deltaTime;
                    }
                    if (Input.GetKeyUp(KeyCode.S))
                    {
                        animatorRun.SetBool("Back", false);
                    }

                    if (Input.GetKey(KeyCode.A))
                    {
                        this.transform.Rotate(Vector3.up, -0.8f);
                    }

                    if (Input.GetKey(KeyCode.D))
                    {
                        this.transform.Rotate(Vector3.up, 0.8f);
                    }

                    if (unitstats.unitActionpoints <= 0)
                    {
                        animatorRun.SetBool("Run", false);
                        animatorRun.SetBool("Back", false);
                    }

                    if (canmove == false)
                    {
                        animatorRun.SetBool("Run", false);
                        animatorRun.SetBool("Back", false);
                    }
                }
                
            }
            if (unitstats.unitActionpoints <= 0)
            {
                animatorRun.SetBool("Run", false);
                animatorRun.SetBool("Back", false);
            }

            if (canmove == false) 
            {
                animatorRun.SetBool("Run", false);
                animatorRun.SetBool("Back", false);
            }
            
            


        }

    }
}