using System.Collections.Generic;
using UnityEngine;


/*
public class MapsList
{
    public List<string>[] Maps = new List<string>[2] {
        new List<string>()
        {
            "##########",
            "#        #",
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
            "#       ##",
            "#   #  O #",
            "###   #X##",
            "#        #",
            "#X## #####",
            "#   O   X#",
            "# ##O### #",
            "#        #",
            "##########"
        }
    };

    public List<string> GetMap(int level)
    {
       
        return Maps[level];
    }
}


*/


public class Levels : MonoBehaviour
{
    //public MapsList MapsList;
    public static int MapLength = 10;



    public List<string>[] Maps = new List<string>[2] {
        new List<string>()
        {
            "##########",
            "#        #",
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
            "#       ##",
            "#   #  O #",
            "###   #X##",
            "#        #",
            "#X## #####",
            "#   O   X#",
            "# ##O### #",
            "#        #",
            "##########"
        }
    };



    public static Levels Instance;
    
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
    }
    



    public string[,] GetConvertMap(int level)
    {
       

        //Debug.Log(MapsList.GetMap(0));

        string[,] ConvertMap = new string[MapLength, MapLength];

        for (int z = 0; z < MapLength; z++)
        {
            for (int x = 0; x < MapLength; x++)
            {
                int zz = (MapLength - 1) - z;

                //string map = MapsList.Maps[level][z].Substring(x, 1);
                //string map = MapsList.GetMap(level);

                string map = Maps[level][z].Substring(x, 1);

                ConvertMap[zz, x] = map;
            }
        }
        return ConvertMap;
    }

    public int TotalNumberOfLevels()
    {
        return Maps.Length;
    }

}
