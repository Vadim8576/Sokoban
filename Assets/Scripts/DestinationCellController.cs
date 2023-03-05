using UnityEngine;


public class DestinationCellController : MonoBehaviour
{
    GameManager GameManager;
    Component[] rends;
    Renderer rend;

    

    private void Awake()
    {
        rends = gameObject.GetComponentsInChildren<Renderer>(true);
        rend = (Renderer)rends[0];
    }

    private void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        CrateController crateController = other.attachedRigidbody.GetComponent<CrateController>();

        if (crateController && rend)
        {
            GameManager.CurrentDestinationCountInc();
            //PrintInfo();

            rend.material.color = Color.green;
            //rend.material.EnableKeyword("_EMISSION");
            rend.material.SetVector("_EmissionColor", new Vector4(0.0f, 1.0f, 0f, 1f) * 2f);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        CrateController crateController = other.attachedRigidbody.GetComponent<CrateController>();
        if (crateController && rend)
        {
            GameManager.CurrentDestinationCountDec();

            //PrintInfo();

            rend.material.color = Color.red;
            //rend.material.EnableKeyword("_EMISSION");
            rend.material.SetVector("_EmissionColor", new Vector4(1.0f, 0.0f, 0f, 1f) * 2f);
        }
    }


    private void PrintInfo()
    {
        Debug.Log("Total Destination Count = " + GameManager.GetTotalDestinationCount());
        Debug.Log("Current Destination Count = " + GameManager.GetCurrentDestinationCount());
    }
}
