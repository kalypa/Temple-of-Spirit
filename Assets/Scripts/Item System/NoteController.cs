using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystem;

namespace ItemInven
{
    public class NoteController : SingleMonobehaviour<NoteController>
    {
        [SerializeField] private GameObject notePanel;

        public void ExpensionNote()
        {
            InputSystems.Instance.isPanel = true;
            notePanel.SetActive(true);
        }


    }
}
