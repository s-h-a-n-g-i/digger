using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    private BlocksManager m_BlocksManager;
    private float prevPos, nextPos;
    void Start()
    {
        m_BlocksManager = GameObject.FindFirstObjectByType<BlocksManager>();
        prevPos = transform.position.y;
        nextPos = transform.position.y;
    }

    void Update()
    {
        CheckForPlacement();
        MoveUp();
    }

    private void CheckForPlacement()
    {
        if (transform.position.y < 10) return;
        Destroy(gameObject);
    }
    public void MoveUpSetup()
    {
        prevPos = transform.position.y;
        nextPos = transform.position.y + 1;
    }
    private void MoveUp()
    {
        Vector3 s = new Vector3(transform.position.x, nextPos, transform.position.z); 
        transform.position = s;
    }
}
