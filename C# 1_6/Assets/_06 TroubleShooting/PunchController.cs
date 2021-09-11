using UnityEngine;

/// <summary>
/// パンチを制御するコンポーネント
/// Fire1 でダッシュする
/// ぶつかったものを弾き飛ばす
/// </summary>
public class PunchController : MonoBehaviour
{
    /// <summary>移動の時にかける力</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>ダッシュする力</summary>
    [SerializeField] float m_dashPower = 15f;
    /// <summary>触れたものを吹き飛ばす力</summary>
    [SerializeField] float m_punchPower = 15f;
    Rigidbody2D m_rb = default;
    float m_h, m_v;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 方向の入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");
        m_v = Input.GetAxisRaw("Vertical");

        // Fire1 でダッシュする
        if (Input.GetButtonDown("Fire1"))
        {
            m_rb.AddForce(this.transform.up * m_dashPower, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        // 入力に応じて移動し、向きを変える
        Vector2 dir = new Vector2(m_h, m_v).normalized;
        m_rb.AddForce(dir * m_movePower);
        this.transform.up = m_rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();  // 衝突相手の Rigidbody2D コンポーネントを取得する
        // パンチが当たった時に吹っ飛ばす
        if (rb != null)
        {
            Vector2 dir = (collision.gameObject.transform.position - this.transform.position).normalized;
            rb.AddForce(dir * m_punchPower, ForceMode2D.Impulse);
        }
        
        
    }
}
