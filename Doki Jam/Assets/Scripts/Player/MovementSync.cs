using UnityEngine;
using Alteruna;

public class MovementSync : AttributesSync {
    private Rigidbody rb;
    public bool isMultiplayer;
    private Alteruna.Avatar _avatar;


    void Start() {
        if (!isMultiplayer) return;
        _avatar = GetComponent<Alteruna.Avatar>();

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isMultiplayer && !_avatar.IsMe) return;
        if (!isMultiplayer) return;
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
