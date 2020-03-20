using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Networking;
using Proyecto26;
using UnityEngine.SceneManagement;

public class LoginManagement : MonoBehaviour
{
    public GameObject canvas;
    public GameObject parentPanel;

    [Header("Login")]
    public GameObject loginPanel;
    public InputField loginPanelEmail;
    public InputField loginPanelPassword;
    [Header("Error")]
    public GameObject errorParent;
    public Text errorText;
    [Header("Message")]
    public GameObject messagePanel;
    public Text messageText;
    //public Text loginPanelErrorText;

    private string databaseURL = "https://test1-be462.firebaseio.com/user/Users";
    private string AuthKey = "AIzaSyA79Y96XJYFzEhO_yxligbpqsZKi6-qyaY";

    private string PlayerName;
    private string PlayerPassword;
    private bool UserFlag;
    private bool PasswordFlag;
    // Start is called before the first frame update
    void Start()
    {
        UserFlag = false;
        PasswordFlag = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnLogin()
    {
        if (loginPanelEmail.text == "")
        {
            loginPanelEmail.ActivateInputField();
            errorParent.SetActive(true);
            errorText.text = "Email is invalid.";
            //loginPanelErrorText.text = "Email is invalid.";
        }
        else if (loginPanelPassword.text == "")
        {
            loginPanelPassword.ActivateInputField();
            errorParent.SetActive(true);
            errorText.text = "Password is invalid.";
            //loginPanelErrorText.text = "Password is invalid.";
        }
        else
        {
            LoginRequest(loginPanelEmail.text, loginPanelPassword.text);
            Debug.Log("username:" + loginPanelEmail.text);
        }

    }
    public void LoginRequest(string email, string password)
    {
        errorParent.SetActive(false);
        string requestUrl = databaseURL + "/" + email + ".json" /* ?auth=" + idToken */;

         RestClient.Get<LoginUser>(requestUrl).Then(response =>
         {
             UserFlag = true;
             //PlayerName = response.userid;
             PlayerPassword = response.password;
             Debug.Log("password:" + PlayerPassword);

             if (PlayerPassword == loginPanelPassword.text)
             {
                 PasswordFlag = true;
                 Scene nextScene;
                 nextScene = SceneManager.GetSceneByName("Train");
                 SceneManager.LoadScene("Train");
                 SceneManager.SetActiveScene(nextScene);
                 Debug.Log("next scene:" + "Train" + nextScene.isLoaded);
             }
         });
        Debug.Log("Userfalg:" + UserFlag);
        OnMessagePanel();
    }
    public void OnMessagePanel()
    {
        
        string email = loginPanelEmail.text;
        string password = loginPanelPassword.text;
        Debug.Log("email:" + loginPanelEmail.text + "password:" + loginPanelPassword.text + "userFlag:" + UserFlag + "passwordflag:" + PasswordFlag);
        if (!UserFlag)
            messageText.text = "This user can't be found! Please check your email.";
        else if(!PasswordFlag)
            messageText.text = "Incorrect password. Try again";
        messagePanel.SetActive(true);
    }

    public void OnMessagePanelClose()
    {
        messagePanel.SetActive(false);
    }
    public void OnValueChange()
    {

    }
}
