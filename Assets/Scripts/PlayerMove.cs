using UnityEngine;


//эта строчка гарантирует что наш скрипт не завалится 
//ести на плеере будет отсутствовать компонент Rigidbody
//[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] public Animator animator;
    DrawLevel drawLevel;

    //Crate crate;

    public bool IsPushing = false;
    bool isRotating = false;
    bool isMoving = false;
    int angle = 0;
    int destinationCount = 0; // Счетчик ящиков, поставленных на место назначения

    float moveHorizontal;
    float moveVertical;

    int newX;
    int newZ;
    int oldX;
    int oldZ;

    string[,] map;

    public Vector3 InterpolatedPosition;
    public Vector3 MoveVector;
    public int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;


    private void Start()
    {
        drawLevel = FindObjectOfType<DrawLevel>();
        //crate = FindObjectOfType<Crate>();

        map = drawLevel.getMap();

        if (map != null)
        {
            oldX = 1;
            oldZ = drawLevel.MapLength - 2;
            newX = 0;
            newZ = 0;
        }
    }


    void Update()
    {
        if (map == null) return;

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        if (isRotating)
        {
            RotatePlayer(angle);
            return;
        }


        if (moveHorizontal < 0 && !isMoving && !IsPushing)
        {
            moveVertical = 0;

            angle = 270;
            if (transform.eulerAngles.y != angle)
            {
                isRotating = true;
                return;
            }
            if (map[oldZ, oldX - 1] == " " || map[oldZ, oldX - 1] == "X")
            {
                newX = -1;
                isMoving = true;
                IsPushing = false;
            }
            else if (map[oldZ, oldX - 1] == "O" || map[oldZ, oldX - 1] == "V")
            {
                if (map[oldZ, oldX - 2] == " ")
                {
                    map[oldZ, oldX - 2] = "O";
                    if (map[oldZ, oldX - 1] == "V")
                    {
                        map[oldZ, oldX - 1] = "X";
                        destinationCount--;
                    }
                    else
                    {
                        map[oldZ, oldX - 1] = " ";
                    }
                    newX = -1;
                    isMoving = false;
                    IsPushing = true;
                }
                else if (map[oldZ, oldX - 2] == "X")
                {
                    map[oldZ, oldX - 2] = "V";
                    destinationCount++;

                    if (map[oldZ, oldX - 1] == "V")
                    {
                        map[oldZ, oldX - 1] = "X";
                        destinationCount--;
                    }
                    else
                    {
                        map[oldZ, oldX - 1] = " ";
                    }
                    newX = -1;
                    isMoving = false;
                    IsPushing = true;
                }
            }
        }

        if (moveHorizontal > 0 && !isMoving && !IsPushing)
        {
            moveVertical = 0;

            angle = 90;
            if (transform.eulerAngles.y != angle)
            {
                isRotating = true;
                return;
            }

            if (map[oldZ, oldX + 1] == " " || map[oldZ, oldX + 1] == "X")
            {

                newX = 1;
                isMoving = true;
                IsPushing = false;

            }
            else if (map[oldZ, oldX + 1] == "O" || map[oldZ, oldX + 1] == "V")
            {

                if (map[oldZ, oldX + 2] == " ")
                {
                    map[oldZ, oldX + 2] = "O";
                    if (map[oldZ, oldX + 1] == "V")
                    {
                        map[oldZ, oldX + 1] = "X";
                        destinationCount--;
                    }
                    else
                    {
                        map[oldZ, oldX + 1] = " ";
                    }

                    newX = 1;

                    isMoving = false;
                    IsPushing = true;
                }
                else if (map[oldZ, oldX + 2] == "X")
                {
                    map[oldZ, oldX + 2] = "V";
                    destinationCount++;
                    if (map[oldZ, oldX + 1] == "V")
                    {
                        map[oldZ, oldX + 1] = "X";
                        destinationCount--;
                    }
                    else
                    {
                        map[oldZ, oldX + 1] = " ";
                    }
                    newX = 1;

                    isMoving = false;
                    IsPushing = true;
                }
            }
        }

        if (moveVertical < 0 && !isMoving && !IsPushing)
        {
            moveHorizontal = 0;

            angle = 180;
            if (transform.eulerAngles.y != angle)
            {
                isRotating = true;
                return;
            }
            if (map[oldZ - 1, oldX] == " " || map[oldZ - 1, oldX] == "X")
            {
                newZ = -1;
                isMoving = true;
                IsPushing = false;
            }
            else if (map[oldZ - 1, oldX] == "O" || map[oldZ - 1, oldX] == "V")
            {
                if (map[oldZ - 2, oldX] == " ")
                {
                    map[oldZ - 2, oldX] = "O";

                    if (map[oldZ - 1, oldX] == "V")
                    {
                        map[oldZ - 1, oldX] = "X";
                        destinationCount--;
                    }
                    else
                    {
                        map[oldZ - 1, oldX] = " ";
                    }
                    newZ = -1;

                    isMoving = false;
                    IsPushing = true;
                }
                else if (map[oldZ - 2, oldX] == "X")
                {
                    map[oldZ - 2, oldX] = "V";
                    destinationCount++;

                    if (map[oldZ - 1, oldX] == "V")
                    {
                        map[oldZ - 1, oldX] = "X";
                        destinationCount--;
                    }
                    else
                    {
                        map[oldZ - 1, oldX] = " ";
                    }
                    newZ = -1;

                    isMoving = false;
                    IsPushing = true;
                }
            }
        }

        if (moveVertical > 0 && !isMoving && !IsPushing)
        {
            moveHorizontal = 0;

            angle = 0;
            if (transform.eulerAngles.y != angle)
            {
                isRotating = true;
                return;
            }
            if (map[oldZ + 1, oldX] == " " || map[oldZ + 1, oldX] == "X")
            {
                newZ = 1;
                isMoving = true;
                IsPushing = false;
            }
            else if (map[oldZ + 1, oldX] == "O" || map[oldZ + 1, oldX] == "V")
            {
                if (map[oldZ + 2, oldX] == " ")
                {
                    map[oldZ + 2, oldX] = "O";
                    if (map[oldZ + 1, oldX] == "V")
                    {
                        map[oldZ + 1, oldX] = "X";
                        destinationCount--;
                    }
                    else
                    {
                        map[oldZ + 1, oldX] = " ";
                    }
                    newZ = 1;

                    isMoving = false;
                    IsPushing = true;
                }
                else if (map[oldZ + 2, oldX] == "X")
                {
                    map[oldZ + 2, oldX] = "V";
                    destinationCount++;

                    if (map[oldZ + 1, oldX] == "V")
                    {
                        map[oldZ + 1, oldX] = "X";
                        destinationCount--;
                    }
                    else
                    {
                        map[oldZ + 1, oldX] = " ";
                    }
                    newZ = 1;

                    isMoving = false;
                    IsPushing = true;
                }
            }
        }


        //Debug.Log("destinationCount = " + destinationCount);



        bool isAnimation = animator.GetBool("Run");

        if (isMoving)
        {
            if (!isAnimation)
            {
                StartMoving();
            }
        }
        else
        {
            StopMoving();
        }

        isAnimation = animator.GetBool("Push");

        if (IsPushing)
        {
            if (!isAnimation)
            {
                StartPushing();
            }
        }
        else
        {
            StopPushing();
        }


        if (!isMoving && !IsPushing) return;


        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

        MoveVector = new Vector3(newX, 0, newZ);

        InterpolatedPosition = Vector3.Lerp(new Vector3(oldX, 0, oldZ), new Vector3(oldX + newX, 0, oldZ + newZ), interpolationRatio);

        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);
        if (elapsedFrames == 0)
        {
            if (IsPushing)
            {
                IsPushing = false;
            }

            isMoving = false;

            oldX += newX;
            oldZ += newZ;
            newX = 0;
            newZ = 0;
            //Debug.Log("Под ногами " + drawLevel.getMap()[oldZ, oldX].ToString());


            if (destinationCount == 3)
            {
                Debug.Log("Level complite!");
            }
        }

        transform.position = InterpolatedPosition;

    }

    void StartMoving()
    {
        isMoving = true;
        IsPushing = false;
        animator.SetBool("Run", true);
        interpolationFramesCount = 30;
    }

    void StopMoving()
    {
        animator.SetBool("Run", false);
    }

    void StartPushing()
    {
        isMoving = false;
        IsPushing = true;
        animator.SetBool("Push", true);
        interpolationFramesCount = 200;
    }

    void StopPushing()
    {
        animator.SetBool("Push", false);
    }

    void RotatePlayer(int angle)
    {
        Quaternion needRotation = Quaternion.Euler(0.0f, angle, 0.0f);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, needRotation, rotationSpeed * Time.deltaTime);
        if (Quaternion.Angle(transform.localRotation, needRotation) < 0.01f)
        {
            isRotating = false;
        }
    }



    public bool IsAnimationPlaying(string animationName)
    {
        // берем информацию о состоянии
        var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // смотрим, есть ли в нем имя какой-то анимации, то возвращаем true
        if (animatorStateInfo.IsName(animationName))
            return true;

        return false;
    }
}
