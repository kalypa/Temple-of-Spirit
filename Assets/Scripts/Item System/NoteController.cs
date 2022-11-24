using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ItemInven
{
    public class NoteController : SingleMonobehaviour<NoteController>
    {
        private GameObject notePanel;

        public void ExpensionNote()
        {
            notePanel.SetActive(true);
        }


    }
}
