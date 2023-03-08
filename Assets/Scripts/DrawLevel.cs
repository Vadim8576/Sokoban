using UnityEngine;


public class DrawLevel : MonoBehaviour
{
    public GameObject _placeCell;
    public GameObject _destinationCell;
    public GameObject _crate;
    public GameObject _wall;
    public GameObject _player;
    public GameObject _playerWidthLight;

 
    GameManager GameManager;

    // Сюжет: кладовщик просыпается от кошмара - на него едут ящики со всех сторон
    // он просыпается в холодном поту и идет на работу


    // Склад 01 - Storage 01

    public string[,] map;

    void Start()
    {
        //Levels = FindObjectOfType<Levels>();
        GameManager = FindObjectOfType<GameManager>();

        int mapLength = GameManager.GetMapLength();


        //Debug.Log("DrawLevels CurrentLevel = " + Progress.GetCurrentLevel());

        map = GameManager.GetConvertMap(GameManager.GetCurrentLevel());


        Debug.Log(map);
        Debug.Log(map.Length);



        for (int z = 0; z < mapLength; z++)
        {
            for (int x = 0; x < mapLength; x++)
            {
                string mapSymbol = map[z, x];

                if (mapSymbol == "@")
                {
                    GameManager.SetPlayerСoordinates(x, z);

                    Instantiate(_placeCell, new Vector3(x, 0, z), Quaternion.identity);
                    Instantiate(_player, new Vector3(x, 0, z), Quaternion.identity);
                }
                
                if (mapSymbol == " ")
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

                /*
                if (x == 1 && z == 8)
                {
                    Instantiate(_player, new Vector3(x, 0, z), Quaternion.identity);
                }
                */
                if (mapSymbol == "O")
                {
                    Instantiate(_placeCell, new Vector3(x, 0, z), Quaternion.identity);
                    Instantiate(_crate, new Vector3(x, 0, z), Quaternion.identity);
                }

            }

        }

    }

}
