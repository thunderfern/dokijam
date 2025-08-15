using UnityEngine;
using Alteruna;

public class Bomb : AttributesSync
{
    //public GameObject explosion;
    public float force, radius;
    public BombType mergeInto;
    private GameObject bombSpawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        bombSpawner = GameObject.FindGameObjectWithTag("bomb spawner");
        //GameObject _explosion = Instantiate(explosion, transform.position, transform.rotation);
        //Debug.Log(other.gameObject);
        //knockBack();
        //gameObject.SetActive(false);

        if (other.gameObject.tag == gameObject.tag && gameObject.activeInHierarchy && other.gameObject.activeInHierarchy)
        {
            other.gameObject.GetComponent<Bomb>().SetState(false);
            gameObject.GetComponent<Bomb>().SetState(false);
            BroadcastRemoteMethod("knockBack");
            if (mergeInto != BombType.NULL) bombSpawner.GetComponent<BombPool>().GetBomb(mergeInto, (other.transform.position + transform.position) / 2);
        }
    }

    public void SetState(bool state)
    {
        BroadcastRemoteMethod("SyncActive", state);
    }

    [SynchronizableMethod]
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

    [SynchronizableMethod]
    void SyncActive(bool state)
    {
        gameObject.SetActive(state);
    }
}
