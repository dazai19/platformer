using System.Diagnostics;
using UnityEngine;
//[RequireComponent(typeof(HealthController))]
public class DamageDiller : MonoBehaviour
{
    
    [SerializeField] private float damage;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<HealthController>())
        {
            col.gameObject.GetComponent<HealthController>().TakeDamage(damage);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<HealthController>() && collision.gameObject.name != "PlayerGod")
        {
            collision.gameObject.GetComponent<HealthController>().TakeDamage(1f);
        }
    }
}
