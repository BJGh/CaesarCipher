using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CaesarCipher
{
    class Cipher
    {
        /*private string fromFile;
        private int keyValue;
        
        public string FromFile
        {
            get { return fromFile; }
            set { fromFile = value; }
        }
        public int KeyValue
        {
            get { return keyValue; }
            set { keyValue = value; }
        }*/


        public string Encrypt(string value, int shift)
        {
   

            shift %= 33;//prevent if shift large than >33
            if(string.IsNullOrEmpty(value)||string.IsNullOrWhiteSpace(value))
            {
                return new string(value);
            }
            char[] buffer = value.ToCharArray();
            
            for(int i = 0;i < buffer.Length;i++)
            {
           
                char letter = buffer[i];
                if (Convert.ToInt16(letter) + shift > 1103)
                {
                    letter = (char)(letter + shift - 32);
                }
                else
                { letter = (char)(letter + shift); }
                if (char.IsWhiteSpace(letter)||char.IsDigit(letter)||char.IsPunctuation(letter)||char.IsSeparator(letter))
                {
                    continue;
                }
                if (letter < 'А' && letter > 'Я')
                {
                    //letter = (char)(letter - 33);
                    letter = (char)((letter -'А'+shift)%33+'А');

                }
                else if(letter<'а'&&letter>'я')
                {
                    //letter = (char)(letter + 33);
                    letter = (char)((letter - 'а' + shift) % 33 + 'а');
                }
                
                buffer[i] = letter;
            }
            return new string(buffer);
        }


    }

}

