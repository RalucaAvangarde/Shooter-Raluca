using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;

    private Text text;                    


    void Awake()
    { 
        text = GetComponent<Text>();
        score = 0;
    }


    void Update()
    {
        text.text = "Score: " + score;
    }
}
