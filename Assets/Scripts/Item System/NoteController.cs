using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystem;
using ItemSystem;
namespace ItemInven
{
    public class NoteController : MonoBehaviour
    {
        [SerializeField] private GameObject notePanel;
        [SerializeField] private PlayerRaycast playerRaycast;

        public void ExpensionNote()
        {
            InputSystems.Instance.isPanel = true;
            this.tag = "Untagged";
            playerRaycast.rayhitF = true;
            notePanel.SetActive(true);
        }


    }
}
