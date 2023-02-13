using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DrawLevel : MonoBehaviour
{
    public GameObject _placeCell;
    public GameObject _destinationCell;
    public GameObject _crate;
    public GameObject _wall;
    public GameObject _player;
    

    public TextMeshProUGUI _cellSymbol;
    
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
    
    /*
    string[] map = {
        "##########",
        "#        #",
        "#    O   #",
        "#        #",
        "#        #",
        "#        #",
        "#        #",
        "#        #",
        "#        #",
        "##########"
    };
    */
    public string[,] Map2d;
    public int MapLength;

    void Start()
    {
        MapLength = map.Length;

        Map2d = new string[MapLength, MapLength];

        for (int z = 0; z < MapLength ; z++)
        {
            for (int x = 0; x < MapLength; x++)
            {

                int xx = x;
                int zz = (MapLength - 1) - z;

                string map2dString = map[z].Substring(x, 1);
                Map2d[z, x] = map2dString;
               

                if (map2dString != "#" && map2dString != "X")
                {
                    Instantiate(_placeCell, new Vector3(xx, 0, zz), Quaternion.identity);
                }
                /*
                if (map2dString == "#")
                {
                    Instantiate(_wall, new Vector3(xx, 0, zz), Quaternion.identity);
                }
                */
                if (map2dString == "X")
                {
                    Instantiate(_destinationCell, new Vector3(xx, 0, zz), Quaternion.identity);
                }

                if (x == 1 && z == 1)
                {
                    Instantiate(_player, new Vector3(xx, 0, zz), Quaternion.identity);
                }

                if (map2dString == "O")
                {
                    Debug.Log("ящик в " + xx + " " + zz);
                    Instantiate(_crate, new Vector3(xx, 0, zz), Quaternion.identity);
                }

            }

        }

    }

    public string[,] getMap()
    {
        return Map2d;
    }

}
