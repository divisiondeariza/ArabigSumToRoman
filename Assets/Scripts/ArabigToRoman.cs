using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArabigToRoman : MonoBehaviour {

	public int inputNumber1;
	public int inputNumber2;

	private string[] unitsSymbols = new string[3]{"I", "V", "X"};
	private string[] tenthsSymbols = new string[3]{"X", "L", "C"};
	private string[] hundredthsSymbols = new string[3]{"C", "D", "M"};
	private string[] thousandthsSymbols = new string[3]{"M", "[V]", "[X]"}; 




	void Start(){

	}

	void Update () {
		int inputNumber = inputNumber1 + inputNumber2;

		print(intToRoman (inputNumber));

	}

	string intToRoman (int inputInteger){
		int units = inputInteger % 10;
		int tenths = (inputInteger / 10) % 10;
		int hundreths = (inputInteger / 100) % 10;
		int thousandth = (inputInteger / 1000) % 10;

		string romanUnits = parseArabicDigitToRomanStructure (units, unitsSymbols);
		string romanTenths = parseArabicDigitToRomanStructure (tenths, tenthsSymbols);
		string romanHundredths = parseArabicDigitToRomanStructure (hundreths, hundredthsSymbols);
		string romanThousandths = parseArabicDigitToRomanStructure (thousandth, thousandthsSymbols);

		return romanThousandths + romanHundredths + romanTenths + romanUnits;
	}

	string parseArabicDigitToRomanStructure (int inputDigit, string[] symbols){
		if (inputDigit < 4) {
			return MultiplyString (symbols[0], inputDigit);
		} else if (inputDigit == 4) {
			return symbols[0] + symbols[1];
		} else if (inputDigit < 9) {
			return symbols[1] + MultiplyString (symbols[0], inputDigit % 5);
		} else if (inputDigit == 9) {
			return symbols[0] + symbols[2];
		} else {
			return "ERROR";
		}

	
	}

	string MultiplyString (string str, int ocurrencies){
		string outputString = "";
		for (int i = 0; i < ocurrencies; i++) {
			outputString = outputString + str;
		}

		return outputString;
	}
}
