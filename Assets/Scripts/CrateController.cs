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
        if(isPushing && player.IsPushing)
        {
            transform.position = player.InterpolatedPosition + player.MoveVector;       
        }
    }


    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.tag == "Player" && !isPushing)
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
        if (other.gameObject.tag == "Player" && isPushing)
        {
            isPushing = false;

            float x = Mathf.Round(transform.position.x);
            float z = Mathf.Round(transform.position.z);

            transform.position = new Vector3(x, 0.0f, z);
        }   
    }

}
