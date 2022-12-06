using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInven;
public class EndingItemController : SingleMonobehaviour<EndingItemController>
{
    [SerializeField] private ThemedKeyInventoryController themedKeyInventoryController;
    public GameObject sword;
    public GameObject grtar;
    public GameObject halgr;
    [HideInInspector] public bool isEnd;
    public enum KatanaPiece
    { Sword, Grtar, Halgr }
    public KatanaPiece katanaPiece;

    private void Update()
    {
        if(sword.activeSelf && halgr.activeSelf && grtar.activeSelf)
        {
            GameManager.Instance.endingPlayer.SetActive(true);
            EndingController.Instance.HappyEnding();
        }
    }

    public void PieceReturn()
    {
        switch (katanaPiece)
        {
            case KatanaPiece.Sword:
                sword.SetActive(true);
                this.gameObject.tag = "Untagged";
                break;
            case KatanaPiece.Grtar:
                grtar.SetActive(true);
                this.gameObject.tag = "Untagged";
                break;
            case KatanaPiece.Halgr:
                halgr.SetActive(true);
                this.gameObject.tag = "Untagged";
                break;
        }

    }
}
