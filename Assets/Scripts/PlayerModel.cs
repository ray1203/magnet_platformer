using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody;
    public float speed = -200f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.AddTorque(-200);
    }



}
