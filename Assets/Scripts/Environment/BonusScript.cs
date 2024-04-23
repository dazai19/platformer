using TMPro;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    [SerializeField] private TMP_Text bonusValue;

    private int bonusCounter = 0;

    private void Awake()
    {
        //bonusValue = GetComponent<TextMeshPro>();
        bonusCounter = ConvertStringToInt32(bonusCounter);
    }

    private int ConvertStringToInt32(int value)
    {
        try
        {
            return value = int.Parse(bonusValue.text);
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
            bonusCounter++;
            bonusValue.text = bonusCounter.ToString();
            Destroy(gameObject, .1f);
        }
    }
}
