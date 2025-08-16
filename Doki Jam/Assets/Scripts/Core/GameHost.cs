using UnityEngine;
using Alteruna;

public enum GameMode
{
    STANDARD,
    SURVIVAL,
    RACING
};

public class GameHost : AttributesSync
{

    // Game data
    public GameMode gameMode;
    public GameObject currentMap;
    public float mapTime = 0;
    public Transform spawnPoint;

    // Other game data
    private Spawner _spawner;
    private Multiplayer _multiplayer;
    private Alteruna.Avatar _avatar;
    private GameObject player;
    private int nstartMap = 6;
    private int nendMap = 9;

    // Drives gameplay
    private int ncurrentMap = 0;

    public bool hasWinner;
    public bool completed;

    // Spawn for modes

    // survival
    public GameObject bombSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        _spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
        _multiplayer = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Multiplayer>();

        //spawns Avatar
        _avatar = _multiplayer.SpawnAvatar();
        player = _avatar.gameObject;
        player.SetActive(false);
        mapTime = 100f;

    }

    // Update is called once per frame
    void Update()
    {
        mapTime += Time.deltaTime;
        if (_multiplayer.Me.IsHost)
        {
            // spawn new map
            if (mapTime >= 10f)
            {
                player.SetActive(false);
                _spawner.Despawn(currentMap);
                ncurrentMap = Random.Range(nstartMap, nendMap + 1);
                currentMap = _spawner.Spawn(ncurrentMap);
                BroadcastRemoteMethod("resetMapInformation", 0.0f, ncurrentMap);
                mapTime = 0.0f;
            }
        }

    }

    [SynchronizableMethod]
    void resetMapInformation(float mapTimen, int ncurrentMapn)
    {
        if (!completed)
        {
            player.GetComponent<AcessoryController>().loseCount--;
            player.GetComponent<AcessoryController>().win = false;
        }
        
        mapTime = mapTimen;
        ncurrentMap = ncurrentMapn;
        currentMap = GameObject.FindGameObjectWithTag("Map");
        spawnPoint = currentMap.transform.Find("Spawnpoint");
        player.transform.position = spawnPoint.position + new Vector3(0, 0, 0);
        player.SetActive(true);
        hasWinner = false;
        completed = false;
    }

    [SynchronizableMethod]
    void updateWinner()
    {
        hasWinner = true;
    }
}
