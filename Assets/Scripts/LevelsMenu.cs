using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    Levels Levels;

    public Transform panel;
    public Font font;

    void Start()
    {
        Levels = FindObjectOfType<Levels>();

        //if (Levels == null) return;

        //Debug.Log("TotalNumberOfLevels = " + Levels.TotalNumberOfLevels());

        /*
        for(int i = 0; i < Maps.TotalNumberOfLevels(); i++)
        {
            CreateButton(i);
        }
        */

        CreateButton(1);
    }


    void CreateButton(int number)
    {
        GameObject newButton = new GameObject("New button", typeof(Image), typeof(Button), typeof(LayoutElement));
        
        newButton.transform.SetParent(panel);
        newButton.transform.position = new Vector3(newButton.transform.position.x, newButton.transform.position.y, panel.transform.position.z);
             
        RectTransform rtb = newButton.GetComponent<RectTransform>();
       
        rtb.sizeDelta = new Vector2 (160.0f, 35.0f);
        rtb.localScale = new Vector2(1.0f, 1.0f);

        GameObject text = new GameObject("Text", typeof(Text));

        text.transform.SetParent(newButton.transform);
        text.GetComponent<Text>().text = "Level " + number.ToString();
        text.GetComponent<Text>().font = font;
        text.GetComponent<Text>().color = new Color(0, 0, 0);
        text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        RectTransform rtt = text.GetComponent<RectTransform>();

        rtt.anchorMin = new Vector2(0, 0);
        rtt.anchorMax = new Vector2(1, 1);
        rtt.anchoredPosition = new Vector2(0, 0);
        rtt.sizeDelta = new Vector2(0, 0);
        rtt.localScale = new Vector2(1.0f, 1.0f);

        newButton.GetComponent<Button>().onClick.AddListener(delegate { Press(); });



        //НЕ РАБОТАЕТ!!!!!! 
        // Вызвать метод другого объекта
        //newButton.GetComponent<Button>().onClick.AddListener(delegate { GameObject.Find("Main Camera").GetComponent < "LevelSelection" > ().CreateButton(); });


    }


    public void Press()
    {
        SceneManager.LoadScene(1);
    }
}
