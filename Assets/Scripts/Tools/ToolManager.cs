using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    [SerializeField] private Tool[] tools;
    [SerializeField] private TMP_Text buttonCost;
    [SerializeField] private SpriteRenderer itemSprite;
    private BlocksManager M_blocksManager;
    private int toolActive = 0;
    void Start()
    {
        M_blocksManager = GameObject.FindFirstObjectByType<BlocksManager>();
    }

    void Update()
    {
        itemSprite.sprite = tools[toolActive].itemSprite;
        if (toolActive + 1 < tools.Length)
            buttonCost.text = "Upgrade Tool: " + tools[toolActive + 1].cost;
        else
            buttonCost.text = "Max Upgrade";
    }

    public void ButtonClick() 
    {
        if (toolActive + 1 >= tools.Length) return;
        if (tools[toolActive + 1].cost > M_blocksManager.kaska) return;
        toolActive++;
        M_blocksManager.kaska -= tools[toolActive].cost;
    }

    public int GetToolDigPower() 
    {
        return tools[toolActive].digPower;
    }
}
