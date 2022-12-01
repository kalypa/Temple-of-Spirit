using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInven;
public class EndingItemController : MonoBehaviour
{
    [SerializeField] private ThemedKeyInventoryController themedKeyInventoryController;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject grtar;
    [SerializeField] private GameObject halgr;
    [SerializeField] private GameObject endingPlayer;
    [HideInInspector] public bool isEnd;
    public enum KatanaPiece
    { Sword, Grtar, Halgr }
    public KatanaPiece katanaPiece;

    private void Update()
    {
        if(sword.activeSelf && halgr.activeSelf && grtar.activeSelf)
        {
            endingPlayer.SetActive(true);
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
