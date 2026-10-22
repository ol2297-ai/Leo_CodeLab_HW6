using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ball : MonoBehaviour
{
    public float rotationSpeed;
    public Vector3 VE;
    public Rigidbody2D RB2;
    InputAction LFT;
    bool STARTGAME = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LFT = InputSystem.actions.FindAction("L");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        if (LFT.WasReleasedThisFrame() && STARTGAME == false)
        {
            STARTGAME = true;
        }
        if (STARTGAME==true )
        {
            MOVEE();
        }
       
    }
    void MOVEE()
    {
        
        RB2.MovePosition(transform.position + VE*Time.deltaTime);
    }
    void BOUNCE()
    {
        VE.y = -VE.y;
        VE.x = Random.Range(50, -50);
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        BOUNCE();
        if (other.gameObject .CompareTag("BACK"))
        {
            Destroy(other.gameObject);
        }
    }

}
