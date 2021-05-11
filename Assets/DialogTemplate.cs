using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ImagewithDialog
{
    [TextArea]
    public string Dialog;
    public Sprite faceSprite;
    public int fontsize;
    public Color textcolor;
    public float timeitdisappear = 3.0f;
}
public class DialogTemplate : MonoBehaviour
{
    public ImagewithDialog[] dialogs;
    public GameObject Dialogbox;
    public GameObject BackgroudDialogbox;
    public GameObject playerIcon;
    public float fadedtime = 3.0f;
    bool isActive = false;
    float curralpha = 0.0f;
    Text dialogboxtext;
    Image imageface;
    bool Actived = false;
    bool Finishdisplay = false;
    bool isPlayingText = false;
    int textindex = 0;
    void Start()
    {
        dialogboxtext = Dialogbox.GetComponent<Text>();
        imageface = playerIcon.GetComponent<Image>();
    }
    void Update()
    {
        if (textindex >= dialogs.Length)
        {
            isActive = false;
        }
        if (isActive && Finishdisplay)
        {
            StartCoroutine(Delaytime());
        }
        if (isActive)
        {
            if (curralpha < 1)
            {
                curralpha += 1 / fadedtime * Time.deltaTime;
                dialogboxtext.color = new Color(dialogs[textindex].textcolor.r, dialogs[textindex].textcolor.g, dialogs[textindex].textcolor.b, curralpha);
                imageface.color = new Color(imageface.color.r, imageface.color.g, imageface.color.b, curralpha);
            }
            Dialogbox.SetActive(true);
            BackgroudDialogbox.SetActive(true);
            playerIcon.SetActive(true);
        }
        else
        {
            Dialogbox.SetActive(false);
            BackgroudDialogbox.SetActive(false);
            playerIcon.SetActive(false);
        }
    }
    IEnumerator Delaytime()
    {
        Finishdisplay = false;
        dialogboxtext.text = dialogs[textindex].Dialog;
        dialogboxtext.fontSize = dialogs[textindex].fontsize;
        imageface.sprite = dialogs[textindex].faceSprite;
        yield return new WaitForSeconds(dialogs[textindex].timeitdisappear);
        textindex++;
        curralpha = 0;
        Finishdisplay = true;

    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player") && !Actived)
        {
            dialogboxtext.text = dialogs[textindex].Dialog;
            dialogboxtext.fontSize = dialogs[textindex].fontsize;
            dialogboxtext.color = dialogs[textindex].textcolor;
            curralpha = 0;
            Finishdisplay = true;
            isActive = true;
            Actived = true;
        }
    }
}
