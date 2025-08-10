using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bomb;
    public GameObject bombSpawnPoint;
    public GameObject gun;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {       
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.forward, Vector3.zero); // z = 0 plane

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 point = ray.GetPoint(distance);
                Instantiate(bomb, point, Quaternion.identity);
            }
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.forward, Vector3.zero); // z = 0 plane

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 point = ray.GetPoint(distance);
                GameObject bombClone = Instantiate(bomb, bombSpawnPoint.transform.position, Quaternion.identity);
                bombClone.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(point - bombSpawnPoint.transform.position) * 400);
            }
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.forward, Vector3.zero); // z = 0 plane

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 point = ray.GetPoint(distance) - transform.position;
                float angle;
                if (transform.localScale.x == 1)
                {
                    angle = Vector3.Angle(Vector3.right, point);
                    if (point.y < 0) angle = 360 - angle;
                }
                else
                {
                    angle = Vector3.Angle(Vector3.left, point);
                    if (point.y > 0) angle = 360 - angle;
                }
                gun.transform.eulerAngles = new Vector3(gun.transform.rotation.x, gun.transform.rotation.y, angle);
            }

        }

        
    }
}
