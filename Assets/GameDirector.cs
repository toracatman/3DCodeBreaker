using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

	GameObject number;	//入力した数字
	GameObject history;	//検証履歴
	GameObject result;	//結果

	int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};	//数字
	int[] answer = new int[5];	//答え

	int kaisuu = 0;	//検証回数
	int jun = 0;	//順番
	int[] a1 = new int[5];	//回答
	string answers = "クリックして数字が書かれた箱に\nボールをぶつけて5桁の重複のない数字を入力";	//回答の文字列
	string historys = "";	//検証履歴の文字列
	string results = "HIT:当たった数字の数\nBLOW:当たっていないけど含まれている数字の数";	//結果の文字列

	int error = 0;	//エラー
	int hit = 0;	//当たった数字の数
	int blow = 0;	//当たってないけどある数字の数

	//数字の入力
	public void NumberInput(int number) {
		if (jun == 0) {
			answers = "";
		}
		a1 [jun] = number;
		answers += a1[jun];
		jun++;
		if (jun == 5) {
			Hantei ();
		}
	}

	//判定
	void Hantei(){
		for (int i = 0; i < 5; i++) {
			int hitf = 0;	//ヒットフラグ
			int blowf = 0;	//ブローフラグ
			for (int j = 0; j < 5; j++) {
				if (i == j)
					continue;

				//重複
				if (a1 [i] == a1 [j]) {
					error = 1;
				}

				//Hit
				if (a1 [i] == answer [i]) {
					hitf = 1;
				}

				//Blow
				else if (a1 [i] == answer [j]) {
					blowf = 1;
				}
			}
			if (hitf == 1) hit++;
			if (blowf == 1) blow++;
		}
		if (error == 1) {
			results = "正しくない値を入力しています。";
			error = 0;
		} else {
			results = "";
			kaisuu++;
			historys += kaisuu + ": " + answers + ": " + hit + "HIT " + blow + "BLOW";
			if (hit == 5) {
				historys += " CLEAR!!";
				if (kaisuu <= 5) {
					this.result.GetComponent<Text> ().fontSize = 40;
					results = "ネ申！！";
				} else if (kaisuu <= 10) {
					this.result.GetComponent<Text> ().fontSize = 40;
					results = "素晴らしい！";
				} else {
					results = kaisuu + "回検証";
				}
			}
			historys += "\n";
		}
		hit = 0;
		blow = 0;
		jun = 0;
	}

	// Use this for initialization
	void Start () {
		this.number = GameObject.Find ("Number");
		this.history = GameObject.Find ("History");
		this.result = GameObject.Find ("Result");

		//答えを作る
		int rand;
		int len = arr.Length;
		for (int i = 0; i < 5; i++) {
			rand = Random.Range (0, len);
			answer [i] = arr [rand];
			arr [rand] = arr [len - 1];
			len--;
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.number.GetComponent<Text> ().text = answers;
		this.history.GetComponent<Text> ().text = historys;
		this.result.GetComponent<Text> ().text = results;
	}
}
