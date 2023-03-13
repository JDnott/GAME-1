using TMPro;
using UnityEngine;


public class ScoreCounter : MonoBehaviour
{
    // Private
    private int score = 0;
   [SerializeField] private TextMeshProUGUI textCount;

    public int Score { set { if (value > 0)
                score += value;
            UpdateScoreText();
         }
        get
        {
            return score;
        }
    }


    // Update is called once per frame
   
    void UpdateScoreText()
    {
      
        textCount.text = "Score: " + score.ToString();
    }



    //public void DecreaseScore(int amount)
    //{
    //    score -= amount;
    //    if (score < 0)
    //    {
    //        score = 0;
    //    }
    //    UpdateScoreText();
    //}
}
