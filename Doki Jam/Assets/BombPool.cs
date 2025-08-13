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
    public List<GameObject> prefabs;
    public int maxBombs;

    private Multiplayer _multiplayer;

    private Spawner _spawner;
    private List<List<GameObject>> bombPool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_multiplayer = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Multiplayer>();

        bombPool = new List<List<GameObject>>();
        //_spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
        for (int i = 0; i < prefabs.Count; i++)
        {
            bombPool.Add(new List<GameObject>());
            for (int j = 0; j < maxBombs; j++)
            {
                bombPool[i].Add(Instantiate(prefabs[i]));
                //bombPool[i].Add(_spawner.Spawn(prefabs[i]));
                bombPool[i][j].SetActive(false);
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
                bombPool[(int)bomb][i].SetActive(true);
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
