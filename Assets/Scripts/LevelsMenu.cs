using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    //Levels Levels;
    GameManager GameManager;
   
    public Transform panel;
    public Font font;

    void Start()
    {
        //Levels = FindObjectOfType<Levels>();
        GameManager = FindObjectOfType<GameManager>();;
    
        for (int i = 0; i < GameManager.GetNumberOfLevels(); i++)
        {
            CreateButton(i);
        }
        
    }


    void CreateButton(int level)
    {
        GameObject newButton = new GameObject("New button", typeof(Image), typeof(Button), typeof(LayoutElement));

        newButton.transform.SetParent(panel);
        newButton.transform.position = new Vector3(newButton.transform.position.x, newButton.transform.position.y, panel.transform.position.z);

        RectTransform rtb = newButton.GetComponent<RectTransform>();

        rtb.sizeDelta = new Vector2(160.0f, 35.0f);
        rtb.localScale = new Vector2(1.0f, 1.0f);

        GameObject text = new GameObject("Text", typeof(Text));

        text.transform.SetParent(newButton.transform);
        text.GetComponent<Text>().text = "Level " + (level + 1).ToString();
        text.GetComponent<Text>().font = font;
        text.GetComponent<Text>().color = new Color(0, 0, 0);
        text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        RectTransform rtt = text.GetComponent<RectTransform>();

        rtt.anchorMin = new Vector2(0, 0);
        rtt.anchorMax = new Vector2(1, 1);
        rtt.anchoredPosition = new Vector2(0, 0);
        rtt.sizeDelta = new Vector2(0, 0);
        rtt.localScale = new Vector2(1.0f, 1.0f);

        newButton.GetComponent<Button>().onClick.AddListener(delegate { Press(level); });

        

        //НЕ РАБОТАЕТ!!!!!! 
        // Вызвать метод другого объекта
        //newButton.GetComponent<Button>().onClick.AddListener(delegate { GameObject.Find("Main Camera").GetComponent < "LevelSelection" > ().CreateButton(); });


    }

    
    public void Press(int level)
    {

        Debug.Log("Level = " + level);

        GameManager.SetCurrentLevel(level);

        Debug.Log("GameManager.GetCurrentLevel = " + GameManager.GetCurrentLevel());

        SceneManager.LoadScene(1);
    }
    
}
