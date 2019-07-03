using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    
    public Text ScoreText;
    public Text LifeText;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject pistol;
    [SerializeField]
    private GameObject rifle;
    [SerializeField]
    private GameObject superGun;

    public int hp = 100;

    public int score = 0;
    public void DecreaseHP(int ammount)
    {
       hp -= ammount;
    }

    void Start()
    {
        superGun.SetActive(false);
        rifle.SetActive(false);
        pistol.SetActive(true);
    }

    void Update()
    {
        CheckForChangeGun();
    }

    private void CheckForChangeGun()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "rifle")
            {
                superGun.SetActive(false);
                pistol.SetActive(false);
                rifle.SetActive(true);
            }
            else if(hit.collider.gameObject.tag == "supergun")
            {
                superGun.SetActive(true);
                pistol.SetActive(false);
                rifle.SetActive(false);
            }
        }
    }
}
