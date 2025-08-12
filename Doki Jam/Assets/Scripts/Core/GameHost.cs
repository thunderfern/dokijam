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

        _multiplayer.SpawnAvatar();
        // spawns bomb spawner
        _spawner.Spawn(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (_multiplayer.Me.IsHost)
        {
            mapTime += Time.deltaTime;
            if (ncurrentMap == 0)
            {
                currentMap = _spawner.Spawn(2);
                ncurrentMap = 2;
                mapTime = 0;
            }
            if (mapTime >= 10f)
            {
                _spawner.Despawn(currentMap);

                if (ncurrentMap == 2)
                {
                    currentMap = _spawner.Spawn(3);
                    ncurrentMap = 3;
                }
                else
                {
                    currentMap = _spawner.Spawn(2);
                    ncurrentMap = 2;
                }
                mapTime = 0;
            }
        }

    }
}
