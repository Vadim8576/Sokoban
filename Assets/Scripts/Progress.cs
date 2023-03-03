using UnityEngine;



[System.Serializable]
public class GameInfo
{
    public int CurentLevel;
}



public class Progress : MonoBehaviour
{



    public GameInfo GameInfo;

    public static Progress Instance; // Позволяет обращаться, например, NumberOfCoins = Progress.Instance.Coins;
    void Awake()
    {
       
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);

            // Загружаем данные с сервера Яндекс
            //LoadExtern();
        }
        else
        {
            Destroy(gameObject);
        }

        GameInfo = new GameInfo();
    }

   
}
