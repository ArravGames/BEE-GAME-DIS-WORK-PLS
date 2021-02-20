using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkAnimation : MonoBehaviour
{

    static Animator walk;
    public float speed = 2.0f;
    public float rotationSpeed = 75.0f;

    // Start is called before the first frame update
    void Start()
    {
        walk = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation != 0)
        {
            walk.SetBool("Walking", true);
        }
        else
        {
            walk.SetBool("Walking", false);
        }
    }
}
