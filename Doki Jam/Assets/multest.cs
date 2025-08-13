using UnityEngine;
using Alteruna;


public class multest : MonoBehaviour
{
    private Alteruna.Avatar _avatar;
    private Spawner _spawner;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();
        _spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();

        if (!_avatar.IsMe) return;


    }

    void Update()
    {
        if (!_avatar.IsMe) return;
        if (Input.GetKey(KeyCode.D)) transform.position = transform.position + new Vector3(10f * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.S)) transform.position = transform.position + new Vector3(0, -10f * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.A)) transform.position = transform.position + new Vector3(-10f * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.W)) transform.position = transform.position + new Vector3(0, 10f * Time.deltaTime, 0);

        if (Input.GetMouseButtonDown(0))
        {
            _spawner.Spawn(0);

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        
    }
}
