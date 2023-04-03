using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rigid;
    void Start ()
    {
        print("Start");
        rigid = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(new Vector2(0, 7), ForceMode.Impulse);
            print("Jump");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position -= new Vector3(speed, 0, 0);
        }
    }
}
