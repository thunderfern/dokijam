using UnityEngine;

public class AcessoryController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool win = false;
    public int loseCount = 0;
    public GameObject Crown;
    public GameObject ClownHair;
    public GameObject ClownNose;
    public Texture ClownTexture;
    public Texture RegularTexture;
    private GameObject crownInstance;
    private GameObject noseInstance;
    private GameObject hairInstance;
    private Transform tomatoTex;



    void Start()
    {
        tomatoTex = this.transform.Find("Tomato/Tomato");
        if (tomatoTex != null)
        {
            Debug.Log("notBroke");
            tomatoTex.gameObject.GetComponent<Renderer>().material.mainTexture = RegularTexture;
        }
        else
        {
            Debug.Log("broke");
        }

        crownInstance = Instantiate(Crown);//Crown
        crownInstance.transform.SetParent(this.transform);
        crownInstance.SetActive(false);
        crownInstance.transform.position = this.transform.position + new Vector3(0.022f, 0.785f, 0f);

        hairInstance = Instantiate(ClownHair);//Hair
        hairInstance.transform.SetParent(this.transform);
        hairInstance.SetActive(true);
        hairInstance.transform.position = this.transform.position + new Vector3(0.028f, -0.186f, -0.006f);


        noseInstance = Instantiate(ClownNose);//Nose
        noseInstance.transform.SetParent(this.transform);
        noseInstance.SetActive(false);
        noseInstance.transform.position = this.transform.position + new Vector3(0.291f, 0.327f, -0.325f);


    }

    // Update is called once per frame
    void Update()
    {
         
        if (win){//if win & doesn't have texture it attaches
            crownInstance.SetActive(true);
        }

        if (!win){//if lose & has texture it removes
            crownInstance.SetActive(false);
        }

        if (loseCount == 0){
            noseInstance.SetActive(false);
            hairInstance.SetActive(false);
            if (tomatoTex != null){
                tomatoTex.gameObject.GetComponent<Renderer>().material.mainTexture = RegularTexture;

            }
        }

        if (loseCount == 1){
            if (tomatoTex != null){
                tomatoTex.gameObject.GetComponent<Renderer>().material.mainTexture = ClownTexture;

            }
        }

        if (loseCount == 2){
            noseInstance.SetActive(true);
        }

        if (loseCount == 3){
            hairInstance.SetActive(true);
        }
    }
}