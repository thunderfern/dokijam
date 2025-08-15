using UnityEngine;
using Alteruna;

public class multest : AttributesSync
{
    private Alteruna.Avatar _avatar;
    private Spawner _spawner;

    [SynchronizableField] private int numMove = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();
        _spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();

        if (!_avatar.IsMe) return;


    }

    void Update()
    {
        //if (_avatar.IsMe)
        //{
        if (!_avatar.IsMe) return;

        if (Input.GetKey(KeyCode.D)) BroadcastRemoteMethod("moveRight");
        else if (Input.GetKey(KeyCode.S)) BroadcastRemoteMethod("moveDown");
        else if (Input.GetKey(KeyCode.A)) BroadcastRemoteMethod("moveLeft");
        else if (Input.GetKey(KeyCode.W)) BroadcastRemoteMethod("moveUp");
        else numMove = 0;
        //}

        /*if (numMove == 1) moveRight();
        else if (numMove == 2) moveDown();
        else if (numMove == 3) moveLeft();
        else if (numMove == 4) moveUp();*/

        /*if (Input.GetMouseButtonDown(0))
        {
            _spawner.Spawn(0);

        }*/
    }

    // Update is called once per frame

    [SynchronizableMethod]
    void moveLeft()
    {
        transform.position = transform.position + new Vector3(-0.02f, 0, 0);
    }

    [SynchronizableMethod]
    void moveRight()
    {
        transform.position = transform.position + new Vector3(0.02f, 0, 0);
    }

    [SynchronizableMethod]
    void moveDown()
    {
        transform.position = transform.position + new Vector3(0, -0.02f, 0);
    }

    [SynchronizableMethod]
    void moveUp()
    {
        transform.position = transform.position + new Vector3(0, 0.02f, 0);
    }
    void FixedUpdate()
    {
        

        
    }
}
