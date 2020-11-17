using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("紅龍")]
    public Transform RedDragon;
    [Header("藍龍")]
    public Transform BlueDragon;
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("旋轉速度"),Range(0.01f,1.5f)]
    public float turn = 0.5f;
    [Header("縮放"), Range(0.01f, 1.5f)]
    public float size = 0.3f;
    [Header("紅龍動畫元件")]
    public Animator aniRed;
    [Header("藍龍動畫元件")]
    public Animator aniBlue;
    [Header("按鈕")]
    public Toggle walk;
    public Button attack;
    public Button fly;
    public Button land;
    public Button flame;


    public string ClipName;
    public AnimatorClipInfo[] ClipInfo;

    
    private void Update()
    {
        RedDragon.Rotate(0, joystick.Horizontal * turn, 0);
        BlueDragon.Rotate(0, joystick.Horizontal * turn, 0);

        RedDragon.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;
        RedDragon.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(RedDragon.localScale.x, 0.1f, 1.5f);

        BlueDragon.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;
        BlueDragon.localScale = new Vector3(1, 1, 1) * Mathf.Clamp(BlueDragon.localScale.x, 0.1f, 1.5f);

        AnimatorStateInfo R_State = aniRed.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo B_State = aniBlue.GetCurrentAnimatorStateInfo(0);

        if (R_State.nameHash==Animator.StringToHash("Base Layer.R_飛行"))
        {
            print("fly");
            flame.interactable = true;
            attack.interactable = false;
        }
        else
        {
            flame.interactable = false;
            attack.interactable = true;
        }

        if (B_State.nameHash == Animator.StringToHash("Base Layer.B_飛行"))
        {
            print("fly");
            flame.interactable = true;
            attack.interactable = false;
        }
        else
        {
            flame.interactable = false;
            attack.interactable = true;
        }

    }

    public void Walk()
    {
        if (walk.isOn == true)
        {
            print("on");
            aniRed.SetBool("走路開關", true);
            aniBlue.SetBool("走路開關", true);
            attack.interactable = false;
            fly.interactable = false;
            land.interactable = false;
        }
        else
        {
            aniRed.SetBool("走路開關", false);
            aniBlue.SetBool("走路開關", false);
            attack.interactable = true;
            fly.interactable = true;
            land.interactable = true;
        }
    }


    public void Attack()
    {
        aniRed.SetTrigger("攻擊觸發");
        aniBlue.SetTrigger("攻擊觸發");
    }

    public void PlayAnimation(string aniName)
    {
        aniRed.SetTrigger(aniName);
        aniBlue.SetTrigger(aniName);
    }

}
