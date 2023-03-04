using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public int CurentLevel; // текущий уровень
    public int MapLength = 10; // длинна карты (кол-во строк)
    public int PlayerX; // Начальные координаты игрока
    public int PlayerZ;

    public static List<string>[] Maps = new List<string>[3] {
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
    
    
    public void SetCurrentLevel(int currentLevel)
    {
        GameData.CurentLevel = currentLevel;
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
            }
        }
        return ConvertMap;
    }
}
