using UnityEngine;

public class BuggyScript : MonoBehaviour
{
    /// <summary>左クリックで切り替えるスプライト</summary>
    [SerializeField] Sprite[] m_sprites = default;
    /// <summary>右クリックで消す（非アクティブにする）GameObject の名前</summary>
    [SerializeField] string m_targetObjectName = default;
    SpriteRenderer m_sprite = default;
    int m_index;

    void Start()
    {
        // GetComponent<T>() は自分と同じ GameObject に
        // 追加されているコンポーネント T を返すが、
        // 指定されたコンポーネントが追加されていない時は null を返す。
        m_sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 左クリックでスプライトを切り替える
        if (Input.GetButtonDown("Fire1"))
        {
            m_sprite.sprite = m_sprites[m_index % 3];
            m_index++;
            Debug.Log("Index: " + m_index % 3);
        }

        // 右クリックで指定した名前のオブジェクトを非アクティブにする（消す）
        if (Input.GetButtonDown("Fire2") && m_targetObjectName.Length > 0)
        {
            // GameObject.Find() は指定した名前の GameObject を検索して返すが、
            // その名前の GameObject が見つからない時は null を返す。
            m_targetObjectName = "Gunman";
            GameObject go = GameObject.Find(m_targetObjectName);
            go.SetActive(false);
           
        }
    }
}
