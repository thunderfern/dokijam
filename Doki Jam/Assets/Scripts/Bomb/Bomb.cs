using UnityEngine;
using Alteruna;

public class Bomb : MonoBehaviour //AttributesSync
{
    //public GameObject explosion;
    public float force, radius;
    public BombType mergeInto;
    private GameObject bombSpawner;
    public GameObject explosion;

    //private Multiplayer _multiplayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        //gameObject.SetActive(false);
        //_multiplayer = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Multiplayer>();

    }

    void Update()
    {
        if (transform.position.y < -25f) gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        //if (!_multiplayer.Me.IsHost) return;
        bombSpawner = GameObject.FindGameObjectWithTag("bomb spawner");
        //GameObject _explosion = Instantiate(explosion, transform.position, transform.rotation);
        //Debug.Log(other.gameObject);
        //knockBack();
        //gameObject.SetActive(false);

        if (other.gameObject.tag == gameObject.tag && gameObject.activeInHierarchy && other.gameObject.activeInHierarchy)
        {
            /*other.gameObject.GetComponent<Bomb>().SetState(false);
            gameObject.GetComponent<Bomb>().SetState(false);
            BroadcastRemoteMethod("knockBack");
            if (mergeInto != BombType.NULL) bombSpawner.GetComponent<BombPool>().GetBomb(mergeInto, (other.transform.position + transform.position) / 2, new Vector3(0, 0, 0));*/
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(AudioName.Explosion);
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
            knockBack();
            GameObject tmp = Instantiate(explosion);
            tmp.transform.position = (other.transform.position + transform.position) / 2;
            if (mergeInto != BombType.NULL)
            {
                bombSpawner.GetComponent<BombPool>().GetBomb(mergeInto, (other.transform.position + transform.position) / 2);
            }
        }
    }

    public void SetState(bool state)
    {
        //BroadcastRemoteMethod("SyncActive", state);
    }

    //[SynchronizableMethod]
    void knockBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearby in colliders)
        {
            Vector3 direction = nearby.transform.position - transform.position;
            Vector3 normalizedDirection = Vector3.Normalize(direction);
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddForce(normalizedDirection * (radius - direction.magnitude) * force, ForceMode.Impulse);
            }
        }
    }

    //[SynchronizableMethod]
    void SyncActive(bool state)
    {
        gameObject.SetActive(state);
    }

    /*[SynchronizableMethod]
    public void setPosition(Vector3 position, Vector3 linearVelocity)
    {
        transform.position = position + new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().linearVelocity = linearVelocity + new Vector3(0, 0, 0);
    }*/
}
