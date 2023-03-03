using UnityEngine;


public class DrawLevel : MonoBehaviour
{
    public GameObject _placeCell;
    public GameObject _destinationCell;
    public GameObject _crate;
    public GameObject _wall;
    public GameObject _player;

    Levels Levels;

    // —южет: кладовщик просыпаетс€ от кошмара - на него едут €щики со всех сторон
    // он просыпаетс€ в холодном поту и идет на работу


    // —клад 01 - Storage 01

    public string[,] map;

    void Start()
    {
        Levels = FindObjectOfType<Levels>();

        int mapLength = Levels.MapLength;

        map = Levels.GetConvertMap(0);



        for (int z = 0; z < mapLength; z++)
        {
            for (int x = 0; x < mapLength; x++)
            {
                string mapSymbol = map[z, x];

                if (mapSymbol != "#" && mapSymbol != "X")
                {
                    Instantiate(_placeCell, new Vector3(x, 0, z), Quaternion.identity);
                }
               
                if (mapSymbol == "#")
                {
                    //Instantiate(_wall, new Vector3(x, 0, z), Quaternion.identity);
                }
                
                if (mapSymbol == "X")
                {
                    Instantiate(_destinationCell, new Vector3(x, 0, z), Quaternion.identity);


                }

                if (mapSymbol == "V")
                {
                    Instantiate(_destinationCell, new Vector3(x, 0, z), Quaternion.identity);
                    Instantiate(_crate, new Vector3(x, 0, z), Quaternion.identity);
                }

                if (x == 1 && z == 8)
                {
                    Instantiate(_player, new Vector3(x, 0, z), Quaternion.identity);
                }

                if (mapSymbol == "O")
                {
                    Instantiate(_crate, new Vector3(x, 0, z), Quaternion.identity);
                }

            }

        }

    }

    private void Update()
    {
        
    }

}
