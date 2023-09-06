using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsHandler : MonoBehaviour
{
    Color color1 = Color.red;
    Color color2 = Color.green;
    Color color3 = new Color(0,1,1);

    // All colored prefabs
    public GameObject redEnemy;
    public GameObject greenEnemy;
    public GameObject blueEnemy;
    public GameObject redSplitter;
    public GameObject greenSplitter;
    public GameObject blueSplitter;
    public GameObject redStageAttack;
    public GameObject greenStageAttack;
    public GameObject blueStageAttack;

    bool colorsChanged = false;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start() {
        transform.Find("ColorsLabels/Color1/Chosen1").GetComponent<TMPro.TextMeshProUGUI>().color = color1;
        transform.Find("ColorsLabels/Color2/Chosen2").GetComponent<TMPro.TextMeshProUGUI>().color = color2;
        transform.Find("ColorsLabels/Color3/Chosen3").GetComponent<TMPro.TextMeshProUGUI>().color = color3;
    }

    void Update()
    {
    }

    public void EnterSettings(){
        foreach(Transform settingsChild in transform){
            settingsChild.gameObject.SetActive(true);
        }
    }

    public void ExitSettings(){
        foreach(Transform settingsChild in transform){
            settingsChild.gameObject.SetActive(false);
        }
        if(colorsChanged){
            // get every item in the scene and change their color here
            ChangeAllColors();
            colorsChanged = false;
        }
        GameObject.Find("PauseMenuController").GetComponent<PauseScript>().inSettings = false;
    }

    public void SetColorOne(string color){
        if(transform.Find("ColorsLabels/Color1/Chosen1").GetComponent<TMPro.TextMeshProUGUI>().text != color){
            switch(color){
                case "Red":
                    color1 = new Color(1,0,0);
                    break;
                case "Green":
                    color1 = new Color(0,1,0);
                    break;
                case "Blue":
                    color1 = new Color(0,1,1);
                    break;
                case "Yellow":
                    color1 = new Color(1,1,0);
                    break;
                case "Navy":
                    color1 = new Color(0,0,1);
                    break;
                case "Pink":
                    color1 = new Color(1,0,1);
                    break;
                default:
                    color1 = new Color(1,0,0);
                    break;
            }
            transform.Find("ColorsLabels/Color1/Chosen1").GetComponent<TMPro.TextMeshProUGUI>().color = color1;
            transform.Find("ColorsLabels/Color1/Chosen1").GetComponent<TMPro.TextMeshProUGUI>().text = color;
            colorsChanged = true;
        }
    }

    public void SetColorTwo(string color){
        if(transform.Find("ColorsLabels/Color2/Chosen2").GetComponent<TMPro.TextMeshProUGUI>().text != color){
            switch(color){
                case "Red":
                    color2 = new Color(1,0,0);
                    break;
                case "Green":
                    color2 = new Color(0,1,0);
                    break;
                case "Blue":
                    color2 = new Color(0,1,1);
                    break;
                case "Yellow":
                    color2 = new Color(1,1,0);
                    break;
                case "Navy":
                    color2 = new Color(0,0,1);
                    break;
                case "Pink":
                    color2 = new Color(1,0,1);
                    break;
                default:
                    color2 = new Color(0,1,0);
                    break;
            }
            transform.Find("ColorsLabels/Color2/Chosen2").GetComponent<TMPro.TextMeshProUGUI>().color = color2;
            transform.Find("ColorsLabels/Color2/Chosen2").GetComponent<TMPro.TextMeshProUGUI>().text = color;
            colorsChanged = true;
        }
    }

    public void SetColorThree(string color){
        if(transform.Find("ColorsLabels/Color3/Chosen3").GetComponent<TMPro.TextMeshProUGUI>().text != color){
            switch(color){
                case "Red":
                    color3 = new Color(1,0,0);
                    break;
                case "Green":
                    color3 = new Color(0,1,0);
                    break;
                case "Blue":
                    color3 = new Color(0,1,1);
                    break;
                case "Yellow":
                    color3 = new Color(1,1,0);
                    break;
                case "Navy":
                    color3 = new Color(0,0,1);
                    break;
                case "Pink":
                    color3 = new Color(1,0,1);
                    break;
                default:
                    color3 = new Color(0,1,1);
                    break;
            }
            transform.Find("ColorsLabels/Color3/Chosen3").GetComponent<TMPro.TextMeshProUGUI>().color = color3;
            transform.Find("ColorsLabels/Color3/Chosen3").GetComponent<TMPro.TextMeshProUGUI>().text = color;
            colorsChanged = true;
        }
    }

    public void ChangeAllColors(){
        // set colors for all prefabs
        redEnemy.GetComponent<ColorSet>().color = color1;
        greenEnemy.GetComponent<ColorSet>().color = color2;
        blueEnemy.GetComponent<ColorSet>().color = color3;
        redSplitter.GetComponent<ColorSet>().color = color1;
        greenSplitter.GetComponent<ColorSet>().color = color2;
        blueSplitter.GetComponent<ColorSet>().color = color3;
        redStageAttack.GetComponent<ColorSet>().color = color1;
        greenStageAttack.GetComponent<ColorSet>().color = color2;
        blueStageAttack.GetComponent<ColorSet>().color = color3;

        //get all existing things and set their color
        foreach(GameObject thing in UnityEngine.Object.FindObjectsOfType<GameObject>()){
            if(thing.GetComponent<ColorSet>() != null){
                // each colored object has a layer set for it, except stage attacks.  they will be the default
                switch(thing.tag){
                    case "Enemy":
                        if(thing.layer == 6){
                            thing.GetComponent<ColorSet>().SetColor(color1);
                        } else if(thing.layer == 7){
                            thing.GetComponent<ColorSet>().SetColor(color2);
                        } else if(thing.layer == 8){
                            thing.GetComponent<ColorSet>().SetColor(color3);
                        }
                        break;
                    case "RedSafeZone":
                        thing.GetComponent<ColorSet>().SetColor(color1);
                        break;
                    case "GreenSafeZone":
                        thing.GetComponent<ColorSet>().SetColor(color2);
                        break;
                    case "BlueSafeZone":
                        thing.GetComponent<ColorSet>().SetColor(color3);
                        break;
                    case "RedStageAttack":
                        thing.GetComponent<ColorSet>().SetColor(color1);
                        break;
                    case "GreenStageAttack":
                        thing.GetComponent<ColorSet>().SetColor(color2);
                        break;
                    case "BlueStageAttack":
                        thing.GetComponent<ColorSet>().SetColor(color3);
                        break;
                }
            }
        }
    }
}
