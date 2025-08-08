using UnityEngine;
using Alteruna;

public class GameHost : MonoBehaviour
{

    public GameObject currentMap;
    private int ncurrentMap = 0;
    private Spawner _spawner;
    private float mapTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        _spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
        
    }

    // Update is called once per frame
    void Update()
    {
        mapTime += Time.deltaTime;
        if (ncurrentMap == 0)
        {
            currentMap = _spawner.Spawn(1);
            ncurrentMap = 1;
            mapTime = 0;
        }
        if (mapTime >= 10f)
        {
            _spawner.Despawn(currentMap);

            if (ncurrentMap == 1)
            {
                currentMap = _spawner.Spawn(2);
                ncurrentMap = 2;
            }
            else
            {
                currentMap = _spawner.Spawn(1);
                ncurrentMap = 1;
            }
            mapTime = 0;
        }
        
    }
}
