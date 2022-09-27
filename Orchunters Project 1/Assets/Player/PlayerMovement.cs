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
    private float m_Speed = 50f;
    private float m_RotationSpeed;
    // Start is called before the first frame update  
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame  
    void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex) && gameUi.IsUnitsTurn(unitIndex))
        {

            if (unitstats.unitActionpoints > 0)
            {
                float movementForward = Input.GetAxis("Vertical") * m_Speed * Time.deltaTime;
                float rotation = Input.GetAxis("Horizontal") * m_RotationSpeed * Time.deltaTime;
                
               
                if (!Mathf.Approximately(Mathf.Abs(movementForward), 0.0f) || !Mathf.Approximately(Mathf.Abs(rotation), 0.0f))
                {
                    unitstats.unitActionpoints = unitstats.unitActionpoints - Time.deltaTime;
                    Debug.Log("Velocity: " + m_Rigidbody.velocity);
                    Debug.Log(transform.forward * movementForward);
                    // forward and back movement
                    m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y, movementForward);
                    // rotation
                    Vector3 rotationAngle = Vector3.up * rotation;
                    Quaternion deltaRotation = Quaternion.Euler(rotationAngle);
                    m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
                    
                    
                }

            }
            else
            {
                m_Rigidbody.velocity = new Vector3(0.0f, m_Rigidbody.velocity.y, 0.0f);
            }
        }
        else
        {
            m_Rigidbody.velocity = new Vector3(0.0f, m_Rigidbody.velocity.y, 0.0f);
        }

        animatorRun.SetFloat("movementV", m_Rigidbody.velocity.z);
    }
}