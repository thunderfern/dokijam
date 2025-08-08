using UnityEngine;

public class Bomb : MonoBehaviour
{
    //public GameObject explosion;
    public float force, radius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision other)
    {
        //GameObject _explosion = Instantiate(explosion, transform.position, transform.rotation);

        knockBack();
        Destroy(gameObject);


    }

    void knockBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearby in colliders)
        {
            Vector3 direction = nearby.transform.position - transform.position;
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(direction*force);
            }
        }
    }
}
