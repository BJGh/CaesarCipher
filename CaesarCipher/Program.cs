using System;
using System.IO;
//Ошибки:

//дешифровать файл методом частотного анализа
namespace CaesarCipher
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Caesar Cipher");
			Console.WriteLine("Enter the key");
			int k = Convert.ToInt32(Console.ReadLine());
			FileProcessor fp = new FileProcessor();
			//fp.Key = k;
			fp.readFileCrypted(k);
			Console.WriteLine("Text successfully crypted. File saved.");
			Console.WriteLine("Start decrypting frequency analysis...");
			//fp.readFileDecrypt();
			FreqDecr freq = new FreqDecr();
			freq.countFrequencyNormalText();
			freq.countFrequencyEncryptedlText();
			//freq.showDictionaries();
			freq.crackText();
		}
	}
}