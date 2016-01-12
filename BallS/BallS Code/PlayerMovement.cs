using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour 
{

    public float speed;
    private Rigidbody rb;
	public float JumpHeight = 260.0f;
	bool FloorTouch;
	bool HasPowerJump, HasPowerSpeed = false;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
		
		
		if (Input.GetKeyDown ("space") && FloorTouch == true)
		{
			transform.Translate(Vector3.up * JumpHeight * Time.deltaTime, Space.World);
			FloorTouch = false;
		} 
		
		
		
		/*if (Input.GetKeyDown ("LeftControl") && HasPowerSpeed == true)
		{
			transform.Translate(Vector3 * 1300.0f * Time.deltaTime, Space.World);
			HasPowerSpeed = false;
		}*/
		
		
		
		if (Input.GetKeyDown ("LeftControl") && HasPowerJump == true)
		{
			transform.Translate(Vector3 * 1300.0f * Time.deltaTime, Space.World);
			HasPowerJump = false;
		}
		
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }
	
	void OnCollisionEnter(Collision Other) 
	{
		if (Other.gameObject.name == "Floor")
		{
			FloorTouch = true;
		}
	}
	
	void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("PogoUp", "SpeedUp"))
        {
            Time.deltaTime other.gameObject.SetActive (false) ;
        }
    }
}