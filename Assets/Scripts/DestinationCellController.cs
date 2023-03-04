using UnityEngine;


public class DestinationCellController : MonoBehaviour
{
    Component[] rends;
    Renderer rend; 

    private void Awake()
    {
        rends = gameObject.GetComponentsInChildren<Renderer>(true);
        rend = (Renderer)rends[0];
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Crate" && rend)
        {
            
            rend.material.color = Color.green;
            //rend.material.EnableKeyword("_EMISSION");
            rend.material.SetVector("_EmissionColor", new Vector4(0.0f, 1.0f, 0f, 1f) * 2f);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Crate" && rend)
        {
            rend.material.color = Color.red;
            //rend.material.EnableKeyword("_EMISSION");
            rend.material.SetVector("_EmissionColor", new Vector4(1.0f, 0.0f, 0f, 1f) * 2f);
        }
    }
}
