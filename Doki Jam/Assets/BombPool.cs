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
    //public List<int> prefabs;
    public int maxBombs;

    //private Multiplayer _multiplayer;

    //private Spawner _spawner;
    private List<List<GameObject>> bombPool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_multiplayer = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Multiplayer>();

        bombPool = new List<List<GameObject>>();
        //_spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();

        //if (_multiplayer.CurrentRoom.GetUserCount() == 1)
        //{
        for (int i = 0; i < prefabs.Count; i++)
        {
            bombPool.Add(new List<GameObject>());
            for (int j = 0; j < maxBombs; j++)
            {
                bombPool[i].Add(Instantiate(prefabs[i]));
                bombPool[i][j].SetActive(false);
                //bombPool[i].Add(_spawner.Spawn(prefabs[i], new Vector3(-10, -10, 0)));
            }
        }
        /*}
        else
        {
            for (int i = 0; i < prefabs.Count; i++)
            {
                bombPool.Add(new List<GameObject>());
            }
        }*/
    }


    // Update is called once per frame
    void Update() {
        /*if (_multiplayer.CurrentRoom.GetUserCount() != 1)
        {
            if (bombPool[0].Count != maxBombs)
            {
                bombPool[0] = new List<GameObject>();
                GameObject[] tmp = GameObject.FindGameObjectsWithTag("eggdragoon");
                foreach (GameObject t in tmp)
                {
                    bombPool[0].Add(t);
                }
            }
            if (bombPool[1].Count != maxBombs)
            {
                bombPool[1] = new List<GameObject>();
                GameObject[] tmp = GameObject.FindGameObjectsWithTag("regulardragoon");
                foreach (GameObject t in tmp)
                {
                    bombPool[1].Add(t);
                }
            }
            if (bombPool[2].Count != maxBombs)
            {
                bombPool[2] = new List<GameObject>();
                GameObject[] tmp = GameObject.FindGameObjectsWithTag("longdragoon");
                foreach (GameObject t in tmp)
                {
                    bombPool[2].Add(t);
                }
            }
            if (bombPool[3].Count != maxBombs)
            {
                bombPool[3] = new List<GameObject>();
                GameObject[] tmp = GameObject.FindGameObjectsWithTag("chonkydragoon");
                foreach (GameObject t in tmp)
                {
                    bombPool[3].Add(t);
                }
            }
        }*/
    }

    /*public GameObject getBomb(BombType bomb, Vector3 position, Vector3 force)
    {
        for (int i = 0; i < maxBombs; i++)
        {
            if (!bombPool[(int)bomb][i].activeInHierarchy)
            {
                bombPool[(int)bomb][i].transform.position = position;
                bombPool[(int)bomb][i].GetComponent<Bomb>().SetState(true);
                bombPool[(int)bomb][i].GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 0);
                bombPool[(int)bomb][i].GetComponent<Rigidbody>().AddForce(force);
                return bombPool[(int)bomb][i];
            }
        }
        return null;
    }*/

    public void DeleteBomb(GameObject bomb)
    {
        bomb.SetActive(false);
    }

    //[SynchronizableMethod]
    public GameObject GetBomb(BombType bomb, Vector3 position)
    {
        /*if (!_multiplayer.Me.IsHost) return null;
        return getBomb(bomb, position, force);*/
        for (int i = 0; i < maxBombs; i++)
        {
            if (!bombPool[(int)bomb][i].activeInHierarchy)
            {
                bombPool[(int)bomb][i].GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 0);
                bombPool[(int)bomb][i].transform.position = position;
                bombPool[(int)bomb][i].SetActive(true);
                //bombPool[(int)bomb][i].GetComponent<Rigidbody>().AddForce(force);
                return bombPool[(int)bomb][i];
            }
        }

        return null;
    }
}
