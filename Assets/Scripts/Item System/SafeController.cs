using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using InputSystem;

namespace ItemSystem
{
    public class SafeController : MonoBehaviour
    {
        [Header("Safe Model Reference")]
        [SerializeField] private GameObject safeModel = null;
        [SerializeField] private Transform safeDial = null;

        [Header("Animation References")]
        [SerializeField] private string safeAnimationName = "SafeDoorOpen";
        private Animator safeAnim;

        [Header("Animation Timers - Default: 1.0f / 0.5f")]
        [SerializeField] private float beforeAnimationStart = 1.0f;
        [SerializeField] private float beforeOpenDoor = 0.5f;

        [Header("Safe UI")]
        [SerializeField] private GameObject safeUI = null;

        [Header("Safe Solution: 0-9")]
        [Range(0, 9)][SerializeField] private int safeSolutionNum1 = 0;
        [Range(0, 9)][SerializeField] private int safeSolutionNum2 = 0;
        [Range(0, 9)][SerializeField] private int safeSolutionNum3 = 0;
        [Range(0, 9)][SerializeField] private int safeSolutionNum4 = 0;

        [Header("UI Numbers")]
        [SerializeField] private Text firstNumberUI = null;
        [SerializeField] private Text secondNumberUI = null;
        [SerializeField] private Text thirdNumberUI = null;
        [SerializeField] private Text fourthNumberUI = null;

        [Header("UI Arrows")]
        [SerializeField] private Button firstArrowUI = null;
        [SerializeField] private Button secondArrowUI = null;
        [SerializeField] private Button thirdArrowUI = null;
        [SerializeField] private Button fourthArrowUI = null;

        [Header("Sounds")]
        [SerializeField] private string interactSound = "SafeInteractSound";
        [SerializeField] private string dialClick = "SafeClick";
        [SerializeField] private string boltUnlock = "SafeBoltUnlock";
        [SerializeField] private string handleSpin = "SafeHandleSpin";
        [SerializeField] private string doorOpen = "SafeDoorOpen";
        [SerializeField] private string lockRattle = "SafeLockRattle";

        private bool firstNumber;
        private bool secondNumber;
        private bool thirdNumber;
        private bool fourthNumber;

        private bool disableClose = false;
        private int lockNumberInt;

        [Header("Trigger Type - ONLY if using a trigger event")]
        [SerializeField] private GameObject triggerObject = null;
        [SerializeField] private bool isTriggerInteraction = false;

        [Header("Unity Event - What happens when you open the safe?")]
        [SerializeField] private UnityEvent safeOpened = null;

        void Awake()
        {
            if (isTriggerInteraction)
            {
                disableClose = true;
            }

            disableClose = true;
            firstNumber = true;
            safeAnim = safeModel.gameObject.GetComponent<Animator>();

            firstNumberUI.color = Color.white;
            secondNumberUI.color = Color.gray;
            thirdNumberUI.color = Color.gray;
            fourthNumberUI.color = Color.gray;

            firstArrowUI.interactable = true;
            secondArrowUI.interactable = false;
            thirdArrowUI.interactable = false;
            fourthArrowUI.interactable = false;

            ColorBlock firstArrowCB = firstArrowUI.colors; 
            firstArrowCB.normalColor = Color.white; 
            firstArrowUI.colors = firstArrowCB;
            ColorBlock secondArrowCB = secondArrowUI.colors; 
            secondArrowCB.normalColor = Color.gray; 
            secondArrowUI.colors = secondArrowCB;
            ColorBlock thirdArrowCB = thirdArrowUI.colors; 
            thirdArrowCB.normalColor = Color.gray; 
            thirdArrowUI.colors = thirdArrowCB;
            ColorBlock fourthArrowCB = fourthArrowUI.colors; 
            thirdArrowCB.normalColor = Color.gray; 
            fourthArrowUI.colors = thirdArrowCB;
        }

        public void ShowSafeLock()
        {
            safeModel.tag = "Untagged";
            if (isTriggerInteraction)
            {
                disableClose = false;
                triggerObject.SetActive(false);
            }

            disableClose = false;
            safeUI.SetActive(true);
            InputSystems.Instance.isPanel = true;
            AudioManager.instance.Play(interactSound);
        }

        private void Update()
        {
            Debug.Log(firstNumberUI.text + secondNumberUI.text + thirdNumberUI.text + fourthNumberUI.text);
            Debug.Log(safeSolutionNum1.ToString("0") + safeSolutionNum2.ToString("0") + safeSolutionNum3.ToString("0") + safeSolutionNum4.ToString("0"));
        }

        private IEnumerator CheckCode()
        {
            string playerInputNumber = firstNumberUI.text + secondNumberUI.text + thirdNumberUI.text + fourthNumberUI.text;
            string safeSolution = safeSolutionNum1.ToString("0") + safeSolutionNum2.ToString("0") + safeSolutionNum3.ToString("0") + safeSolutionNum4.ToString("0");

            if (playerInputNumber == safeSolution)
            {
                InputSystems.Instance.isPanel = false;
                safeUI.SetActive(false);
                safeModel.tag = "Untagged";

                AudioManager.instance.Play(boltUnlock);
                yield return new WaitForSeconds(beforeAnimationStart);
                safeAnim.Play(safeAnimationName, 0, 0.0f);
                AudioManager.instance.Play(handleSpin);
                yield return new WaitForSeconds(beforeOpenDoor);
                AudioManager.instance.Play(doorOpen);

                if (isTriggerInteraction)
                {
                    disableClose = true;
                    triggerObject.SetActive(false);
                }

                safeOpened.Invoke();
            }
            else
            {
                InputSystems.Instance.isPanel = false;
                AudioManager.instance.Play(lockRattle);
                firstNumberUI.text = "0";
                secondNumberUI.text = "0";
                thirdNumberUI.text = "0";
                fourthNumberUI.text = "0";
                safeUI.SetActive(false);
                safeModel.tag = "Padlock";
                firstNumber = true;
                secondNumber = false;
                thirdNumber = false;
                fourthNumber = false;

                firstArrowUI.interactable = true;
                secondArrowUI.interactable = false;
                thirdArrowUI.interactable = false;
                fourthArrowUI.interactable = false;

                firstNumberUI.color = Color.white;
                secondNumberUI.color = Color.gray;
                thirdNumberUI.color = Color.gray;
                fourthNumberUI.color = Color.gray;

                ColorBlock firstArrowCB = firstArrowUI.colors; 
                firstArrowCB.normalColor = Color.white; 
                firstArrowUI.colors = firstArrowCB;
                ColorBlock secondArrowCB = secondArrowUI.colors; 
                secondArrowCB.normalColor = Color.gray; 
                secondArrowUI.colors = secondArrowCB;
                ColorBlock thirdArrowCB = thirdArrowUI.colors; 
                thirdArrowCB.normalColor = Color.gray; 
                thirdArrowUI.colors = thirdArrowCB;
                ColorBlock fourthArrowCB = fourthArrowUI.colors;
                fourthArrowCB.normalColor = Color.gray;
                fourthArrowUI.colors = fourthArrowCB;
                safeDial.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
                lockNumberInt = 0;
            }
        }

        public void AcceptKey()
        {
            EventSystem.current.SetSelectedGameObject(null);
            AudioManager.instance.Play(interactSound);

            if (firstNumber)
            {
                firstNumber = false;
                secondNumber = true;
                thirdNumber = false;
                fourthNumber = false;

                firstArrowUI.interactable = false;
                secondArrowUI.interactable = true;
                thirdArrowUI.interactable = false;
                fourthArrowUI.interactable = false;
                lockNumberInt = 0;
                secondNumberUI.text = lockNumberInt.ToString("0");

                firstNumberUI.color = Color.gray;
                secondNumberUI.color = Color.white;
                thirdNumberUI.color = Color.gray;
                fourthNumberUI.color = Color.gray;

                ColorBlock firstArrowCB = firstArrowUI.colors; 
                firstArrowCB.normalColor = Color.gray; 
                firstArrowUI.colors = firstArrowCB;
                ColorBlock secondArrowCB = secondArrowUI.colors; 
                secondArrowCB.normalColor = Color.white; 
                secondArrowUI.colors = secondArrowCB;
                ColorBlock thirdArrowCB = thirdArrowUI.colors; 
                thirdArrowCB.normalColor = Color.gray; 
                thirdArrowUI.colors = thirdArrowCB;
                ColorBlock fourthArrowCB = fourthArrowUI.colors;
                fourthArrowCB.normalColor = Color.gray;
                fourthArrowUI.colors = fourthArrowCB;
            }
            else if (secondNumber)
            {
                firstNumber = false;
                secondNumber = false;
                thirdNumber = true;
                fourthNumber = false;
                lockNumberInt = 0;
                thirdNumberUI.text = lockNumberInt.ToString("0");

                firstArrowUI.interactable = false;
                secondArrowUI.interactable = false;
                thirdArrowUI.interactable = true;
                fourthArrowUI.interactable = false;

                firstNumberUI.color = Color.gray;
                secondNumberUI.color = Color.gray;
                thirdNumberUI.color = Color.white;
                fourthNumberUI.color = Color.gray;

                ColorBlock firstArrowCB = firstArrowUI.colors; 
                firstArrowCB.normalColor = Color.gray; 
                firstArrowUI.colors = firstArrowCB;
                ColorBlock secondArrowCB = secondArrowUI.colors; 
                secondArrowCB.normalColor = Color.gray; 
                secondArrowUI.colors = secondArrowCB;
                ColorBlock thirdArrowCB = thirdArrowUI.colors; 
                thirdArrowCB.normalColor = Color.white; 
                thirdArrowUI.colors = thirdArrowCB;
                ColorBlock fourthArrowCB = fourthArrowUI.colors;
                fourthArrowCB.normalColor = Color.gray;
                fourthArrowUI.colors = fourthArrowCB;
            }
            else if (thirdNumber)
            {
                firstNumber = false;
                secondNumber = false;
                thirdNumber = false;
                fourthNumber = true;
                lockNumberInt = 0;
                fourthNumberUI.text = lockNumberInt.ToString("0");

                firstArrowUI.interactable = false;
                secondArrowUI.interactable = false;
                thirdArrowUI.interactable = false;
                fourthArrowUI.interactable = true;

                firstNumberUI.color = Color.gray;
                secondNumberUI.color = Color.gray;
                thirdNumberUI.color = Color.gray;
                fourthNumberUI.color = Color.white;

                ColorBlock firstArrowCB = firstArrowUI.colors;
                firstArrowCB.normalColor = Color.gray;
                firstArrowUI.colors = firstArrowCB;
                ColorBlock secondArrowCB = secondArrowUI.colors;
                secondArrowCB.normalColor = Color.gray;
                secondArrowUI.colors = secondArrowCB;
                ColorBlock thirdArrowCB = thirdArrowUI.colors;
                thirdArrowCB.normalColor = Color.gray;
                thirdArrowUI.colors = thirdArrowCB;
                ColorBlock fourthArrowCB = fourthArrowUI.colors;
                fourthArrowCB.normalColor = Color.white;
                fourthArrowUI.colors = fourthArrowCB;
            }
            else if (fourthNumber)
            {
                firstNumber = false;
                secondNumber = false;
                thirdNumber = false;
                fourthNumber = false;

                firstArrowUI.interactable = false;
                secondArrowUI.interactable = false;
                thirdArrowUI.interactable = false;
                fourthArrowUI.interactable = false;

                firstNumberUI.color = Color.gray;
                secondNumberUI.color = Color.gray;
                thirdNumberUI.color = Color.gray;
                fourthNumberUI.color = Color.gray;

                ColorBlock firstArrowCB = firstArrowUI.colors; firstArrowCB.normalColor = Color.gray; firstArrowUI.colors = firstArrowCB;
                ColorBlock secondArrowCB = secondArrowUI.colors; secondArrowCB.normalColor = Color.gray; secondArrowUI.colors = secondArrowCB;
                ColorBlock thirdArrowCB = thirdArrowUI.colors; thirdArrowCB.normalColor = Color.gray; thirdArrowUI.colors = thirdArrowCB;
                ColorBlock fourthArrowCB = thirdArrowUI.colors; fourthArrowCB.normalColor = Color.gray; fourthArrowUI.colors = fourthArrowCB;

                StartCoroutine(CheckCode());
            }
        }

        public void UpKey(int lockNumberSelection)
        {
            EventSystem.current.SetSelectedGameObject(null);
            AudioManager.instance.Play(dialClick);

            if (firstNumber && lockNumberSelection == 1)
            {
                if (lockNumberInt <= 8)
                {
                    safeDial.transform.Rotate(0.0f, 0.0f, -22.5f, Space.Self);
                    lockNumberInt++;
                    firstNumberUI.text = lockNumberInt.ToString("0");
                }
                else
                {
                    lockNumberInt = 0;
                    safeDial.transform.Rotate(0.0f, 0.0f, -22.5f, Space.Self);
                    firstNumberUI.text = lockNumberInt.ToString("0");
                }
            }

            if (secondNumber && lockNumberSelection == 2)
            {
                if (lockNumberInt <= 8)
                {
                    safeDial.transform.Rotate(0.0f, 0.0f, 22.5f, Space.Self);
                    lockNumberInt++;
                    secondNumberUI.text = lockNumberInt.ToString("0");
                }
                else
                {
                    lockNumberInt = 0;
                    safeDial.transform.Rotate(0.0f, 0.0f, 22.5f, Space.Self);
                    secondNumberUI.text = lockNumberInt.ToString("0");
                }
            }

            if (thirdNumber && lockNumberSelection == 3)
            {
                if (lockNumberInt <= 8)
                {
                    safeDial.transform.Rotate(0.0f, 0.0f, -22.5f, Space.Self);
                    lockNumberInt++;
                    thirdNumberUI.text = lockNumberInt.ToString("0");
                }
                else
                {
                    lockNumberInt = 0;
                    safeDial.transform.Rotate(0.0f, 0.0f, -22.5f, Space.Self);
                    thirdNumberUI.text = lockNumberInt.ToString("0");
                }
            }

            if (fourthNumber && lockNumberSelection == 4)
            {
                if (lockNumberInt <= 8)
                {
                    safeDial.transform.Rotate(0.0f, 0.0f, 22.5f, Space.Self);
                    lockNumberInt++;
                    fourthNumberUI.text = lockNumberInt.ToString("0");
                }
                else
                {
                    lockNumberInt = 0;
                    safeDial.transform.Rotate(0.0f, 0.0f, 22.5f, Space.Self);
                    fourthNumberUI.text = lockNumberInt.ToString("0");
                }
            }
        }
    }
}