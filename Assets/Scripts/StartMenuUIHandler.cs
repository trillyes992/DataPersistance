using UnityEngine;
using UnityEngine.UI;
public class StartMenuUIHandler : MonoBehaviour
{

        //this method is called when finishing Input ID
    //so,it shouldn't exist in the main scene
    public static void UpdateScreen()
    {
        
        StartMenuManager.ID = FindObjectOfType<InputField>().text;
            
        
        try
        {
            StartMenuManager.ID = FindObjectOfType<InputField>().text;
            FindObjectOfType<Text>().text = "欢迎你，" + StartMenuManager.ID;
        }
        catch
        {

        }
        
        
    }
}