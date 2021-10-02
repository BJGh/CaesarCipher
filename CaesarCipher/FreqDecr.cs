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
		/*private readonly Dictionary<char, double> ruFrequencies = new Dictionary<char, double>()
            {
         {'а',0.062},{'б',0.014},{'в',0.038},{'г',0.013},{'д',0.025},{'е',0.072},
        {'ё',0.072},{'ж',0.007},{'з',0.016},{'и',0.062},{'й',0.010},{'к',0.028},{'л',0.035},
        {'м',0.026},{'н',0.053},{'о',0.090},{'п',0.023},{'р',0.040},{'с',0.045},{'т',0.053},
        {'у',0.021},{'ф',0.002},{'х',0.009},{'ц',0.004},{'ч',0.012},{'ш',0.006},{'щ',0.003},
        {'ъ',0.014},{'ы',0.016},{'э',0.003},{'ю',0.006},{'я',0.018}
            };*/
		private Dictionary<char, double> normalFrequency = new Dictionary<char, double>();
		private Dictionary<char, double> encryptedFrequency = new Dictionary<char, double>();
		private Dictionary<char,char> replaceDictionary = new Dictionary<char,char>();
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
		
		public void crackText()
        {
			//var ordered = encryptedFrequency.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
			//отсортировал по убыванию частоты
			encryptedFrequency = encryptedFrequency.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
			normalFrequency = normalFrequency.OrderByDescending(x=>x.Value).ToDictionary(x=>x.Key,x=>x.Value);

			FileProcessor fp = new FileProcessor();
			string res = "";
			double normal = 0.0;
			double encrypted = 0.0;
			List<char> rep = new List<char>();
			StreamReader reader = new StreamReader("caesarencrypt.txt");
			List<char> characters = new List<char>();
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
			
				characters.AddRange(line);

			}
			for(i=0;i<33;i++)
			{
				if(normalFrequency
			}
			Console.Write(res);

		//	fp.writeFileDecryption(res);
		}


	}
}
