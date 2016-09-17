/*
Camera Fade In: 
Script que a partir de un sprite que oscurece la escena, realiza un fade in. 
Ideal para cuando se ingresa a una escena.
*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraFadeIn : MonoBehaviour
{
	/*
	 * Requiere un Sprite en color negro acomodado en la pantalla
	*/
	public SpriteRenderer blackSprite;

	void Awake() {

		if (blackSprite == null)
			return;

		Color spriteColor = blackSprite.color; 
		spriteColor.a = 1.0f;
		blackSprite.color = spriteColor;

	}

    IEnumerator Start()
    {
		if (blackSprite == null)
			yield break;

		Color spriteColor;
		while (blackSprite.color.a>0){
			spriteColor = blackSprite.color; 
			spriteColor.a -= Time.deltaTime / 2;
			blackSprite.color = spriteColor;

			yield return null;
		}
			
		yield return null;
    }


}
