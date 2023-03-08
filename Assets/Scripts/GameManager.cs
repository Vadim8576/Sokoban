using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;


[System.Serializable]
public class GameData
{
    
    public int CurentLevel; // текущий уровень
    public int MapLength = 10; // длинна карты (кол-во строк)
    public int PlayerX; // Начальные координаты игрока
    public int PlayerZ;
    public int TotalDestinationCount = 0; // сколько язиков нужно поставить на место
    public int CurrentDestinationCount = 0; // сколько язиков поставлено в данный момент
    public bool isPaused = false;

    public static List<string>[] Maps = new List<string>[14] {
        new List<string>()
        {
            "##########",
            "#@       #",
            "#   #  O #",
            "###   #X##",
            "#        #",
            "#X## #####",
            "#   O   X#",
            "# ##O### #",
            "#        #",
            "##########"
        },

        new List<string>()
        {
            "##########",
            "##########",
            "####   ###",
            "## O # ###",
            "## #  X ##",
            "##    # ##",
            "### #   ##",
            "###@  ####",
            "##########",
            "##########"
        },

        new List<string>()
        {
            "##########",
            "#    #   #",
            "#    V ###",
            "# XO     #",
            "# O      #",
            "# X      #",
            "#######  #",
            "#        #",
            "#     @  #",
            "##########"
        },

        new List<string>()
        {
            "##########",
            "#    #   #",
            "#    V ###",
            "# XO     #",
            "# O      #",
            "# X      #",
            "#######  #",
            "#        #",
            "#     @  #",
            "##########"
        },

        new List<string>()
        {
            "##########",
            "#    #   #",
            "#    V ###",
            "# XO     #",
            "# O      #",
            "# X      #",
            "#######  #",
            "#        #",
            "#     @  #",
            "##########"
        },

        new List<string>()
        {
            "##########",
            "#    #   #",
            "#    V ###",
            "# XO     #",
            "# O      #",
            "# X      #",
            "#######  #",
            "#        #",
            "#     @  #",
            "##########"
        },

        new List<string>()
        {
            "##########",
            "#    #   #",
            "#    V ###",
            "# XO     #",
            "# O      #",
            "# X      #",
            "#######  #",
            "#        #",
            "#     @  #",
            "##########"
        },

        new List<string>()
        {
            "##########",
            "#    #   #",
            "#    V ###",
            "# XO     #",
            "# O      #",
            "# X      #",
            "#######  #",
            "#        #",
            "#     @  #",
            "##########"
        },

        new List<string>()
        {
            "##########",
            "#    #   #",
            "#    V ###",
            "# XO     #",
            "# O      #",
            "# X      #",
            "#######  #",
            "#        #",
            "#     @  #",
            "##########"
        },

        new List<string>()
        {
            "##########",
            "#    #   #",
            "#    V ###",
            "# XO     #",
            "# O      #",
            "# X      #",
            "#######  #",
            "#        #",
            "#     @  #",
            "##########"
        },

        new List<string>()
        {
            "##########",
            "#    #   #",
            "#    V ###",
            "# XO     #",
            "# O      #",
            "# X      #",
            "#######  #",
            "#        #",
            "#     @  #",
            "##########"
        },

        new List<string>()
        {
            "##########",
            "#    #   #",
            "#    V ###",
            "# XO     #",
            "# O      #",
            "# X      #",
            "#######  #",
            "#        #",
            "#     @  #",
            "##########"
        },

        new List<string>()
        {
            "##########",
            "#    #   #",
            "#    V ###",
            "# XO     #",
            "# O      #",
            "# X      #",
            "#######  #",
            "#        #",
            "#     @  #",
            "##########"
        },

        new List<string>()
        {
            "##########",
            "#    #   #",
            "#    V ###",
            "# XO     #",
            "# O      #",
            "# X      #",
            "#######  #",
            "#        #",
            "#     @  #",
            "##########"
        }
    };

    public int NumberOfLevels = Maps.Length; // кол-во уровней
}



public class GameManager : MonoBehaviour
{

    public GameData GameData;
    int MapLength;

    public static GameManager Instance; // Позволяет обращаться, например, NumberOfCoins = Progress.Instance.Coins;
    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

        GameData = new GameData();
    }

    private void Start()
    {
        MapLength = GameData.MapLength;
    }


    public void SetPlayerСoordinates(int x, int z)
    {
        GameData.PlayerX = x;
        GameData.PlayerZ = z;
    }

    public int GetPlayerX()
    {
        return GameData.PlayerX;
    }
    
    public int GetPlayerZ()
    {
        return GameData.PlayerZ;
    }
    
    
    public void Pause()
    {
        Time.timeScale = 0;
        GameData.isPaused = true;
    }
    
    public void Play()
    {
        Time.timeScale = 1;
        GameData.isPaused = false;
    }

    public bool GameIsPaused()
    {
        return GameData.isPaused;
    }


    
    public void SetCurrentLevel(int currentLevel)
    {
        GameData.CurentLevel = currentLevel;
    }
    public void SetNextLevel()
    {
        if(GameData.CurentLevel < GameData.NumberOfLevels)
        {
            GameData.CurentLevel++;
        }          
    }

    public int GetCurrentLevel()
    {
        return GameData.CurentLevel;
    }


    public void SetMapLength(int mapLength)
    {
        GameData.MapLength = mapLength;
    }

    public int GetMapLength()
    {
        return GameData.MapLength;
    }

    public int GetNumberOfLevels()
    {
        return GameData.NumberOfLevels;
    }

    public List<string>[] GetMaps()
    {
        return GameData.Maps;
    }



    public void TotalDestinationCountInc()
    {
        GameData.TotalDestinationCount++;
    }
    public void ResetTotalDestinationCount()
    {
        GameData.TotalDestinationCount = 0;
    }

    public int GetTotalDestinationCount()
    {
        return GameData.TotalDestinationCount;
    }

    public void CurrentDestinationCountInc()
    {
        GameData.CurrentDestinationCount++;
    }
    
    public void ResetCurrentDestinationCount()
    {
        GameData.CurrentDestinationCount = 0;
    }

    public void CurrentDestinationCountDec()
    {
        GameData.CurrentDestinationCount--;
    }

    public int GetCurrentDestinationCount()
    {
        return GameData.CurrentDestinationCount;
    }

    /*
    public void RestartLevel()
    {
        DestroyGameObjectsWithTag("DestroyedGameObject");
    }

    public static void DestroyGameObjectsWithTag(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);

        if (gameObjects.Length == 0) return;

        foreach (GameObject target in gameObjects)
        {
            Destroy(target);
        }
    }
    */

    public string[,] GetConvertMap(int level, string replaceSymbol = "")
    {
        string[,] ConvertMap = new string[MapLength, MapLength];

        for (int z = 0; z < MapLength; z++)
        {
            for (int x = 0; x < MapLength; x++)
            {
                int zz = (MapLength - 1) - z;
                
               
                string substring = GameData.Maps[level][z].Substring(x, 1);

                if (substring == replaceSymbol)
                {
                    substring = " ";
                }

                ConvertMap[zz, x] = substring;

                if (replaceSymbol == "@") continue;

                if(substring == "X" || substring == "V")
                {
                    TotalDestinationCountInc();
                }
            }
        }

        Debug.Log("GameManager TotalDestinationCount = " + GetTotalDestinationCount());

        return ConvertMap;
    }
}
