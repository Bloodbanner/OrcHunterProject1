
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private int playerIndex;
    [SerializeField] private int unitIndex;


    // Start is called before the first frame update  
    void Start()
    {

    }

    // Update is called once per frame  
    void Update()
    {
        if(TurnManager.GetInstance().IsItPlayerTurn(playerIndex))




        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * 5f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * 5f * Time.deltaTime);
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
     
}
