using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    public float Speed;
    public Joystick joystick;
    Vector2 move;
    public Rigidbody2D rb;
    public Animator _animator;
    float _z;
    float z;
    float __z;
    
    public float new_speed = 20f;
    public float old_speed = 10f;
    
    bool isFlying = false;
    
    public float flyTime = 10f;
    
    void Update()
    {

        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;

        float hAxis = joystick.Horizontal;
        float vAxis = joystick.Vertical;

        z = Mathf.Atan2(-hAxis, vAxis) * Mathf.Rad2Deg;//+90f or -90 if rotation is wrong

        if (z != 0)
        {
            _z = z;
            __z = z;
        }
        else
        {
            _z = __z;
        }
        Vector2 movement = (new Vector2(move.x, move.y)).normalized * Speed;
        rb.velocity = movement;

        if (movement.magnitude > Mathf.Epsilon)
        {
            _animator.SetBool("Moving", true);
        }
        else
        {
            _animator.SetBool("Moving", false);
        }
        
        
        if(CrossPlatformInputManager.GetButtonDown("FlyButton")&&isFlying == false)
        {
              StartCoroutine(flyfunction());
        }
        
    }
    void FixedUpdate()
    {
        rb.rotation = _z;//also here you can do this+ 90 or -90 or -_z

    }
    IEnumerator flyfunction()
    {
        isFlying = true;
        Speed = new_speed;
        yield return new WaitForSeconds(flyTime);
        Speed = old_speed;
        isFlying = false;
    {

}
