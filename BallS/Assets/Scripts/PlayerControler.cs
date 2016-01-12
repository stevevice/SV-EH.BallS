using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    bool FloorTouch;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("space") && FloorTouch == true)
        {
            transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
            FloorTouch = false;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision Other)
    {
        if (Other.gameObject.name == "Floor")
        {
            FloorTouch = true;
        }
    }
}