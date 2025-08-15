using UnityEngine;
using Alteruna;

public enum GameMode
{
    STANDARD,
    SURVIVAL,
    RACING
};

public class GameHost : MonoBehaviour
{

    // Game data
    public GameMode gameMode;
    public GameObject currentMap;
    public float mapTime = 0;

    // Other game data
    private Spawner _spawner;
    private Multiplayer _multiplayer;
    private int nstartMap = 0;
    private int nendMap = 0;

    // Drives gameplay
    private int ncurrentMap = 0;
    
    // Spawn for modes

    // survival
    public GameObject bombSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        _spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
        _multiplayer = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Multiplayer>();

        //_multiplayer.SpawnAvatar();
        // spawns bomb spawner
        if (_multiplayer.Me.IsHost)
        {
            _multiplayer.SpawnAvatar();
            //_spawner.Spawn(1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_multiplayer.Me.IsHost)
        {
            /*if (GameObject.FindGameObjectWithTag("bomb spawner") == null)
            {
                _spawner.Spawn(6);
            }*/
            mapTime += Time.deltaTime;
            if (ncurrentMap == 0)
            {
                currentMap = _spawner.Spawn(6);
                ncurrentMap = 6;
                mapTime = 0;
            }
            if (mapTime >= 10f)
            {
                _spawner.Despawn(currentMap);

                if (ncurrentMap == 6)
                {
                    currentMap = _spawner.Spawn(7);
                    ncurrentMap = 7;
                }
                else
                {
                    currentMap = _spawner.Spawn(6);
                    ncurrentMap = 6;
                }
                mapTime = 0;
            }
        }
        if (mapTime < 0.0001f && _multiplayer.GetAvatar() == null)
        {
            _multiplayer.SpawnAvatar();
        }

    }
}
