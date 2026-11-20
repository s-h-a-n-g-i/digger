using System.Collections;
using TMPro;
using UnityEditor.EditorTools;
using UnityEngine;

public class BlocksManager : MonoBehaviour
{
    public float gravity = 1;
    public int level = 0;
    public bool moveBlocks = false;
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private Spawner[] spawners;
    [SerializeField] private TMP_Text moneyText;
    public int digPower = 1;

    public int kaska = 0;
    private ToolManager toolManager;
    private void Start()
    {
        toolManager = GameObject.FindFirstObjectByType<ToolManager>();
        spawners = GameObject.FindObjectsByType<Spawner>(0);
        StartCoroutine(StartMap());
    }
    void Update()
    {
        moneyText.text = kaska + "$";
        digPower = toolManager.GetToolDigPower();
        if (moveBlocks)
            MoveBlocks();
    }

    public void MoveBlocks() 
    {
        BlockMovement[] blocksOnMap = GameObject.FindObjectsByType<BlockMovement>(0);
        foreach (BlockMovement blockMovement in blocksOnMap) 
        {
            blockMovement.MoveUpSetup();
        }
        SpawnBlocks();
        level++;
        moveBlocks = false;
    }

    private void SpawnBlocks() 
    {
        foreach (Spawner s in spawners) 
        {
            Instantiate(blockPrefab, s.transform.position, s.transform.rotation);
        }
        kaska++;
    }
    IEnumerator StartMap() 
    {
        for (int i = 0; i < 11; i++) 
        {
            moveBlocks = true;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
