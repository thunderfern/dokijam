using UnityEngine;

public class Bomb : MonoBehaviour
{
    //public GameObject explosion;
    public float force, radius;
    public GameObject mergeInto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision other)
    {
        //GameObject _explosion = Instantiate(explosion, transform.position, transform.rotation);

        knockBack();
        Destroy(gameObject);

        /*if (other.gameObject.tag == gameObject.tag)
        {
            Instantiate(mergeInto, (other.transform.position + transform.position) / 2, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }*/
    }

    void knockBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearby in colliders)
        {
            Vector3 direction = nearby.transform.position - transform.position;
            Vector3 normalizedDirection = Vector3.Normalize(direction);
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(normalizedDirection * (radius - direction.magnitude) * force);
            }
        }
    }
}
