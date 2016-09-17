/*
Camera Splash Fade: 
Script que a partir de un sprite que oscurece la escena, realiza un fade in, luego espera un segundo, 
siguiendo con un fade out para finalizar derivando a la siguiente escena. 
Ideal para una escena de tipo splash.
*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraSplashFade : MonoBehaviour
{
	public SpriteRenderer blackSprite;
    public string loadLevel;

	/*
	Inicializa colocando el sprite oscuro con alpha = 1
	para que la escena aparezca oscura.
	*/
	void Awake() {

		if (blackSprite == null)
			return;

		Color spriteColor = blackSprite.color; 
		spriteColor.a = 1.0f;
		blackSprite.color = spriteColor;

	}
		
	/*
	Realiza el resto de la operaciones 
	*/
    IEnumerator Start()
    {
		if( blackSprite == null )
			yield break;
		
		Color spriteColor;
		// Comienza a poner progresivamente el alpha a 0 (se visualiza la escena)
		while ( blackSprite.color.a > 0 ){
			spriteColor = blackSprite.color; 
			spriteColor.a -= Time.deltaTime / 2;
			blackSprite.color = spriteColor;
			yield return null;
		}

		// Espera un segundo para que se visualice la escena
		yield return new WaitForSeconds(1);

		// Continua colocando progresivamente el sprite oscuro a 1 (se oscurece la escena)
		while ( blackSprite.color.a < 1 ){
			spriteColor = blackSprite.color; 
			spriteColor.a += Time.deltaTime / 2;
			blackSprite.color = spriteColor;
			yield return null;
		}

		// Carga la siguiente escena
		SceneManager.LoadScene(loadLevel);
		yield return null;
    }


}
