﻿using UnityEngine;
using AdventurePuzzleKit;

namespace ThemedKeySystem
{
    public class ThemedKeyController : MonoBehaviour
    {
        [Header("Type of Key")]
        [SerializeField] private KeyTheme keyType = KeyTheme.None;

        [Header("Key Pickup Sound")]
        [SerializeField] private string keySound = "ThemedKeyPickup";

        public enum KeyTheme { None, Heart, Diamond, Club, Spade, Red, Blue }

        public void KeyPickup()
        {
            switch (keyType)
            {
                case KeyTheme.Heart:
                    ThemedKeyInventoryController.instance.UpdateInventory("Heart");
                    break;
                case KeyTheme.Diamond:
                    ThemedKeyInventoryController.instance.UpdateInventory("Diamond");
                    break;
                case KeyTheme.Club:
                    ThemedKeyInventoryController.instance.UpdateInventory("Club");
                    break;
                case KeyTheme.Spade:
                    ThemedKeyInventoryController.instance.UpdateInventory("Spade");
                    break;
                case KeyTheme.Red:
                    ThemedKeyInventoryController.instance.UpdateInventory("Red");
                    break;
                case KeyTheme.Blue:
                    ThemedKeyInventoryController.instance.UpdateInventory("Blue");
                    break;
            }
            PickupSound();
            gameObject.SetActive(false);
        }

        void PickupSound()
        {
            AKAudioManager.instance.Play(keySound);
        }
    }
}
