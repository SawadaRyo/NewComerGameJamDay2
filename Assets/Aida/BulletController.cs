using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Tooltip("’e‚Ì‘¬“x")]
    [SerializeField] private float bullet_Speed = 1f;
    [SerializeField] private GameObject gameobject;
    [SerializeField] private float life_Time = 1f;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector3.up * bullet_Speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "DeadLine")
       {
          
          Destroy(this.gameObject);
       }
        if (collision.gameObject.TryGetComponent<IFallObject>(out IFallObject fallobject))
        {
            fallobject.HitResult();
            Destroy(this.gameObject);
            GameObject ob = Instantiate(gameobject, transform.position, Quaternion.identity);
            Destroy(ob, life_Time);
        }
    }
}
