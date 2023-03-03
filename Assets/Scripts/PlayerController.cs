using UnityEngine;


//эта строчка гарантирует что наш скрипт не завалитс€ 
//ести на плеере будет отсутствовать компонент Rigidbody
//[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject particle;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] public Animator animator;

    Levels Levels;


    public bool IsPushing = false;
    bool isRotating = false;
    bool isMoving = false;
    int angle = 0;
    int destinationCount = 0; // —четчик €щиков, поставленных на место назначени€

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

    bool isAnimation;


    int CurrentLevel = 0;


    private void Start()
    {
        Levels = FindObjectOfType<Levels>();

        map = Levels.GetConvertMap(CurrentLevel);

        if (map != null)
        {
            oldX = 1;
            oldZ = Levels.MapLength - 2;
            newX = 0;
            newZ = 0;
        }

        transform.localEulerAngles = new Vector3(0, -180, 0);
    }


    void Update()
    {
        if (map == null) return;


        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }


        isAnimation = animator.GetBool("Push");

        if (isRotating && !isAnimation)
        {
           
           RotatePlayer(angle);

            return;
        }
        else if (isRotating && isAnimation)
        {
            StopPushing();
            return;
        }


        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        
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



        isAnimation = animator.GetBool("Run");

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


            if (destinationCount == 3)
            {
                Debug.Log("Level complite!");
                particle.SetActive(true);
            }
            else
            {
                particle.SetActive(false);
            }
        }

        transform.position = InterpolatedPosition;

    }

    void StartMoving()
    {
        animator.SetBool("Run", true);
        interpolationFramesCount = 27;
    }

    void StopMoving()
    {
        animator.SetBool("Run", false);
    }

    void StartPushing()
    {
        animator.SetBool("Push", true);
        interpolationFramesCount = 150;
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
        // берем информацию о состо€нии
        var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // смотрим, есть ли в нем им€ какой-то анимации, то возвращаем true
        if (animatorStateInfo.IsName(animationName))
            return true;

        return false;
    }
}
