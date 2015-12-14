using UnityEngine;
using System.Collections;

public class CarPlayer : MonoBehaviour {

    public float m_Speed = 12f;
    public float m_TurnSpeed;
    public Camera MainCamera;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    public SpriteRenderer carRenderer;
    private float carSize;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        //carSize = carRenderer.bounds.size.x;
    }

    void FixedUpdate()
    {
        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");
        Move();
        Turn();
        MainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }

    private void Nitro()
    {
        if (Input.GetButton("Nitro"))
        {
            m_Speed = 24f;
        }
        else {
            m_Speed = 12f;
        }
    }

    private void Move()
    {
        //Nitro();
        Vector3 movement = transform.up * m_MovementInputValue * m_Speed * Time.deltaTime;        
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);        
    }


    private void Turn()
    {
        if (m_MovementInputValue != 0)
        {
            float turn = (m_TurnInputValue * -1) * m_TurnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, 0f, turn);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 8){
            m_Speed = 6f;
        }
        if (collision.gameObject.layer == 9){
            m_Speed = 0f;
        }
    }

    private void OnCollisionExit(Collision collision) 
    {
        Debug.Log(collision.gameObject.layer);
        //switch (collision.gameObject.layer){
            //default:
                m_Speed = 12f;
                //break;
        //}
    }
}
