using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
//игнорить запятые и знаки препинания.
namespace CaesarCipher
{
	class FreqDecr
	{
		
	
		private double valueFrequency(int lettercount,int letter)
        {
			return Math.Round(((double)letter / (double)lettercount), 2);
        }
	
		private Dictionary<char, double> normalFrequency = new Dictionary<char, double>();
		private Dictionary<char, double> encryptedFrequency = new Dictionary<char, double>();
		private Dictionary<char, char> resultDictionary = new Dictionary<char, char>();
		Dictionary<char, int> normalTextCount = new Dictionary<char, int>() {
			 {'а',0},{'б',0},{'в',0},{'г',0},{'д',0},{'е',0},
			{'ё',0},{'ж',0},{'з',0},{'и',0},{'й',0},{'к',0},{'л',0},
			{'м',0},{'н',0},{'о',0},{'п',0},{'р',0},{'с',0},{'т',0},
			{'у',0},{'ф',0},{'х',0},{'ц',0},{'ч',0},{'ш',0},{'щ',0},
			{'ъ',0},{'ы',0},{'ь',0},{'э',0},{'ю',0},{'я',0}
				};
		Dictionary<char, int> encryptedTextCount = new Dictionary<char, int>() {
			 {'а',0},{'б',0},{'в',0},{'г',0},{'д',0},{'е',0},
			{'ё',0},{'ж',0},{'з',0},{'и',0},{'й',0},{'к',0},{'л',0},
			{'м',0},{'н',0},{'о',0},{'п',0},{'р',0},{'с',0},{'т',0},
			{'у',0},{'ф',0},{'х',0},{'ц',0},{'ч',0},{'ш',0},{'щ',0},
			{'ъ',0},{'ы',0},{'ь',0},{'э',0},{'ю',0},{'я',0}
				};
		public void saveFrequencies()
        {
			encryptedFrequency = encryptedFrequency.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
			normalFrequency = normalFrequency.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
	
			List<char> normalList = new List<char>(this.normalFrequency.Keys);
			List<char> encryptedList = new List<char>(this.encryptedFrequency.Keys);

			resultDictionary = normalList.Zip(encryptedList, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
			Console.WriteLine("done here");
		}
		public void countFrequencyNormalText()
		{
			StreamReader sr = new StreamReader("chapter1.txt");
			int countAllLetters = 0;
			List<char> lines = new List<char>();
			while(!sr.EndOfStream)
            {
				string line = sr.ReadLine();
				line.Replace(" ", "");
				line.Replace("\\p{P}+", "");

				lines.AddRange(line);
            }
			sr.Close();
		foreach (char ch in lines)
            {
				if (char.IsWhiteSpace(ch) || char.IsDigit(ch) || char.IsPunctuation(ch) || char.IsSeparator(ch))
				{
					continue;
				}
                else
				{
					++countAllLetters;
					normalTextCount[char.ToLower(ch)]++;
				}

            }

		foreach(var chDictionary in normalTextCount.Keys)
            {
				if(normalTextCount[chDictionary]!=0)
                {
					double letterfrequency = Math.Round(valueFrequency(countAllLetters, normalTextCount[chDictionary]),2);
					normalFrequency.Add(chDictionary, letterfrequency);
                }
            }//подсчет частоты букв в обычном тексте.
		
		}

		public void countFrequencyEncryptedlText()
		{
			StreamReader sr = new StreamReader("caesarencrypt.txt");
			int countAllLettersEncrypted = 0;
			List<char> lines = new List<char>();
			while (!sr.EndOfStream)
			{
				string line = sr.ReadLine();
				line.Replace(" ", "");
				line.Replace("\\p{P}+", "");
				lines.AddRange(line);
			}
			sr.Close();
			foreach (char ch in lines)
			{
				if (char.IsWhiteSpace(ch) || char.IsDigit(ch) || char.IsPunctuation(ch) || char.IsSeparator(ch))
				{
					continue;
				}
				else
				{
					++countAllLettersEncrypted;
					encryptedTextCount[char.ToLower(ch)]++;
				}
			}

			foreach (var chDictionary in encryptedTextCount.Keys)
			{
				if (encryptedTextCount[chDictionary] != 0)
				{
					double letterfrequency = Math.Round(valueFrequency(countAllLettersEncrypted, encryptedTextCount[chDictionary]), 2);
					encryptedFrequency.Add(chDictionary, letterfrequency);
				}
			}//подсчет частоты букв в зашифрованном тексте
			sr.Close();

		}


	
		public void writeFileDecryption(string v)
		{
			string fileName = "result.txt";
			var Writer = new StreamWriter(fileName, true);
			Writer.WriteLine(v);
			Writer.Close();
		}

		public void crackText()
        {
	

			FileProcessor fp = new FileProcessor();
			string res = "";
			

			StreamReader reader = new StreamReader("caesarencrypt.txt");
			List<char> characters = new List<char>();
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
			

				characters.AddRange(line);

			}
			foreach(char ech in characters)
            {
				if (char.IsWhiteSpace(ech) || char.IsDigit(ech) || char.IsPunctuation(ech) || char.IsSeparator(ech))
				{
					res += ech;
				}
				else
				{

					res += resultDictionary[char.ToLower(ech)];
		

				}
			}
			writeFileDecryption(res);

        }


    }
}

