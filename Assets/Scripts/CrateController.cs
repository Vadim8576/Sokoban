using UnityEngine;

public class CrateController : MonoBehaviour
{
    //[SerializeField] GameObject particle;
    PlayerController player;

    bool isPushing = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }



    private void Update()
    {
        if (isPushing && player.IsPushing)
        {
            transform.position = player.transform.position + player.MoveVector;
        } 

        if(isPushing && !player.IsPushing)
        {
            float roundX = Mathf.Round(transform.position.x);
            float roundZ = Mathf.Round(transform.position.z);
       
            transform.position = new Vector3(roundX, 0.0f, roundZ);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        //PlayerController playerController = other.attachedRigidbody.GetComponent<PlayerController>();

        if (other.gameObject.tag == "Player" && !isPushing)
        //if (playerController && !isPushing)
        {

            isPushing = true;

            Debug.Log("Trigger");

            /*
            if (!particle.activeSelf)
            {
                particle.SetActive(true);
            }
            */
        }
    }


    private void OnTriggerExit(Collider other)
    {
        //PlayerController playerController = other.attachedRigidbody.GetComponent<PlayerController>();
        //if (playerController && !isPushing)
        if (other.gameObject.tag == "Player" && isPushing)
        {
            isPushing = false;


        }
    }

}
