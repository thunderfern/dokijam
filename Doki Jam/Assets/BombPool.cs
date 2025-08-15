using UnityEngine;
using System.Collections.Generic;
using Alteruna;

public enum BombType
{
    EGG,
    REGULAR,
    LONG,
    CHONKY,
    NULL
}

public class BombPool : MonoBehaviour
{
    //public List<GameObject> prefabs;
    public List<int> prefabs;
    public int maxBombs;

    private Multiplayer _multiplayer;

    private Spawner _spawner;
    private List<List<GameObject>> bombPool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _multiplayer = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Multiplayer>();

        bombPool = new List<List<GameObject>>();
        _spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
        if (_multiplayer.CurrentRoom.GetUserCount() == 1)
        {
            for (int i = 0; i < prefabs.Count; i++)
            {
                bombPool.Add(new List<GameObject>());
                for (int j = 0; j < maxBombs; j++)
                {
                    //bombPool[i].Add(Instantiate(prefabs[i]));
                    bombPool[i].Add(_spawner.Spawn(prefabs[i], new Vector3(-10, -10, 0)));
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetBomb(BombType bomb, Vector3 position)
    {
        for (int i = 0; i < maxBombs; i++)
        {
            if (!bombPool[(int)bomb][i].activeInHierarchy)
            {
                bombPool[(int)bomb][i].transform.position = position;
                bombPool[(int)bomb][i].GetComponent<Bomb>().SetState(true);
                return bombPool[(int)bomb][i];
            }
        }
        return null;
    }

    public void DeleteBomb(GameObject bomb)
    {
        bomb.SetActive(false);
    }
}
