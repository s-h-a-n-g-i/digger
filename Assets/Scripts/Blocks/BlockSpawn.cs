using UnityEngine;
using UnityEngine.InputSystem;

public class BlockSpawn : MonoBehaviour
{
    [SerializeField] private Block[] block;
    [SerializeField] private Block thisBlock;
    private BlocksManager blocksManager;
    private InputAction mouseClick;
    private bool clickBlocker = true;
    private bool chosenOne;
    void Start()
    {
        mouseClick = InputSystem.actions.FindAction("Attack");
        blocksManager = GameObject.FindFirstObjectByType<BlocksManager>();

        for (int i = 0; i < block.Length; i++) 
        {
            if (blocksManager.level >= block[i].levelSpawn) 
            {
                thisBlock = block[i];
            }
        }
        GetComponent<SpriteRenderer>().sprite = thisBlock.sprite;
    }
    private void Update()
    {
        if (transform.position == new Vector3(0, -1, 0))
            chosenOne = true;
        if (!chosenOne) return;

        if (mouseClick.ReadValue<float>() > 0 && clickBlocker) 
            Click();
        else if(mouseClick.ReadValue<float>()==0)
            clickBlocker = true;

        if (thisBlock.toughness > 0) return;

        blocksManager.MoveBlocks();
        Destroy(gameObject);
    }

    private void Click() 
    {
        clickBlocker = false;
        thisBlock.toughness -= blocksManager.digPower;
    }
}
