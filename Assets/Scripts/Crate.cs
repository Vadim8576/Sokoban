using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField] GameObject particle;
    PlayerMove playerMove = null;

    private void Update()
    {
        if(playerMove && playerMove.IsPushing)
        {
            transform.position = playerMove.InterpolatedPosition + playerMove.MoveVector;       
        }
    }


    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.tag == "Player" && !playerMove)
        {
            playerMove = other.attachedRigidbody.GetComponent<PlayerMove>();
            Debug.Log("Trigger");

            if (!particle.activeSelf)
            {
                particle.SetActive(true);
            }
        }    
    }


    private void OnTriggerExit(Collider other)
    {   
        if (other.gameObject.tag == "Player" && playerMove)
        {
            StopPushing();
        }   
    }

    public void StopPushing()
    {
        playerMove = null;

        if (particle.activeSelf)
        {
            particle.SetActive(false);
        }

        float x = Mathf.Round(transform.position.x);
        float z = Mathf.Round(transform.position.z);
       
        transform.position = new UnityEngine.Vector3(x, 0.0f, z);
    }

}
