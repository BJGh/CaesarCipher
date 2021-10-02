using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CaesarCipher
{
    class FileProcessor
    {


        StreamReader sr = File.OpenText("chapter1.txt");
        Cipher cipher = new Cipher();
        public void readFileCrypted(int key)
        {
            string textline;
            string toFile;
             while(!sr.EndOfStream)
              {
                textline = sr.ReadLine();
               toFile =  cipher.Encrypt(textline, key);
                writeFileCrypted(toFile);
              }
             
  
        }
        public void  writeFileCrypted(string messagetype)
        {

            string fileName = "caesarencrypt.txt";
            var fileWriter = new StreamWriter(fileName,true);
            fileWriter.WriteLine(messagetype);
            fileWriter.Close();
        }
        public void writeFileDecryption(string v)
        {
            string fileName = "result.txt";
            var Writer = new StreamWriter(fileName, true);
                Writer.WriteLine(v);
            Writer.Close();
        }
    }
}
