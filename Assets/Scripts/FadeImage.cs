using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{

    [SerializeField]
    private Image img;
    [SerializeField]
    private GameObject overText;
    [SerializeField]
    private PlayerManager enemy;
    public void Update()
    {
        if (enemy.hp == 0)
        {
            overText.SetActive(true);
            StartCoroutine(ImageFade(false));
        }
        
    }

    IEnumerator ImageFade(bool fadeAway)
    {
        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}

