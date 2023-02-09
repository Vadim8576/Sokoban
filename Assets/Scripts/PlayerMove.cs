using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

//test

//эта строчка гарантирует что наш скрипт не завалитс€ 
//ести на плеере будет отсутствовать компонент Rigidbody
//[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    
    [SerializeField] private float _speed;
    [SerializeField] public Animator _animator;

    public bool _push = false;
    bool _isRotating = false;
    int _angle = 0;
    public float moveHorizontal;
    public float moveVertical;

    // все действи€ с физикой необходимо обрабатывать в FixedUpdate, а не в Update
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        
        // Start/Stop animations
        if ((Mathf.Abs(moveHorizontal) > 0 || Mathf.Abs(moveVertical) > 0) && !_push)
        {
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }

        // «апрет перемещени€ по другим ос€м
        if (Mathf.Abs(moveHorizontal) > 0)
        {
            moveVertical = 0;
        }

        if (Mathf.Abs(moveVertical) > 0)
        {
            moveHorizontal = 0;
        }

        // –азворот персонажа
        if (moveHorizontal > 0)
        {
            _angle = 90;
            if (transform.eulerAngles.y != _angle) _isRotating = true;
        }
        else if (moveHorizontal < 0)
        {
            _angle = 270;
            if (transform.eulerAngles.y != _angle) _isRotating = true;
        }
        else if (moveVertical > 0)
        {
            _angle = 0;
            if (transform.eulerAngles.y != _angle) _isRotating = true;
        }
        else if (moveVertical < 0)
        {
            _angle = 180;
            if (transform.eulerAngles.y != _angle) _isRotating = true;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (_isRotating)
        {
            RotatePlayer(_angle);
        }
        else
        {
            float k = 1f;
            if (_push)
            {
                k = 0.3f;
            }
            

            transform.position += movement * Time.deltaTime * _speed * k;
        }



        if(_animator.GetBool("Push"))
        {
            //Debug.Log("position = " + transform.position);
            
        }
        
        //Debug.Log("moveHorizontal = " + moveHorizontal);
        //Debug.Log("moveVertical = " + moveVertical);

    }

    private void RotatePlayer(int angle)
    {

        Debug.Log("RotatePlayer");
        Quaternion needRotation = Quaternion.Euler(0.0f, angle, 0.0f);
        // update
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, needRotation, 500 * Time.deltaTime);
        if (Quaternion.Angle(transform.localRotation, needRotation) < 0.01f)
        {
            // finish
            _isRotating = false;
        }
    }


    
}
