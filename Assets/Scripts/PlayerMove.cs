using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

//-0.06199998

//эта строчка гарантирует что наш скрипт не завалится 
//ести на плеере будет отсутствовать компонент Rigidbody
//[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] public Animator _animator;
    DrawLevel _drawLevel;

    public bool _push = false;
    bool _isRotating = false;
    int _angle = 0;
    public float moveHorizontal;
    public float moveVertical;

    /*
    string[] map = {
        "##########",
        "#   O    #",
        "#   #    #",
        "###   #X##",
        "#        #",
        "#X## #####",
        "#   O   X#",
        "# ##O### #",
        "#        #",
        "##########"
    };
    */
    private string[,] map;

    int newX;
    int newZ;
    int oldX;
    int oldZ;


    bool isMoving = false;

    public int interpolationFramesCount = 20; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;

    private void Start()
    {
        _drawLevel = FindObjectOfType<DrawLevel>();

        map = _drawLevel.getMap();

        if (map != null)
        {
            Debug.Log("Длина массива = " + map.GetLength(0));
            Debug.Log("Длина массива = " + map.GetLength(1));
            oldX = 1;
            oldZ = _drawLevel.MapLength - 2;
            newX = 0;
            newZ = 0;

            Debug.Log("Ящик " + map[5, 7].ToString());


            for (int z = 0; z < 10; z++)
            {
                string line = "";
                for (int x = 0; x < 10; x++)
                {
                    line += map[z, x].ToString();
                    //Debug.Log(map[z, x].ToString());
                }
                Debug.Log(line);
            }


        }
    }


    void Update()
    {

        if (map == null) return;

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        if (_isRotating)
        {
            RotatePlayer(_angle);
            return;
        }

        /*
                if (moveHorizontal < 0 && map[oldZ, oldX - 1] == "#" && !isMoving && !_isRotating)
                {
                    _animator.SetBool("Push", true);
                }
        */

        if (moveHorizontal < 0 && !isMoving)
        {
            moveVertical = 0;

            _angle = 270;
            if (transform.eulerAngles.y != _angle)
            {
                _isRotating = true;
                return;
            }
            if (map[oldZ, oldX - 1] == " " || map[oldZ, oldX - 1] == "X")
            {
                newX = -1;
                isMoving = true;
            }
            else if (map[oldZ, oldX - 1] == "O" || map[oldZ, oldX - 1] == "V")
            {
                if (map[oldZ, oldX - 2] == " ")
                {
                    map[oldZ, oldX - 2] = "O";
                    if (map[oldZ, oldX - 1] == "V")
                    {
                        map[oldZ, oldX - 1] = "X";
                    }
                    else
                    {
                        map[oldZ, oldX - 1] = " ";
                    }
                    newX = -1;
                    isMoving = true;
                }
                else if (map[oldZ, oldX - 2] == "X")
                {
                    map[oldZ, oldX - 2] = "V";
                    if (map[oldZ, oldX - 1] == "V")
                    {
                        map[oldZ, oldX - 1] = "X";
                    }
                    else
                    {
                        map[oldZ, oldX - 1] = " ";
                    }
                    newX = -1;
                    isMoving = true;
                }
            }

        }

        if (moveHorizontal > 0 && !isMoving)
        {
            moveVertical = 0;

            _angle = 90;
            if (transform.eulerAngles.y != _angle)
            {
                _isRotating = true;
                return;
            }




            if (map[oldZ, oldX + 1] == " " || map[oldZ, oldX + 1] == "X")
            {
                
                newX = 1;
                isMoving = true;
            }
            else if (map[oldZ, oldX + 1] == "O" || map[oldZ, oldX + 1] == "V")
            {
                
                if (map[oldZ, oldX + 2] == " ")
                {
                    map[oldZ, oldX + 2] = "O";
                    if (map[oldZ, oldX + 1] == "V")
                    {
                        map[oldZ, oldX + 1] = "X";
                    }
                    else
                    {
                        map[oldZ, oldX + 1] = " ";
                    }
                    newX = 1;
                    isMoving = true;

                    
                    
                }
                else if (map[oldZ, oldX + 2] == "X")
                {
                    map[oldZ, oldX + 2] = "V";
                    if (map[oldZ, oldX + 1] == "V")
                    {
                        map[oldZ, oldX + 1] = "X";
                    }
                    else
                    {
                        map[oldZ, oldX + 1] = " ";
                    }
                    newX = 1;
                    isMoving = true;

                    
                }
            }
        }

        if (moveVertical < 0 && !isMoving)
        {
            moveHorizontal = 0;

            _angle = 180;
            if (transform.eulerAngles.y != _angle)
            {
                _isRotating = true;
                return;
            }
            if (map[oldZ - 1, oldX] == " " || map[oldZ - 1, oldX] == "X")
            {
                newZ = -1;
                isMoving = true;
            }
            else if (map[oldZ - 1, oldX] == "O" || map[oldZ - 1, oldX] == "V")
            {
                if (map[oldZ - 2, oldX] == " ")
                {
                    map[oldZ - 2, oldX] = "O";

                    if (map[oldZ - 1, oldX] == "V")
                    {
                        map[oldZ - 1, oldX] = "X";
                    }
                    else
                    {
                        map[oldZ - 1, oldX] = " ";
                    }
                    newZ = -1;
                    isMoving = true;
                }
                else if (map[oldZ - 2, oldX] == "X")
                {
                    map[oldZ - 2, oldX] = "V";
                    if (map[oldZ - 1, oldX] == "V")
                    {
                        map[oldZ - 1, oldX] = "X";
                    }
                    else
                    {
                        map[oldZ - 1, oldX] = " ";
                    }
                    newZ = -1;
                    isMoving = true;
                }
            }
        }

        if (moveVertical > 0 && !isMoving)
        {
            moveHorizontal = 0;

            _angle = 0;
            if (transform.eulerAngles.y != _angle)
            {
                _isRotating = true;
                return;
            }
            if (map[oldZ + 1, oldX] == " " || map[oldZ + 1, oldX] == "X")
            {
                newZ = 1;
                isMoving = true;
            }
            else if (map[oldZ + 1, oldX] == "O" || map[oldZ + 1, oldX] == "V")
            {
                if (map[oldZ + 2, oldX] == " ")
                {
                    map[oldZ + 2, oldX] = "O";
                    if (map[oldZ + 1, oldX] == "V")
                    {
                        map[oldZ + 1, oldX] = "X";
                    }
                    else
                    {
                        map[oldZ + 1, oldX] = " ";
                    }
                    newZ = 1;
                    isMoving = true;
                }
                else if (map[oldZ + 2, oldX] == "X")
                {
                    map[oldZ + 2, oldX] = "V";
                    if (map[oldZ + 1, oldX] == "V")
                    {
                        map[oldZ + 1, oldX] = "X";
                    }
                    else
                    {
                        map[oldZ + 1, oldX] = " ";
                    }
                    newZ = 1;
                    isMoving = true;
                }
            }
        }


        if (isMoving)
        {
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
            return;
        }


        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
        Vector3 interpolatedPosition = Vector3.Lerp(new Vector3(oldX, 0, oldZ), new Vector3(oldX + newX, 0, oldZ + newZ), interpolationRatio);

        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);
        if (elapsedFrames == 0)
        {
            isMoving = false;
            oldX += newX;
            oldZ += newZ;
            newX = 0;
            newZ = 0;
            //Debug.Log("oldZ = " + oldZ + " oldX = " + oldX);
            Debug.Log("Под ногами " + _drawLevel.getMap()[oldZ, oldX].ToString());
        }

        transform.position = interpolatedPosition;
    }


    void RotatePlayer(int angle)
    {
        Quaternion needRotation = Quaternion.Euler(0.0f, angle, 0.0f);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, needRotation, 500 * Time.deltaTime);
        if (Quaternion.Angle(transform.localRotation, needRotation) < 0.01f)
        {
            _isRotating = false;
        }
    }
}
