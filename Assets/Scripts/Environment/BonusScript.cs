using TMPro;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    [SerializeField] private TMP_Text coinValue;
    [SerializeField] private GameObject[] imageBonus; // 0 1 2 3 4

    private int coinCounter = 0;

    private int ConvertStringToInt32(int value)
    {
        try
        {
            return value = int.Parse(coinValue.text);
        }
        catch (System.Exception)
        {
            return 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            switch (gameObject.tag)
            {
                case "Coin":
                    coinCounter = ConvertStringToInt32(coinCounter);
                    coinCounter++;
                    coinValue.text = coinCounter.ToString();
                    Destroy(gameObject, .1f);
                    break;

                case "Bonus":
                    for (int i = 0; i < imageBonus.Length; i++)
                    {
                        if (!imageBonus[i].activeSelf)
                        {
                            imageBonus[i].SetActive(true);
                            Destroy(gameObject, .1f);
                            break;
                        }
                    }
                    
                    break;
            }

        }
    }


}
