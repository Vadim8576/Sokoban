using System.Collections.Generic;
using UnityEngine;

public class Maps : MonoBehaviour
{
    List<string>[] LevelMaps = new List<string>[2];

    public int MapLength = 10;

    void Start()
    {
        LevelMaps[0] = new List<string>()
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
        };

        LevelMaps[1] = new List<string>()
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
        };

    }


    public string[,] GetMap(int level)
    {
        string[,] LevelMap = new string[MapLength, MapLength];

        for (int z = 0; z < MapLength; z++)
        {
            for (int x = 0; x < MapLength; x++)
            {
                int zz = (MapLength - 1) - z;

                string map = LevelMaps[level][z].Substring(x, 1);
                LevelMap[zz, x] = map;
            }
        }

        return LevelMap;
    }

}
