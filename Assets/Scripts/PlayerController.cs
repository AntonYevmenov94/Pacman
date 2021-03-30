using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject point;
    private Rigidbody rigidbody;
    private float speed;
    private float turnspeed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        turnspeed = 25f;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Point")
        {
            Destroy(collision.gameObject);
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rigidbody.MovePosition(rigidbody.position + Vector3.right * horizontal * Time.deltaTime * speed);
        rigidbody.MovePosition(rigidbody.position + Vector3.forward * vertical * Time.deltaTime * speed);
        if (horizontal < 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * turnspeed);
        if (horizontal > 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * turnspeed);
        if (vertical > 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * turnspeed);
        if (vertical < 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * turnspeed);

    }

}
