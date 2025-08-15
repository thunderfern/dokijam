using UnityEngine;
using Alteruna;

public class BombMovementSync : AttributesSync
{
    private Rigidbody rb;
    public bool isMultiplayer;
    private Alteruna.Avatar _avatar;
    private Multiplayer _multiplayer;

    void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();
        rb = GetComponent<Rigidbody>();
        _multiplayer = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Multiplayer>();

    }

    void Update()
    {
        if (!isMultiplayer) return;
        if (!_multiplayer.Me.IsHost) return;
        if (!rb) rb = GetComponent<Rigidbody>();
        else BroadcastRemoteMethod("updateTransform", transform.position, rb.linearVelocity);
    }

    [SynchronizableMethod]
    void updateTransform(Vector3 position, Vector3 linearVelocity)
    {
        transform.position = position + new Vector3(0, 0, 0);
        rb.linearVelocity = linearVelocity + new Vector3(0, 0, 0);
    }
}
