using UnityEngine;

public class CrateController : MonoBehaviour
{
    [SerializeField] GameObject particle;
    PlayerController player = null;


    private void Update()
    {
        if(player && player.IsPushing)
        {
            transform.position = player.InterpolatedPosition + player.MoveVector;       
        }
    }


    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.tag == "Player" && !player)
        {
            player = other.attachedRigidbody.GetComponent<PlayerController>();
            Debug.Log("Trigger");

            if (!particle.activeSelf)
            {
                particle.SetActive(true);
            }
        }    
    }


    private void OnTriggerExit(Collider other)
    {   
        if (other.gameObject.tag == "Player" && player)
        {
            StopPushing();
        }   
    }

    public void StopPushing()
    {
        player = null;

        if (particle.activeSelf)
        {
            particle.SetActive(false);
        }

        float x = Mathf.Round(transform.position.x);
        float z = Mathf.Round(transform.position.z);
       
        transform.position = new UnityEngine.Vector3(x, 0.0f, z);
    }

}
