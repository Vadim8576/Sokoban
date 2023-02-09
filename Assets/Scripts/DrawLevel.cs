using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DrawLevel : MonoBehaviour
{
    public GameObject _placeCell;
    public GameObject _crate;
    public GameObject _wall;
    public GameObject _player;
    void Start()
    {
        string[] map = {
                "##########",
                "#   O    #",
                "#   #    #",
                "###   #X##",
                "#        #",
                "#X## #####",
                "#   O   X#",
                "# ##O### #",
                "#        #",
                "##########"
        };

        int len = map.Length;

        string[,] map2d = new string[len, len];

        for (int z = 0; z < len; z++)
        {
            for (int x = 0; x < len; x++)
            {
                int xx = len - x;
                int zz = len - z;
                map2d[z, x] = map[z].Substring(x, 1);
                string map2dString = map2d[z, x];

                Instantiate(_placeCell, new Vector3(xx, 0, z), Quaternion.identity);

                if (x == 1 && z == 1)
                {
                    Instantiate(_player, new Vector3(xx, 0, z), Quaternion.identity);
                }

                if (map2dString == "O")
                {
                    Instantiate(_crate, new Vector3(xx, 0, z), Quaternion.identity);
                }

                if (map2dString == "#")
                {
                    Instantiate(_wall, new Vector3(xx, 0, z), Quaternion.identity);
                }

            }

        }

    }

}
