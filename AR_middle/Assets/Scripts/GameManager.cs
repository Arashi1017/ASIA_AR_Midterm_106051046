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

    public bool walk;


    
    


    private void Start()
    {
        
    }

    private void Update()
    {
        RedDragon.Rotate(0, joystick.Horizontal * turn, 0);
        BlueDragon.Rotate(0, joystick.Horizontal * turn, 0);

        RedDragon.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;

    }

    public void WalkToggle()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
        {
            walk = true;
        }else
            walk = false;

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
