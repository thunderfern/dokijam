using UnityEngine;
using Alteruna;

public class BombSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bombSpawnPoint;
    public GameObject gun;
    public GameObject player;
    public int shootingForce;
    private Alteruna.Avatar _avatar;
    void Start()
    {
        //bombSpawnPoint = GameObject.FindGameObjectWithTag("bomb spawn");
        //gun = GameObject.FindGameObjectWithTag("gun");
        //player = GameObject.FindGameObjectWithTag("Player");
        _avatar = player.GetComponent<Alteruna.Avatar>();
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


        //if (!_avatar.IsMe) return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.forward, Vector3.zero); // z = 0 plane

            

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 point = ray.GetPoint(distance);
                //GameObject bombClone = GetComponent<BombPool>().GetBomb(BombType.EGG, bombSpawnPoint.transform.position);
                //bombClone.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(point - bombSpawnPoint.transform.position) * shootingForce);
                //bombClone.GetComponent<Bomb>().setPosition(bombClone.transform.position, bombClone.GetComponent<Rigidbody>().linearVelocity);
                //GetComponent<BombPool>().BroadcastRemoteMethod("GetBomb", BombType.EGG, bombSpawnPoint.transform.position, Vector3.Normalize(point - bombSpawnPoint.transform.position) * shootingForce);


                /**for (int i = 0; i < 1000; i++)
                {
                    Collider[] checkColliders = Physics.OverlapBox(bombSpawnPoint.transform.position, new Vector3(0.35f, 044f, 0.5f), Quaternion.identity);
                    if (checkColliders.Length == 0)
                    {
                        break;
                    }

                    foreach (Collider coll in checkColliders)
                    {
                        if (coll.gameObject.tag == "Ground")
                        {
                            Vector3 dir = (bombSpawnPoint.transform.position - coll.transform.position).normalized/10;
                            Debug.Log(coll.gameObject.transform.position);
                            Debug.Log(bombSpawnPoint);
                            bombSpawnPoint.transform.position += dir;
                        }
                    }

                    
                }**/
                /**Collider[] checkColliders = Physics.OverlapBox(bombSpawnPoint.transform.position, new Vector3(0.35f, 0.44f, 0.5f), Quaternion.identity);
                if (checkColliders.Length == 0)
                {
                    GameObject bombClone = GetComponent<BombPool>().GetBomb(BombType.EGG, bombSpawnPoint.transform.position, new Vector3(0, 0, 0));
                    bombClone.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(point - bombSpawnPoint.transform.position) * shootingForce);

                    
                }**/

                GameObject bombClone = GetComponent<BombPool>().GetBomb(BombType.EGG, bombSpawnPoint.transform.position);
                bombClone.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(point - bombSpawnPoint.transform.position) * shootingForce);
            }
        }
        else {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.forward, Vector3.zero); // z = 0 plane
            if (plane.Raycast(ray, out float distance))
            {
                Vector3 point = ray.GetPoint(distance) - player.transform.position;
                float angle;
                if (player.transform.localScale.x == 1)
                {
                    angle = Vector3.Angle(Vector3.right, point);
                    if (point.y < 0) angle = 360 - angle;
                }
                else
                {
                    angle = Vector3.Angle(Vector3.left, point);
                    if (point.y > 0)
                    {
                        angle = 360 - angle;
                    }
                }
                gun.transform.eulerAngles = new Vector3(gun.transform.rotation.x, gun.transform.rotation.y, angle);
            }

        }

        
    }
}
