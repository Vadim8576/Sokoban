using UnityEngine;

public class DrawLevel : MonoBehaviour
{
    public GameObject _placeCell;
    public GameObject _destinationCell;
    public GameObject _crate;
    public GameObject _wall;
    public GameObject _player;
    
    

    // —южет: кладовщик просыпаетс€ от кошмара - на него едут €щики со всех сторон
    // он просыпаетс€ в холодном поту и идет на работу


    // —клад 01 - Storage 01


    string[] map = {
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
                Map2d[zz, xx] = map2dString;
               

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
                
                if (map2dString == "V")
                {
                    Instantiate(_destinationCell, new Vector3(xx, 0, zz), Quaternion.identity);
                    Instantiate(_crate, new Vector3(xx, 0, zz), Quaternion.identity);
                }

                if (xx == 1 && zz == 8)
                {
                    Instantiate(_player, new Vector3(xx, 0, zz), Quaternion.identity);
                }

                if (map2dString == "O")
                {
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
